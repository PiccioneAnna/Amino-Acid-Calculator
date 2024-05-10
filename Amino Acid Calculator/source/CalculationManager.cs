using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Amino_Acid_Calculator.source.CustomDataStructures;

namespace Amino_Acid_Calculator.source
{
    public class CalculationManager
    {
        #region Fields

        // File paths given by user input
        public string baseFolderPath = "";
        public string inputFilePath = "";
        public string outputFolderPath = "";

        public string? outputsfn;

        public string aaBasefn = "baseAAValues.csv";
        public string baseIDsfn = "baseIDs.csv";

        public TextBlock logtext;

        // Actual data structs
        public List<BaseMealInfo> baseMealInfoList = new(); 
        public List<BaseAAStruct> baseAAStructs = new();
        public List<InputDataStruct> inputDataStructs = new();
        public List<OutputDataStruct> outputDataStructs = new();

        public int ffqCutoff = 130;
        public List<string>? AA_Names;
        public List<string>? ffq_IDs;

        #endregion

        public void Run(TextBlock textLog)
        {
            logtext = textLog;

            logtext.Text += " Starting calculator...";

            GrabBaseValues();

        }

        #region Data Population

        public void GrabBaseValues()
        {
            logtext.Text += "\n Grabbing base meal information...";
            baseMealInfoList = FileReader.ReadBaseIds(baseFolderPath + "//" + baseIDsfn);
            logtext.Text += "\n Base meal info collected successfully.";
            logtext.Text += "\n " + baseMealInfoList.Count + " meal info rows found.";

            logtext.Text += "\n Grabbing base AA Database values...";
            AA_Names = FileReader.PopulateAminoAcidNames(baseFolderPath + "//" + aaBasefn);
            logtext.Text += "\n " + AA_Names.Count + " amino acids defined.";
            baseAAStructs = FileReader.ReadBaseAAValues(baseFolderPath + "//" + aaBasefn, AA_Names);
            logtext.Text += "\n Base AA Database values collected successfully.";
            logtext.Text += "\n " + baseAAStructs.Count + " foods coded with base aa values.";

            logtext.Text += "\n Grabbing provided input values...";
            inputDataStructs = FileReader.ReadInputFile(inputFilePath, ffqCutoff);
            logtext.Text += "\n Input values collected successfully.";
            logtext.Text += "\n " + inputDataStructs.Count + " ffq collected.";

        }

        public void MapInputValues()
        {

        }

        #endregion

        #region Math

        public void CalculateTotal()
        {

        }

        #endregion

        #region Helpers
        public void DefineFilePaths(string baseF, string inputF, string outputF)
        {
            baseFolderPath = baseF;
            inputFilePath = inputF;
            outputFolderPath = outputF;
        }
        #endregion

    }
}
