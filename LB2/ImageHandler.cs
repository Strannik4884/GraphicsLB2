using System;
using System.Drawing.Imaging;
using System.Drawing;

namespace LB2
{
    public class ImageHandler
    {
        private string bitmapPath;
        private Bitmap currentBitmap;
        private Bitmap originalBitmap;
        private bool isGrayscale = false;
        private byte bitsPerPixel;

        // флаг применения фильтра оттенков серого
        public bool IsGrayscale
        {
            get
            {
                return isGrayscale;
            }

            private set
            {
                isGrayscale = value;
            }
        }

        // Bitmap оригинального изображения
        public Bitmap OriginalBitmap
        {
            set
            {
                originalBitmap = value;
            }

            get
            {
                return originalBitmap;
            }
        }

        // Bitmap текущего изображения
        public Bitmap CurrentBitmap
        {
            get
            {
                return currentBitmap;
            }

            set
            {
                currentBitmap = value;
                isGrayscale = false;
            }
        }

        // путь до изображения
        public string BitmapPath
        {
            get
            {
                return bitmapPath;
            }

            set
            {
                bitmapPath = value;
            }
        }

        // функция получения количества бит на один пиксель
        public byte GetBitsPerPixel(PixelFormat pixelFormat)
        {
            byte BitsPerPixel;
            switch (pixelFormat)
            {
                case PixelFormat.Format8bppIndexed:
                    BitsPerPixel = 8;
                    break;
                case PixelFormat.Format24bppRgb:
                    BitsPerPixel = 24;
                    break;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                    BitsPerPixel = 32;
                    break;
                default:
                    BitsPerPixel = 0;
                    break;
            }

            return BitsPerPixel;
        }

        // применение фильтра оттенков серого на текущее изображение
        public unsafe void SetGrayscale()
        {
            // если текущий Bitmap пуст или фильтр уже был применён - выходим из функции
            if (CurrentBitmap == null || isGrayscale)
            {
                return;
            }
            // получаем данные текущего Bitmap'а и блокируем его
            BitmapData bData = currentBitmap.LockBits(new Rectangle(0, 0, currentBitmap.Width, currentBitmap.Height), ImageLockMode.ReadWrite, currentBitmap.PixelFormat);
            // получаем количество битов на один пиксель
            bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
            // получаем указатель на данные Bitmap'а
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            // применяем фильтр
            byte* data;
            // проходимся по всем пикселям
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    // вычисляем позицию начала текущего пикселя
                    data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;
                    // если цветовая палитра больше или равна 24 битам на пиксель
                    if (bitsPerPixel >= 24)
                    {
                        // вычисляем значение фильтра
                        var gray = (byte)(.299 * data[2] + .587 * data[1] + .114 * data[0]);
                        // применяем значение к цветовой палитре RGB
                        data[0] = gray;
                        data[1] = gray;
                        data[2] = gray; 
                    }
                }
            }
            // разблокируем Bitmap текущего изображения
            currentBitmap.UnlockBits(bData);
            isGrayscale = true;
        }

        // нормализуем Bitmap текущего изображения
        public unsafe double[,] GetNormalizedMatrix()
        {
            // если текущий Bitmap пуст - выходим из функции
            if (originalBitmap == null)
            {
                return null;
            }
            // получаем данные текущего Bitmap'а и блокируем его
            BitmapData bData = originalBitmap.LockBits(new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height), ImageLockMode.ReadWrite, originalBitmap.PixelFormat);
            // получаем количество битов на один пиксель
            bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
            // получаем указатель на данные Bitmap'а
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            // выделяем массив под нормализованный Bitmap
            var normalizedMatrix = new double[originalBitmap.Width, originalBitmap.Height];
            // нормализуем Bitmap
            byte* data;
            // проходимся по всем пикселям
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    // вычисляем позицию начала текущего пикселя
                    data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;
                    // нормализуем
                    normalizedMatrix[j, i] = data[0] / 255d;
                }
            }
            // разблокируем Bitmap текущего изображения
            originalBitmap.UnlockBits(bData);

            return normalizedMatrix;
        }

        // денормализация Bitmap'а текущего изображения
        public unsafe void DenormalizeCurrent(double[,] norm)
        {
            // если массив пуст - выходим из функции
            if (norm == null)
            {
                return;
            }
            // размеры массива
            int n = norm.GetLength(0);
            int m = norm.GetLength(1);

            // проверяем размеры массива с размерами текущего Bitmap'а
            if (m != currentBitmap.Height || n != currentBitmap.Width)
            {
                throw new Exception("Sizes don't match.");
            }

            // получаем данные текущего Bitmap'а и блокируем его
            BitmapData bData = currentBitmap.LockBits(new Rectangle(0, 0, currentBitmap.Width, currentBitmap.Height), ImageLockMode.ReadWrite, currentBitmap.PixelFormat);
            // получаем количество битов на один пиксель
            bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
            // получаем указатель на данные Bitmap'а
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            // денормализуем Bitmap
            byte* data;
            // проходимся по всем пикселям
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    // вычисляем позицию начала текущего пикселя
                    data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;
                    // рассчитываем новое значение для цвета с учётом переполнения
                    byte newCol = norm[j, i] == 0 ? (byte)0 : (byte)255;
                    // если цветовая палитра больше или равна 24 битам на пиксель
                    if (bitsPerPixel >= 24)
                    {
                        // применяем значение к цветовой палитре RGB
                        data[0] = newCol;
                        data[1] = newCol;
                        data[2] = newCol;
                    }
                    else
                    {
                        data[0] = newCol;
                    }
                }
            }
            // разблокируем Bitmap текущего изображения
            currentBitmap.UnlockBits(bData);
        }

        // очистка всех данных
        public void CleanUp()
        {
            currentBitmap = null;
            originalBitmap = null;
            isGrayscale = false;
            bitsPerPixel = 0;
            bitmapPath = "";
            GC.Collect();
        }
    }
}
