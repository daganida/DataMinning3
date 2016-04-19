using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ID3Project;
using System.Data;

namespace ID3Classifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string directoryPath;
        ID3Project.ID3Classifier id3;
        public MainWindow()
        {
            InitializeComponent();
            image1.Source = new BitmapImage(new Uri(@"\\Mac\Home\Desktop\DataMining3\images\gini1.jpg"));

   
            
            
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }


        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
             directoryPath = dialog.SelectedPath;
             txtPath.Text = directoryPath;
            

        }



        private void Build_Click(object sender, RoutedEventArgs e)
        {
            id3 = new ID3Project.ID3Classifier(directoryPath);
            id3.setAttributesFromStructureFile();
            id3.insertDataIntoTable("train.txt");
            id3.insertDataIntoTable("test.txt");

    

        }

        private void Classify_Click(object sender, RoutedEventArgs e)
        {

        }   
    }
}
