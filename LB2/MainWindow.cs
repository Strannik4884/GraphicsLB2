using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LB2
{
    public partial class MainWindow : Form
    {
        private readonly ImageHandler imageHandler = new ImageHandler();
        private readonly Detector detector = new Detector();
        private readonly double defaultLowerTreshold = 0.02;
        private readonly double defaultUpperTreshold = 0.08;

        public MainWindow()
        {
            InitializeComponent();
            // инициализация параметров
            lowerTresholdValue.Value = 2;
            upperTresholdValue.Value = 8;
            lowerTresholdBox.Text = defaultLowerTreshold.ToString();
            upperTresholdBox.Text = defaultUpperTreshold.ToString();
            detector.LowerTreshold = defaultLowerTreshold;
            detector.UpperTreshold = defaultUpperTreshold;
            detector.IsMaxPrecision = false;
        }

        // обработчик события изменения значения нижнего порога
        private void lowerTresholdValue_Scroll(object sender, EventArgs e)
        {
            var v = lowerTresholdValue.Value / 100.0;
            detector.LowerTreshold = v;
            lowerTresholdBox.Text = v.ToString();
        }

        // обработчик события изменения значения верхнего порога
        private void upperTresholdValue_Scroll(object sender, EventArgs e)
        {
            var v = upperTresholdValue.Value / 100.0;
            detector.UpperTreshold = v;
            upperTresholdBox.Text = v.ToString();
        }

        // обработчик события изменения флага автоматического расчёта порогов
        private void calculateTresholdsFlag_CheckedChanged(object sender, EventArgs e)
        {
            detector.LowerTreshold = 0;
            detector.UpperTreshold = 0;

            upperTresholdValue.Value = 0;
            lowerTresholdValue.Value = 0;

            lowerTresholdBox.Text = "0.0";
            upperTresholdBox.Text = "0.0";

            lowerTresholdValue.Enabled = !lowerTresholdValue.Enabled;
            upperTresholdValue.Enabled = !upperTresholdValue.Enabled;
        }

        // обработчик события изменения значения точности вычислений
        private void precisionValue_Scroll(object sender, EventArgs e)
        {
            precisionBox.Text = precisionValue.Value.ToString();
        }
        
        // обработчик события изменения флага максимальной точности вычислений
        private void maxPrecisionFlag_CheckedChanged(object sender, EventArgs e)
        {
            precisionValue.Value = 1;
            precisionBox.Text = "1";
            precisionValue.Enabled = !precisionValue.Enabled;
            detector.IsMaxPrecision = !detector.IsMaxPrecision;
        }

        // обработчик пункта меню очистки формы
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultImageBox.Image = null;
            originalImageBox.Image = null;

            if (imageHandler.CurrentBitmap != null) imageHandler.CurrentBitmap.Dispose();
            if (imageHandler.OriginalBitmap != null) imageHandler.OriginalBitmap.Dispose();

            lowerTresholdValue.Value = 2;
            upperTresholdValue.Value = 8;
            lowerTresholdBox.Text = defaultLowerTreshold.ToString();
            upperTresholdBox.Text = defaultUpperTreshold.ToString();
            detector.LowerTreshold = defaultLowerTreshold;
            detector.UpperTreshold = defaultUpperTreshold;
            detector.IsMaxPrecision = false;
        }

        // обработчик пункта меню загрузки изображения
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp"
                };
                if (DialogResult.OK != openFileDialog.ShowDialog()) return;
                resultImageBox.Image = null;
                originalImageBox.Image = null;

                if (imageHandler.CurrentBitmap != null) imageHandler.CurrentBitmap.Dispose();
                if (imageHandler.OriginalBitmap != null) imageHandler.OriginalBitmap.Dispose();

                imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(openFileDialog.FileName);
                imageHandler.OriginalBitmap = (Bitmap)Image.FromFile(openFileDialog.FileName);
                imageHandler.BitmapPath = openFileDialog.FileName;

                originalImageBox.Image = imageHandler.OriginalBitmap;

                imageResolutionBox.Text = originalImageBox.Image.Width.ToString() + "x" + originalImageBox.Image.Height.ToString();
                imageSizeBox.Text = Math.Round((new FileInfo(openFileDialog.FileName).Length / 1000000.0), 2).ToString() + "MB";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при открытии изображения: неверный формат файла", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // обработчик пункта меню сохранения изображения
        private void saveFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // получаем Bitmap полученного изображения
                    Bitmap bmp = imageHandler.CurrentBitmap;
                    bmp.Save(saveFileDialog.FileName, GetImageFormatByFilterIndex(saveFileDialog.FilterIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения: " + ex.Message, "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // обработчик пункта меню выхода из приложения
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // обработчик пункта меню определения границ
        private void detectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            lastDetectionTimeBox.Text = "Выполонение...";

            imageHandler.SetGrayscale();

            Stopwatch stopwtach = new Stopwatch();
            stopwtach.Start();

            try
            {
                var n = imageHandler.GetNormalizedMatrix();
                var image = detector.Detection(n, precisionValue.Value);

                imageHandler.DenormalizeCurrent(image);

                n = null;
                image = null;

                stopwtach.Stop();
                string elapsed = stopwtach.Elapsed.ToString();
                lastDetectionTimeBox.Text = elapsed.Substring(0, 11);

                detector.CleanUp();
                GC.Collect();

                resultImageBox.Image = imageHandler.CurrentBitmap;
            }
            catch (OutOfMemoryException)
            {
                resultImageBox.Image = null;
                resultImageBox.Dispose();
                originalImageBox.Image = null;
                originalImageBox.Dispose();
                imageHandler.CleanUp();
                detector.CleanUp();
                lastDetectionTimeBox.Text = "0";
                MessageBox.Show("Выбранное изображение слишком велико. Выберите изображение меньшего размера и повторите попытку", "Ошибка поиска границ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        // функция для получения формата изображения по выбранному индексу фильтра
        private ImageFormat GetImageFormatByFilterIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ImageFormat.Png;
                case 1:
                    return ImageFormat.Jpeg;
                case 2:
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Png;
            }
        }
    }
}
