namespace AudioFind
{
    partial class Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TestResultsList = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.TestGetResults = new System.Windows.Forms.Button();
            this.TestSoundType = new System.Windows.Forms.ComboBox();
            this.TestFileSelect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.TrainResults = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClearModelList = new System.Windows.Forms.Button();
            this.GenModels = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SaveModel = new System.Windows.Forms.Button();
            this.TrainGetResults = new System.Windows.Forms.Button();
            this.SoundTypeTrain = new System.Windows.Forms.ComboBox();
            this.Classifiers = new System.Windows.Forms.ComboBox();
            this.TestFileForTrain = new System.Windows.Forms.Button();
            this.TrainingFolder = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 440);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.TestGetResults);
            this.tabPage1.Controls.Add(this.TestSoundType);
            this.tabPage1.Controls.Add(this.TestFileSelect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(803, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search Audio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(8, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TestResultsList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.axWindowsMediaPlayer1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 359);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 3;
            // 
            // TestResultsList
            // 
            this.TestResultsList.FormattingEnabled = true;
            this.TestResultsList.Location = new System.Drawing.Point(3, 31);
            this.TestResultsList.Name = "TestResultsList";
            this.TestResultsList.Size = new System.Drawing.Size(256, 316);
            this.TestResultsList.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(245, 202);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 154);
            this.textBox1.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(3, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(520, 193);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // TestGetResults
            // 
            this.TestGetResults.Location = new System.Drawing.Point(371, 3);
            this.TestGetResults.Name = "TestGetResults";
            this.TestGetResults.Size = new System.Drawing.Size(109, 26);
            this.TestGetResults.TabIndex = 2;
            this.TestGetResults.Text = "Get Results";
            this.TestGetResults.UseVisualStyleBackColor = true;
            this.TestGetResults.Click += new System.EventHandler(this.TestGetResults_Click);
            // 
            // TestSoundType
            // 
            this.TestSoundType.FormattingEnabled = true;
            this.TestSoundType.Location = new System.Drawing.Point(55, 8);
            this.TestSoundType.Name = "TestSoundType";
            this.TestSoundType.Size = new System.Drawing.Size(121, 21);
            this.TestSoundType.TabIndex = 1;
            // 
            // TestFileSelect
            // 
            this.TestFileSelect.Location = new System.Drawing.Point(228, 3);
            this.TestFileSelect.Name = "TestFileSelect";
            this.TestFileSelect.Size = new System.Drawing.Size(119, 26);
            this.TestFileSelect.TabIndex = 0;
            this.TestFileSelect.Text = "Select Test File";
            this.TestFileSelect.UseVisualStyleBackColor = true;
            this.TestFileSelect.Click += new System.EventHandler(this.TestFileSelect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Controls.Add(this.TrainGetResults);
            this.tabPage2.Controls.Add(this.SoundTypeTrain);
            this.tabPage2.Controls.Add(this.Classifiers);
            this.tabPage2.Controls.Add(this.TestFileForTrain);
            this.tabPage2.Controls.Add(this.TrainingFolder);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(803, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Train";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(3, 33);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.TrainResults);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.ClearModelList);
            this.splitContainer2.Panel2.Controls.Add(this.GenModels);
            this.splitContainer2.Panel2.Controls.Add(this.axWindowsMediaPlayer2);
            this.splitContainer2.Panel2.Controls.Add(this.textBox2);
            this.splitContainer2.Panel2.Controls.Add(this.SaveModel);
            this.splitContainer2.Size = new System.Drawing.Size(794, 373);
            this.splitContainer2.SplitterDistance = 264;
            this.splitContainer2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Results";
            // 
            // TrainResults
            // 
            this.TrainResults.FormattingEnabled = true;
            this.TrainResults.Location = new System.Drawing.Point(3, 28);
            this.TrainResults.Name = "TrainResults";
            this.TrainResults.Size = new System.Drawing.Size(258, 342);
            this.TrainResults.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Generated models";
            // 
            // ClearModelList
            // 
            this.ClearModelList.Location = new System.Drawing.Point(430, 347);
            this.ClearModelList.Name = "ClearModelList";
            this.ClearModelList.Size = new System.Drawing.Size(93, 22);
            this.ClearModelList.TabIndex = 5;
            this.ClearModelList.Text = "Clear Results";
            this.ClearModelList.UseVisualStyleBackColor = true;
            this.ClearModelList.Click += new System.EventHandler(this.ClearModelList_Click);
            // 
            // GenModels
            // 
            this.GenModels.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.GenModels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GenModels.FormattingEnabled = true;
            this.GenModels.Location = new System.Drawing.Point(403, 222);
            this.GenModels.Name = "GenModels";
            this.GenModels.Size = new System.Drawing.Size(120, 119);
            this.GenModels.TabIndex = 4;
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(4, 3);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(519, 176);
            this.axWindowsMediaPlayer2.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(4, 185);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 184);
            this.textBox2.TabIndex = 2;
            // 
            // SaveModel
            // 
            this.SaveModel.Location = new System.Drawing.Point(309, 348);
            this.SaveModel.Name = "SaveModel";
            this.SaveModel.Size = new System.Drawing.Size(115, 23);
            this.SaveModel.TabIndex = 1;
            this.SaveModel.Text = "Save selected model";
            this.SaveModel.UseVisualStyleBackColor = true;
            this.SaveModel.Click += new System.EventHandler(this.SaveModel_Click);
            // 
            // TrainGetResults
            // 
            this.TrainGetResults.Location = new System.Drawing.Point(590, 8);
            this.TrainGetResults.Name = "TrainGetResults";
            this.TrainGetResults.Size = new System.Drawing.Size(80, 22);
            this.TrainGetResults.TabIndex = 4;
            this.TrainGetResults.Text = "Get Results";
            this.TrainGetResults.UseVisualStyleBackColor = true;
            this.TrainGetResults.Click += new System.EventHandler(this.TrainGetResults_Click);
            // 
            // SoundTypeTrain
            // 
            this.SoundTypeTrain.FormattingEnabled = true;
            this.SoundTypeTrain.Location = new System.Drawing.Point(43, 6);
            this.SoundTypeTrain.Name = "SoundTypeTrain";
            this.SoundTypeTrain.Size = new System.Drawing.Size(117, 21);
            this.SoundTypeTrain.TabIndex = 3;
            // 
            // Classifiers
            // 
            this.Classifiers.FormattingEnabled = true;
            this.Classifiers.Location = new System.Drawing.Point(470, 7);
            this.Classifiers.Name = "Classifiers";
            this.Classifiers.Size = new System.Drawing.Size(94, 21);
            this.Classifiers.TabIndex = 2;
            this.Classifiers.SelectedIndexChanged += new System.EventHandler(this.Classifiers_SelectedIndexChanged);
            // 
            // TestFileForTrain
            // 
            this.TestFileForTrain.Location = new System.Drawing.Point(357, 6);
            this.TestFileForTrain.Name = "TestFileForTrain";
            this.TestFileForTrain.Size = new System.Drawing.Size(90, 21);
            this.TestFileForTrain.TabIndex = 1;
            this.TestFileForTrain.Text = "Select Test File";
            this.TestFileForTrain.UseVisualStyleBackColor = true;
            this.TestFileForTrain.Click += new System.EventHandler(this.TestFileForTrain_Click);
            // 
            // TrainingFolder
            // 
            this.TrainingFolder.Location = new System.Drawing.Point(208, 6);
            this.TrainingFolder.Name = "TrainingFolder";
            this.TrainingFolder.Size = new System.Drawing.Size(105, 21);
            this.TrainingFolder.TabIndex = 0;
            this.TrainingFolder.Text = "Select Training Set";
            this.TrainingFolder.UseVisualStyleBackColor = true;
            this.TrainingFolder.Click += new System.EventHandler(this.TrainingFolder_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(811, 440);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Controller";
            this.Text = "AudioFind";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TestResultsList;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button TestGetResults;
        private System.Windows.Forms.ComboBox TestSoundType;
        private System.Windows.Forms.Button TestFileSelect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox TrainResults;
        private System.Windows.Forms.Button TrainGetResults;
        private System.Windows.Forms.ComboBox SoundTypeTrain;
        private System.Windows.Forms.ComboBox Classifiers;
        private System.Windows.Forms.Button TestFileForTrain;
        private System.Windows.Forms.Button TrainingFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button SaveModel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.ListBox GenModels;
        private System.Windows.Forms.Button ClearModelList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

