namespace LB2
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.resultImageBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lowerTresholdValue = new System.Windows.Forms.TrackBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.originalImageBox = new System.Windows.Forms.PictureBox();
            this.upperTresholdValue = new System.Windows.Forms.TrackBar();
            this.lowerTresholdLabel = new System.Windows.Forms.Label();
            this.upperTresholdLabel = new System.Windows.Forms.Label();
            this.lowerTresholdBox = new System.Windows.Forms.Label();
            this.upperTresholdBox = new System.Windows.Forms.Label();
            this.calculateTresholdsFlag = new System.Windows.Forms.CheckBox();
            this.precisionValue = new System.Windows.Forms.TrackBar();
            this.precisionLabel = new System.Windows.Forms.Label();
            this.precisionBox = new System.Windows.Forms.Label();
            this.maxPrecisionFlag = new System.Windows.Forms.CheckBox();
            this.appInfo = new System.Windows.Forms.StatusStrip();
            this.imageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageResolutionBox = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageSizeBox = new System.Windows.Forms.ToolStripStatusLabel();
            this.spring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastDetectionTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastDetectionTimeBox = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeUnitLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerTresholdValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperTresholdValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precisionValue)).BeginInit();
            this.appInfo.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultImageBox
            // 
            this.resultImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultImageBox.InitialImage = null;
            this.resultImageBox.Location = new System.Drawing.Point(3, 0);
            this.resultImageBox.Name = "resultImageBox";
            this.resultImageBox.Size = new System.Drawing.Size(321, 277);
            this.resultImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultImageBox.TabIndex = 0;
            this.resultImageBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lowerTresholdValue
            // 
            this.lowerTresholdValue.Location = new System.Drawing.Point(13, 129);
            this.lowerTresholdValue.Maximum = 100;
            this.lowerTresholdValue.Name = "lowerTresholdValue";
            this.lowerTresholdValue.Size = new System.Drawing.Size(272, 45);
            this.lowerTresholdValue.TabIndex = 1;
            this.lowerTresholdValue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.lowerTresholdValue.Scroll += new System.EventHandler(this.lowerTresholdValue_Scroll);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(12, 205);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.originalImageBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.resultImageBox);
            this.splitContainer.Size = new System.Drawing.Size(660, 282);
            this.splitContainer.SplitterDistance = 327;
            this.splitContainer.TabIndex = 2;
            // 
            // originalImageBox
            // 
            this.originalImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalImageBox.InitialImage = null;
            this.originalImageBox.Location = new System.Drawing.Point(3, 3);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(319, 274);
            this.originalImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalImageBox.TabIndex = 0;
            this.originalImageBox.TabStop = false;
            // 
            // upperTresholdValue
            // 
            this.upperTresholdValue.Location = new System.Drawing.Point(345, 129);
            this.upperTresholdValue.Maximum = 100;
            this.upperTresholdValue.Name = "upperTresholdValue";
            this.upperTresholdValue.Size = new System.Drawing.Size(290, 45);
            this.upperTresholdValue.TabIndex = 3;
            this.upperTresholdValue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.upperTresholdValue.Scroll += new System.EventHandler(this.upperTresholdValue_Scroll);
            // 
            // lowerTresholdLabel
            // 
            this.lowerTresholdLabel.AutoSize = true;
            this.lowerTresholdLabel.Location = new System.Drawing.Point(19, 104);
            this.lowerTresholdLabel.Name = "lowerTresholdLabel";
            this.lowerTresholdLabel.Size = new System.Drawing.Size(82, 13);
            this.lowerTresholdLabel.TabIndex = 4;
            this.lowerTresholdLabel.Text = "Нижний порог:";
            // 
            // upperTresholdLabel
            // 
            this.upperTresholdLabel.AutoSize = true;
            this.upperTresholdLabel.Location = new System.Drawing.Point(344, 104);
            this.upperTresholdLabel.Name = "upperTresholdLabel";
            this.upperTresholdLabel.Size = new System.Drawing.Size(84, 13);
            this.upperTresholdLabel.TabIndex = 5;
            this.upperTresholdLabel.Text = "Верхний порог:";
            // 
            // lowerTresholdBox
            // 
            this.lowerTresholdBox.AutoSize = true;
            this.lowerTresholdBox.Location = new System.Drawing.Point(291, 129);
            this.lowerTresholdBox.Name = "lowerTresholdBox";
            this.lowerTresholdBox.Size = new System.Drawing.Size(22, 13);
            this.lowerTresholdBox.TabIndex = 8;
            this.lowerTresholdBox.Text = "0.0";
            // 
            // upperTresholdBox
            // 
            this.upperTresholdBox.AutoSize = true;
            this.upperTresholdBox.Location = new System.Drawing.Point(641, 129);
            this.upperTresholdBox.Name = "upperTresholdBox";
            this.upperTresholdBox.Size = new System.Drawing.Size(22, 13);
            this.upperTresholdBox.TabIndex = 9;
            this.upperTresholdBox.Text = "0.0";
            // 
            // calculateTresholdsFlag
            // 
            this.calculateTresholdsFlag.AutoSize = true;
            this.calculateTresholdsFlag.Location = new System.Drawing.Point(347, 68);
            this.calculateTresholdsFlag.Name = "calculateTresholdsFlag";
            this.calculateTresholdsFlag.Size = new System.Drawing.Size(191, 17);
            this.calculateTresholdsFlag.TabIndex = 10;
            this.calculateTresholdsFlag.Text = "Автоматический расчёт порогов";
            this.calculateTresholdsFlag.UseVisualStyleBackColor = true;
            this.calculateTresholdsFlag.CheckedChanged += new System.EventHandler(this.calculateTresholdsFlag_CheckedChanged);
            // 
            // precisionValue
            // 
            this.precisionValue.Location = new System.Drawing.Point(10, 56);
            this.precisionValue.Maximum = 100;
            this.precisionValue.Minimum = 1;
            this.precisionValue.Name = "precisionValue";
            this.precisionValue.Size = new System.Drawing.Size(273, 45);
            this.precisionValue.TabIndex = 11;
            this.precisionValue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.precisionValue.Value = 50;
            this.precisionValue.Scroll += new System.EventHandler(this.precisionValue_Scroll);
            // 
            // precisionLabel
            // 
            this.precisionLabel.AutoSize = true;
            this.precisionLabel.Location = new System.Drawing.Point(19, 37);
            this.precisionLabel.Name = "precisionLabel";
            this.precisionLabel.Size = new System.Drawing.Size(134, 13);
            this.precisionLabel.TabIndex = 12;
            this.precisionLabel.Text = "Точность поиска границ:";
            // 
            // precisionBox
            // 
            this.precisionBox.AutoSize = true;
            this.precisionBox.Location = new System.Drawing.Point(290, 56);
            this.precisionBox.Name = "precisionBox";
            this.precisionBox.Size = new System.Drawing.Size(19, 13);
            this.precisionBox.TabIndex = 13;
            this.precisionBox.Text = "50";
            // 
            // maxPrecisionFlag
            // 
            this.maxPrecisionFlag.AutoSize = true;
            this.maxPrecisionFlag.Location = new System.Drawing.Point(347, 36);
            this.maxPrecisionFlag.Name = "maxPrecisionFlag";
            this.maxPrecisionFlag.Size = new System.Drawing.Size(190, 17);
            this.maxPrecisionFlag.TabIndex = 14;
            this.maxPrecisionFlag.Text = "Максимальная точность поиска";
            this.maxPrecisionFlag.UseVisualStyleBackColor = true;
            this.maxPrecisionFlag.CheckedChanged += new System.EventHandler(this.maxPrecisionFlag_CheckedChanged);
            // 
            // appInfo
            // 
            this.appInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageLabel,
            this.imageResolutionBox,
            this.imageSizeBox,
            this.spring,
            this.lastDetectionTimeLabel,
            this.lastDetectionTimeBox,
            this.timeUnitLabel});
            this.appInfo.Location = new System.Drawing.Point(0, 499);
            this.appInfo.Name = "appInfo";
            this.appInfo.ShowItemToolTips = true;
            this.appInfo.Size = new System.Drawing.Size(684, 22);
            this.appInfo.TabIndex = 15;
            this.appInfo.Text = "Info";
            // 
            // imageLabel
            // 
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(86, 17);
            this.imageLabel.Text = "Изображение:";
            // 
            // imageResolutionBox
            // 
            this.imageResolutionBox.Name = "imageResolutionBox";
            this.imageResolutionBox.Size = new System.Drawing.Size(25, 17);
            this.imageResolutionBox.Text = "0x0";
            // 
            // imageSizeBox
            // 
            this.imageSizeBox.Name = "imageSizeBox";
            this.imageSizeBox.Size = new System.Drawing.Size(34, 17);
            this.imageSizeBox.Text = "0 МБ";
            // 
            // spring
            // 
            this.spring.Name = "spring";
            this.spring.Size = new System.Drawing.Size(310, 17);
            this.spring.Spring = true;
            // 
            // lastDetectionTimeLabel
            // 
            this.lastDetectionTimeLabel.Name = "lastDetectionTimeLabel";
            this.lastDetectionTimeLabel.Size = new System.Drawing.Size(154, 17);
            this.lastDetectionTimeLabel.Text = "Время последнего поиска:";
            this.lastDetectionTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lastDetectionTimeBox
            // 
            this.lastDetectionTimeBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lastDetectionTimeBox.Name = "lastDetectionTimeBox";
            this.lastDetectionTimeBox.Size = new System.Drawing.Size(13, 17);
            this.lastDetectionTimeBox.Text = "0";
            this.lastDetectionTimeBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeUnitLabel
            // 
            this.timeUnitLabel.Name = "timeUnitLabel";
            this.timeUnitLabel.Size = new System.Drawing.Size(16, 17);
            this.timeUnitLabel.Text = "с.";
            this.timeUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.detectToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 16;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveFileAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Очистить";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "Открыть файл";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileAsToolStripMenuItem
            // 
            this.saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
            this.saveFileAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveFileAsToolStripMenuItem.Text = "Сохранить как";
            this.saveFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveFileAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // detectToolStripMenuItem
            // 
            this.detectToolStripMenuItem.Name = "detectToolStripMenuItem";
            this.detectToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.detectToolStripMenuItem.Text = "Определить границы";
            this.detectToolStripMenuItem.Click += new System.EventHandler(this.detectToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 521);
            this.Controls.Add(this.appInfo);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.maxPrecisionFlag);
            this.Controls.Add(this.precisionBox);
            this.Controls.Add(this.precisionLabel);
            this.Controls.Add(this.precisionValue);
            this.Controls.Add(this.calculateTresholdsFlag);
            this.Controls.Add(this.upperTresholdBox);
            this.Controls.Add(this.lowerTresholdBox);
            this.Controls.Add(this.upperTresholdLabel);
            this.Controls.Add(this.lowerTresholdLabel);
            this.Controls.Add(this.upperTresholdValue);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.lowerTresholdValue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(700, 560);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №2";
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerTresholdValue)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperTresholdValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precisionValue)).EndInit();
            this.appInfo.ResumeLayout(false);
            this.appInfo.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox resultImageBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TrackBar lowerTresholdValue;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TrackBar upperTresholdValue;
        private System.Windows.Forms.Label lowerTresholdLabel;
        private System.Windows.Forms.Label upperTresholdLabel;
        private System.Windows.Forms.PictureBox originalImageBox;
        private System.Windows.Forms.Label lowerTresholdBox;
        private System.Windows.Forms.Label upperTresholdBox;
        private System.Windows.Forms.CheckBox calculateTresholdsFlag;
        private System.Windows.Forms.TrackBar precisionValue;
        private System.Windows.Forms.Label precisionLabel;
        private System.Windows.Forms.Label precisionBox;
        private System.Windows.Forms.CheckBox maxPrecisionFlag;
        private System.Windows.Forms.StatusStrip appInfo;
        private System.Windows.Forms.ToolStripStatusLabel lastDetectionTimeLabel;
        private System.Windows.Forms.ToolStripStatusLabel lastDetectionTimeBox;
        private System.Windows.Forms.ToolStripStatusLabel timeUnitLabel;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripStatusLabel imageLabel;
        private System.Windows.Forms.ToolStripStatusLabel imageResolutionBox;
        private System.Windows.Forms.ToolStripStatusLabel imageSizeBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectToolStripMenuItem;
    }
}

