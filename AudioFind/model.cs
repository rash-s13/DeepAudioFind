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
	public class Model
	{

        //class for classifier items
         public class Comboitems
        {
            public string Name { get; set; }
            public Classifier cls { get; set; }

            public override String ToString()
            {
                return Name;
            }
        }

        //class for sound types
         public class CheckBoxItem
         {
             public string Name { get; set; }
             public int Id { get; set; }

             public override String ToString()
             {
                 return Name;
             }
         }

        //class for model and results storage
         public class modelitems
         {
             public string Name { get; set; }
             public Classifier cls { get; set; }

             public override String ToString()
             {
                 return Name;
             }
         }

       
         public static List<Comboitems> initializeclassifiers()
         {
             
		    List<Comboitems> comboList = new List<Comboitems>();
            comboList.Add(new Comboitems { Name = "Select Classifier...", cls = null });
            comboList.Add(new Comboitems { Name = "RandomTree", cls = new weka.classifiers.trees.RandomTree() });
            comboList.Add(new Comboitems { Name = "RandomForest", cls = new weka.classifiers.trees.RandomForest() });
            comboList.Add(new Comboitems { Name = "J48", cls = new weka.classifiers.trees.J48() });
            comboList.Add(new Comboitems { Name = "MultiBoostwithJ48", cls = new weka.classifiers.meta.MultiBoostAB() });
            comboList.Add(new Comboitems { Name = "NaivesBayesupdateable", cls = new weka.classifiers.bayes.NaiveBayesUpdateable() });
            comboList.Add(new Comboitems { Name = "Bagging", cls = new weka.classifiers.meta.Bagging() });
            comboList.Add(new Comboitems { Name = "Ibk", cls = new weka.classifiers.lazy.IBk() });
            return comboList;

         }
        public static List<CheckBoxItem> initializeSounds()
         {

             List<CheckBoxItem> soundList = new List<CheckBoxItem>();

             soundList.Add(new CheckBoxItem { Name = "Select Sound type...", Id = 0 });
             soundList.Add(new CheckBoxItem { Name = "H-sound", Id = 1 });
             soundList.Add(new CheckBoxItem { Name = "Oki", Id = 2 });

             return soundList;
         }

           

	}
}
