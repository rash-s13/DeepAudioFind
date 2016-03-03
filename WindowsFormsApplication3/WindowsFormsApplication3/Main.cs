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

namespace WindowsFormsApplication3
{
    public partial class Main : Form
    {
        private double[] predictions;
        private System.Timers.Timer tmrWmpPlayerPosition;
        double start, end;
        double counter = 0;
        AxWMPLib.AxWindowsMediaPlayer player = null;
        AxWMPLib.AxWindowsMediaPlayer player1 = null;
        AxWMPLib.AxWindowsMediaPlayer player2 = null;
        public DeepMat.DeepMat audiolab = new DeepMat.DeepMat();
        Classifier selected = null;
        double win, step;
        Class1 util = new Class1();
        string target = null;

        public class CheckBoxItem
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public override String ToString()
            {
                return Name;
            }
        }

        public class Comboitems
        {
            public string Name { get; set; }
            public Classifier cls { get; set; }

            public override String ToString()
            {
                return Name;
            }
        }

        public Main()
        {
            InitializeComponent();
            listBox1.DoubleClick += new EventHandler(listBox1_DoubleClick);
            listBox2.DoubleClick += new EventHandler(listBox2_DoubleClick);

            List<Comboitems> comboList = new List<Comboitems>();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "cls";

            comboList.Add(new Comboitems { Name = "Select Classifier...", cls = null });
            comboList.Add(new Comboitems { Name = "RandomTree", cls = new weka.classifiers.trees.RandomTree() });
            comboList.Add(new Comboitems { Name = "DecisionTable", cls = new weka.classifiers.trees.RandomForest() });
            comboList.Add(new Comboitems { Name = "MultiBoostwithJ48", cls = new weka.classifiers.meta.MultiBoostAB() });
            comboList.Add(new Comboitems { Name = "MultiBoostwithJ48", cls = new weka.classifiers.meta.MultiBoostAB() });
            comboList.Add(new Comboitems { Name = "NaivesBayesupdateable", cls = new weka.classifiers.bayes.NaiveBayesUpdateable() });
            comboList.Add(new Comboitems { Name = "Bagging", cls = new weka.classifiers.meta.Bagging() });
            comboList.Add(new Comboitems { Name = "Ibk", cls = new weka.classifiers.lazy.IBk() });

            comboBox2.DataSource = comboList;

            List<CheckBoxItem> soundList = new List<CheckBoxItem>();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";

            soundList.Add(new CheckBoxItem { Name = "Select Sound type...", Id = 0 });
            soundList.Add(new CheckBoxItem { Name = "H-sound", Id = 1 });
            soundList.Add(new CheckBoxItem { Name = "Oki", Id = 2 });
            comboBox1.DataSource = soundList;
            comboBox3.DataSource = soundList;
            this.player1 = axWindowsMediaPlayer1;
            this.player2 = axWindowsMediaPlayer2;
        }


        private void displayresults(ListBox list)
        {
            player.settings.autoStart = false;
            player.URL = openFileDialog1.FileName;
            int j = 0;
            List<CheckBoxItem> checkboxItemList = new List<CheckBoxItem>();
            list.DisplayMember = "Name";
            list.ValueMember = "Id";
            string[] s = new string[predictions.Length];
            for (int i = 0; i < predictions.Length; i++)
            {
                if (predictions[i] == 0)
                {
                    var checkboxItem = new CheckBoxItem
                    {
                        Id = i,
                        Name = "samples" + j
                    };
                    checkboxItemList.Add(checkboxItem);
                    j++;
                }
            }
            list.DataSource = checkboxItemList;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int value = (listBox1.SelectedItem as CheckBoxItem).Id;
            player = player1;
            playsample(value);
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            int value = (listBox2.SelectedItem as CheckBoxItem).Id;
            player = player2;
            playsample(value);
        }

        private void playsample(int value)
        {
            start = value * (step);
            counter = start;
            end = (value * win) + step;
            textBox1.Text = "Position of result sample : " + start + "s to " + end + "s";
            player.Ctlcontrols.currentPosition = start;
            player.Ctlcontrols.play();
            StopWmpPlayerTimer();
            StartWmpPlayerTimer(100);
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


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Wave Sound|*.wav";
            openFileDialog1.ShowDialog();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string filename = openFileDialog1.FileName;
            string path = null;
            int value = (comboBox1.SelectedItem as CheckBoxItem).Id;

            if (value == 1)
            {
                path = "C:\\Users\\Rashmi\\SkyDrive\\Capstone-Final\\WindowsFormsApplication1\\WindowsFormsApplication1\\Training\\H-genfiles";
                win = 0.250;
                step = 0.250;
            }
            else if (value == 2)
            {
                path = "C:\\Users\\Rashmi\\SkyDrive\\Capstone-Final\\WindowsFormsApplication1\\WindowsFormsApplication1\\Training\\Oki-genfiles";
                win = 0.600;
                step = 0.600;
            }


            textBox1.Text = "Fetching Results ...";

            await Task.Run(() => audiolab.deep_learning_test(path, filename, 10, win, step));


            await Task.Run(() => util.createWekafiles(path, "test", value));
            predictions = await Task.Run(() => util.wekaclassify(path));
            player = player1;
            displayresults(listBox1);
            textBox1.Text = "Done!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Wave Sound|*.wav";
            openFileDialog2.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (comboBox2.SelectedItem as Comboitems).cls;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string filename = openFileDialog2.FileName;
            string path = folderBrowserDialog1.SelectedPath;

            int value = (comboBox2.SelectedItem as CheckBoxItem).Id;

            if (value == 1)
            {
                target = "C:\\Users\\Rashmi\\SkyDrive\\Capstone-Final\\WindowsFormsApplication1\\WindowsFormsApplication1\\Training\\H-genfiles";
                win = 0.250;
                step = 0.250;
            }
            else if (value == 2)
            {
                target = "C:\\Users\\Rashmi\\SkyDrive\\Capstone-Final\\WindowsFormsApplication1\\WindowsFormsApplication1\\Training\\Oki-genfiles";
                win = 0.600;
                step = 0.600;
            }

            textBox2.Text = "Fetching results ...";
            await Task.Run(() =>audiolab.deep_learning_train(path, 10));
            string[] files = Directory.GetFiles(path);

            foreach (string f in files)
            {
                string targetFile = Path.Combine(target, Path.GetFileName(f));
                if (File.Exists(targetFile)) File.Delete(targetFile);
                File.Move(f, targetFile);
            }

            await Task.Run(() =>audiolab.deep_learning_test(target, filename, 10, win, step));
            await Task.Run(() =>util.createWekafiles(target, "train", value));
            await Task.Run(() =>util.createWekafiles(target, "test", value));
            textBox2.Text = "ARFF files generated in genfiles folder";
            if (selected != null)
            {
                predictions = await Task.Run(() =>util.wekatrainandclassify(selected, target));
                textBox2.Text = "Done!";
                player = player2;
                displayresults(listBox2);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selected != null)
                weka.core.SerializationHelper.write(target + "h.model", selected);
        }
    }
}
