using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Amino_Acid_Calculator.source.CustomDataStructures;

namespace Amino_Acid_Calculator.source
{
    /// <summary>
    ///  Class is in charge of reading each customf ormated csv, inherits from csv helper api
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Method grabs all of the default values from baseids database
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<BaseMealInfo> ReadBaseIds(string file)
        {
            int index = -1;

            List<BaseMealInfo> mealinfo = new();

            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
                csv.Read();
                csv.ReadHeader();
                while(csv.Read())
                {
                    index++;
                    if(index < 1) { continue; }

                    var meal = new BaseMealInfo
                    {
                        mealID = csv.GetField<int>("MEAL_ID/LINE NUMBER"),
                        mealName = csv.GetField("COLUMN NAME"),
                        mealIndex = csv.GetField("FFQ INDEX") != null && int.TryParse(csv.GetField("FFQ INDEX"), out int temp) ? csv.GetField<int>("FFQ INDEX") : -1
                    };

                    mealinfo.Add(meal);
                }         
            }

            return mealinfo;
        }

        /// <summary>
        /// Method maps out all base AA values from the UK/US provided database
        /// </summary>
        /// <param name="file"></param>
        /// <param name="aaNames"></param>
        /// <returns></returns>
        public static List<BaseAAStruct> ReadBaseAAValues(string file, List<string> aaNames)
        {
            List<BaseAAStruct> baseAAStructs = new();
            int index = 1;

            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    index++;

                    var aaRow = new BaseAAStruct
                    {
                        mealIndex = index,
                        foodName = csv.GetField("Food Name"),
                        aaValues = new()
                    };

                    foreach (var name in aaNames)
                    {
                        int value = csv.GetField<int>(name);
                        aaRow.aaValues.Add(value);
                    }

                    baseAAStructs.Add(aaRow);
                }
            }

            return baseAAStructs;
        }
        
        /// <summary>
        /// Method reads through an input file and maps out data as long as its in valid format
        /// </summary>
        /// <param name="file"></param>
        /// <param name="stopIndex"></param>
        /// <returns></returns>
        public static List<InputDataStruct> ReadInputFile(string file, int stopIndex)
        {
            List<string> ffq = new();
            List<InputDataStruct> inputDataStructs = new();

            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                for (int i = 1; i <= stopIndex; i++)
                {
                    string header = csv.GetField(i);
                    ffq.Add(header);
                }

                while (csv.Read())
                {
                    var input = new InputDataStruct
                    {
                        ffqID = csv.GetField("ID"),
                        answers = new()
                    };

                    foreach (var question in ffq)
                    {
                        int value = csv.GetField<int>(question);
                        input.answers.Add(question, value);
                    }

                    inputDataStructs.Add(input);
                }
            }

            return inputDataStructs;
        }

        /// <summary>
        /// Method returns a list of amino acid names from base aa value
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<string> PopulateAminoAcidNames(string file)
        {
            List<string> aa_names = new();

            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                for (int i = 2; i < csv.ColumnCount; i++) // in csv aa names start at column 2
                {
                    bool isHeader = csv.TryGetField<string>(i, out string header_name);
                    if (isHeader) { aa_names.Add(header_name); }
                }
            }

            return aa_names;
        }
    }
}
