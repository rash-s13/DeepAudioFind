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

namespace WindowsFormsApplication3
{
    class Class1
    {
        public void createWekafiles(string path, string option,int value)
        {
            // full path of python interpreter 
            string python = @"C:\Python34\python.exe";

            // python app to call 
            string myPythonApp = "C:\\Users\\Rashmi\\SkyDrive\\Capstone-Final\\WindowsFormsApplication1\\WindowsFormsApplication1\\bin\\Debug\\main.py";

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
            myProcessStartInfo.Arguments = myPythonApp + " " + path + " " + option + " " + value;
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
            weka.core.Instances test = new weka.core.Instances(new java.io.FileReader(path+"\\test.arff"));
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
            weka.core.Instances train = new weka.core.Instances(new java.io.FileReader(path+"\\training.arff"));
            train.setClassIndex(train.numAttributes() - 1);

            weka.core.Instances test = new weka.core.Instances(new java.io.FileReader(path+"\\test.arff"));
            test.setClassIndex(test.numAttributes() - 1);

            weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
            myRandom.setInputFormat(train);
            train = weka.filters.Filter.useFilter(train, myRandom);

            selected.buildClassifier(train);
            weka.classifiers.Evaluation eval = new weka.classifiers.Evaluation(test);
            predictions = eval.evaluateModel(selected, test);
            return predictions;
        }
    }
}
