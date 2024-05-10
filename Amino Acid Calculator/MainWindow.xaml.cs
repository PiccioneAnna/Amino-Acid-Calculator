using Amino_Acid_Calculator.source;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Amino_Acid_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string baseFolderPath = "";
        public string inputFilePath = "";
        public string outputFolderPath = "";

        public CalculationManager calculationManager;

        public MainWindow()
        {
            InitializeComponent();
            calculationManager = new CalculationManager();
        }

        private void RunCalculator(object sender, RoutedEventArgs e)
        {
            calculationManager.DefineFilePaths(baseFolderPath, inputFilePath, outputFolderPath);
            calculationManager.Run(logText);
        }

        private void SelectBaseFileLocation(object sender,  RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                baseFolderPath = dialog.FileName;
                basetxt.Text = baseFolderPath;
            }
        }

        private void SelectInputFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                inputFilePath = fileDialog.FileName;
                inputtxt.Text = inputFilePath;
            }
        }

        private void SelectOutputLocation(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputFolderPath = dialog.FileName;
                outputtxt.Text = outputFolderPath;
            }
        }
    }
}
