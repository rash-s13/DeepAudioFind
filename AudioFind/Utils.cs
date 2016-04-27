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

namespace AudioFind
{
    class Utils
    {
        //Function used to call Python script to generate ARFF format feature files
        public void createWekafiles(string path, string option,int value)
        {
            string genPath = (AppDomain.CurrentDomain.BaseDirectory).ToString();

            // python app to call 
            string myPythonApp = genPath+"main.py";

            // Create new process start info 
            string command = "Python " + myPythonApp + " " + path + " " + option + " " + value;
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd", "/c " + command);

            // Do not create the black window.
            myProcessStartInfo.CreateNoWindow = true;

            //make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            // myProcessStartInfo.Arguments = path + option;   
            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;
            // start the process 
            myProcess.Start();
            // Read the standard output of the app we called.  
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadToEnd();
            // wait exit signal from the app we called and then close it. 
            myProcess.WaitForExit();
            myProcess.Close();
        }

        public double[] wekaclassify(string path)
        {
            double[] predictions;
            weka.core.Instances test = new weka.core.Instances(new java.io.FileReader(path + "\\test.arff"));
            test.setClassIndex(test.numAttributes() - 1);
            string[] model = System.IO.Directory.GetFiles(path, "*.model");
            weka.classifiers.Classifier cls = (weka.classifiers.Classifier)weka.core.SerializationHelper.read(model[0]);
            weka.classifiers.Evaluation eval = new weka.classifiers.Evaluation(test);
            predictions = eval.evaluateModel(cls, test);
            return predictions;
        }

        public double[] wekatrainandclassify(Classifier selected,string path)
        {
            double[] predictions;
            Classifier cls = new weka.classifiers.meta.MultiBoostAB();
            weka.core.Instances train = new weka.core.Instances(new java.io.FileReader(path+"\\training.arff"));
            train.setClassIndex(train.numAttributes() - 1);

            weka.core.Instances test = new weka.core.Instances(new java.io.FileReader(path+"\\test.arff"));
            test.setClassIndex(test.numAttributes() - 1);

            weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
            myRandom.setInputFormat(train);
            train = weka.filters.Filter.useFilter(train, myRandom);
           

            if ((selected.getClass()).equals(cls.getClass()))
            {
                String[] options = weka.core.Utils.splitOptions("-C 3 -P 100 -S 1 -I 10 -W weka.classifiers.trees.J48 -- -C 0.25 -M 2");
                selected.setOptions(options);
            }

            selected.buildClassifier(train);
            weka.classifiers.Evaluation eval = new weka.classifiers.Evaluation(test);
            predictions = eval.evaluateModel(selected, test);
            return predictions;
        }
    }
}
