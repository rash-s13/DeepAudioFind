using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using weka.classifiers;
using DeepMat;
using AxWMPLib;
using System.Configuration;

namespace AudioFind
{
    public partial class Controller : Form
    {
        private double[] predictions;
        //timer used to play results for given duration and then stop
        private System.Timers.Timer tmrWmpPlayerPosition;
        double start, end;
        double counter = 0;
        //player 1 - search interface, player2 - training interface; 
        AxWMPLib.AxWindowsMediaPlayer player = null;
        AxWMPLib.AxWindowsMediaPlayer player1 = null;
        AxWMPLib.AxWindowsMediaPlayer player2 = null;
        //DeepMat is matlab functions compiled into DLL for use in this application
        public DeepMat.DeepMat audiolab = new DeepMat.DeepMat();
        //classifier selected by user in training interface
        Classifier selected = null;
        double win, step;
        int numf = 0;
        Utils util = new Utils();
        string target = null;
        int count = 1;

        //constructor to initialize view components and player controls
        public Controller()
        {
            InitializeComponent();
            TestResultsList.DoubleClick += new EventHandler(TestResultsList_DoubleClick);
            TrainResults.DoubleClick += new EventHandler(TrainResults_DoubleClick);
            GenModels.DoubleClick += new EventHandler(GenModels_DoubleClick);

            Classifiers.DisplayMember = "Name";
            Classifiers.ValueMember = "cls";

            List<Model.Comboitems> comboList = Model.initializeclassifiers();
            Classifiers.DataSource = comboList;

            
            TestSoundType.DisplayMember = "Name";
            TestSoundType.ValueMember = "Id";
            SoundTypeTrain.DisplayMember = "Name";
            SoundTypeTrain.ValueMember = "Id";
            List<Model.CheckBoxItem> soundList = Model.initializeSounds();

            TestSoundType.DataSource = soundList;
            SoundTypeTrain.DataSource = soundList;
            this.player1 = axWindowsMediaPlayer1;
            this.player2 = axWindowsMediaPlayer2;
        }

        //Function to take predictions and display them as results in listbox
        private void displayresults(ListBox list)
        {
            int j = 1;
            List<Model.CheckBoxItem> checkboxItemList = new List<Model.CheckBoxItem>();
            list.DisplayMember = "Name";
            list.ValueMember = "Id";
            string[] s = new string[predictions.Length];
            for (int i = 0; i < predictions.Length; i++)
            {
                if (predictions[i] == 0)
                {
                    var checkboxItem = new Model.CheckBoxItem
                    {
                        Id = i,
                        Name = "result-sound-" + j
                    };
                    list.Items.Add(checkboxItem);
                    j++;
                }
            }
        }

        //Funtion to click event of result files by user in search audio interface 
        private void TestResultsList_DoubleClick(object sender, EventArgs e)
        {
            int value = (TestResultsList.SelectedItem as Model.CheckBoxItem).Id;
            player = player1;
            playsample(value);
        }

        //Funtion to click event of result files by user in training interface
        private void TrainResults_DoubleClick(object sender, EventArgs e)
        {
            int value = (TrainResults.SelectedItem as Model.CheckBoxItem).Id;
            player = player2;
            playsample(value);
        }

        //Function to display results for the model selected by user
        private async void GenModels_DoubleClick(object sender, EventArgs e)
        {
            TrainResults.Items.Clear();
            Classifier cl = (GenModels.SelectedItem as Model.modelitems).cls;
            predictions = await Task.Run(() => util.wekatrainandclassify(cl, target));
            player = player2;
            displayresults(TrainResults);
        }

        //play selected sample by calculating duration and position of result in test file
        private void playsample(int value)
        {
            start = value * (step);
            counter = start;
            end = (value * win) + step;
            textBox1.Text = "Position of result sample : " + start + "s to " + end + "s";
            player.Ctlcontrols.currentPosition = start;
            StopWmpPlayerTimer();
            StartWmpPlayerTimer(100);

            player.Ctlcontrols.play();
        }

        //event handler for test file selection button
        private void TestFileSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Wave Sound|*.wav";
            openFileDialog1.ShowDialog();
        }

        //evet handler function when user clicks "GetResults" in search audio interface
        private async void TestGetResults_Click(object sender, EventArgs e)
        {
            TestGetResults.Enabled = false;
            TestFileSelect.Enabled = false;
            TestResultsList.Items.Clear();
            string filename = openFileDialog1.FileName;

            if (filename == null)
            {
                MessageBox.Show("No test file selected!");
                return;
            }
            int value = (TestSoundType.SelectedItem as Model.CheckBoxItem).Id;

            setParameters(value);

            textBox1.Text = "Extracting test files features ...\r\n";

            await Task.Run(() => audiolab.deep_learning_test(target, filename, numf, win, step));

            textBox1.Text += "Creating ARFF files ...\r\n";
            await Task.Run(() => util.createWekafiles(target, "test", value));

            textBox1.Text += "Weka generating predictions...\r\n";
            //generate predictions on test data
            predictions = await Task.Run(() => util.wekaclassify(target));
            player = player1;
            player.settings.autoStart = false;
            player.URL = filename;
            displayresults(TestResultsList);
            StoreResultstoFile(filename, target, value);

            TestGetResults.Enabled = true;
            TestFileSelect.Enabled = true;
            textBox1.Text = "Done!";
        }

        //Store results from search audio o text file for future reference
        private void StoreResultstoFile(string testfile, string path, int value)
        {
            testfile = Path.GetFileNameWithoutExtension(testfile);
            string results;
            if(value == 1)
             results = path + "\\" + testfile + "-Hresults.txt";
            else
                results = path + "\\" + testfile + "-OKIresults.txt";

            System.IO.StreamWriter file = new System.IO.StreamWriter(results);
            string[] s = new string[predictions.Length];
            int j = 1;
            for (int i = 0; i < predictions.Length; i++)
            {
                if (predictions[i] == 0)
                {
                    start = i * (step);
                    counter = start;
                    end = (i * win) + step;
                    string line  = "result-instance" + j + " from timings " + start + "s to " + end + "s";
                    file.WriteLine(line);
                    j++;
                }
            }
            file.Close();
        }

        private void TrainingFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void TestFileForTrain_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Wave Sound|*.wav";
            openFileDialog2.ShowDialog();
        }

        private void Classifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (Classifiers.SelectedItem as Model.Comboitems).cls;
        }

        private string appPath()
        {
            return (AppDomain.CurrentDomain.BaseDirectory).ToString();
        }

        //evet handler function when user clicks "GetResults" in training interface
        private async void TrainGetResults_Click(object sender, EventArgs e)
        {
            TrainingFolder.Enabled = false;
            TestFileForTrain.Enabled = false;
            TrainGetResults.Enabled = false;
            string filename = openFileDialog2.FileName;

            TrainResults.Items.Clear();
            
            if (filename == null)
            {
                MessageBox.Show("No test file selected!");
                return;
            }
            string path = folderBrowserDialog1.SelectedPath;
            if (path == null)
            {
                MessageBox.Show("Training folder not selected!");
                return;
            }

            DirectoryInfo dir = Directory.GetParent(path);

            //check the sound type selected
            int value = (SoundTypeTrain.SelectedItem as Model.CheckBoxItem).Id;

            //set win step based on sound type
            setParameters(value);

            textBox2.Text = "Extracting training files features ...\r\n";
            await Task.Run(() =>audiolab.deep_learning_train(path, numf));
            string[] files = Directory.GetFiles(path);

            //Move files from training folder to genfiles folder
            foreach (string f in files)
            {
                string targetFile = Path.Combine(target, Path.GetFileName(f));
                if (File.Exists(targetFile)) File.Delete(targetFile);
                File.Move(f, targetFile);
            }
            //extract test file features
            textBox2.Text += "Extracting test files features ...\r\n";
            await Task.Run(() =>audiolab.deep_learning_test(target, filename, numf, win, step));

            textBox2.Text += "Creating ARFF files ...\r\n";
            await Task.Run(() =>util.createWekafiles(target, "train", value));
           await Task.Run(() =>util.createWekafiles(target, "test", value));

            textBox2.Text += "ARFF files generated in genfiles folder\r\n";

            //classify and provide results if classifier is selected
            if (selected != null)
            {
                predictions = await Task.Run(() =>util.wekatrainandclassify(selected, target));
                textBox2.Text += "Done!";

                player = player2;
                player.settings.autoStart = false;
                player.URL = openFileDialog2.FileName;
                displayresults(TrainResults);


                TrainingFolder.Enabled = true;
                TestFileForTrain.Enabled = true;
                TrainGetResults.Enabled = true;
            }
            else
            {
                MessageBox.Show("Select classifiers to view results");
            }

            string file2 = "model" + count.ToString();
            count++;
            GenModels.Items.Add(new Model.modelitems { Name = file2, cls = selected });
        }

        //Function to set parameters based on sound type selected
        private void setParameters(int value)
        {

            string genPath = appPath();

            if (value == 1)
            {
                target = genPath + "Training\\H-genfiles";
                win = Settings1.Default.winH;
                step = Settings1.Default.stepH;
                numf = Settings1.Default.numfH;
            }
            else if (value == 2)
            {
                target = genPath + "Training\\Oki-genfiles";
                win = Settings1.Default.winOki;
                step = Settings1.Default.stepOki;
                numf = Settings1.Default.numfOki;
            }
            else
            {
                MessageBox.Show("No sound type selected!");
                return;
            }
        }

        //Event handler for user click of "Savemodel" button
        private void SaveModel_Click(object sender, EventArgs e)
        {
            if (GenModels.SelectedItem == null)
                MessageBox.Show("No model selected!");
            selected = (GenModels.SelectedItem as Model.modelitems).cls;
            if (selected != null)
                weka.core.SerializationHelper.write(target + "\\h.model", selected);
            textBox2.Text = "Model Saved";
            GenModels.Items.Clear();
        }

        private void ClearModelList_Click(object sender, EventArgs e)
        {
            GenModels.Items.Clear();
        }


        //Timer functions below
        private void tmrWmpPlayerPosition_Tick(object sender, EventArgs e)
        {
            counter += 0.1;
            if (counter >= end)
            {
                player.Ctlcontrols.pause();
                StopWmpPlayerTimer();
            }
        }

        private void StartWmpPlayerTimer(int interval)
        {
            tmrWmpPlayerPosition = new System.Timers.Timer();
            tmrWmpPlayerPosition.Elapsed += new System.Timers.ElapsedEventHandler(tmrWmpPlayerPosition_Tick);
            tmrWmpPlayerPosition.Enabled = true;
            tmrWmpPlayerPosition.Interval = interval;
            tmrWmpPlayerPosition.Start();
        }

        private void StopWmpPlayerTimer()
        {
            if (tmrWmpPlayerPosition != null)
                tmrWmpPlayerPosition.Dispose();
            tmrWmpPlayerPosition = null;
        }

    }
}
