using System;
using System.Collections.Generic;

namespace Amino_Acid_Calculator.source
{
    /// <summary>
    /// A collection of custom data structures made from csv templates
    /// </summary>
    internal class CustomDataStructures
    {
        public int ffqCutoff = 130;
        public List<string>? AA_Names;
        public List<string>? ffq_IDs;

        /// <summary>
        /// Dictionary containing the base conversion rate for each ffq value, taken from FETA program
        /// </summary>
        public static Dictionary<int, Double> baseFrequencies = new()
        {
            {1, 0},
            {2, 0.07},
            {3, 0.14},
            {4, 0.43},
            {5, 0.79},
            {6, 1},
            {7, 2.5},
            {8, 4.5},
            {9, 6},
        };

        /// <summary>
        /// Structure containing all of the original meal information within baseAAValue database
        ///  *LINE 0 NOT INCLUDED : DNI MILK
        /// </summary>
        public struct BaseMealId
        {
            public int mealID;
            public string mealName;
            public int mealIndex; // in reference to the UK/US baseAA Value Database
        }

        /// <summary>
        /// Structure containing base values of each ffq food for 18 AA defined below
        /// </summary>
        public struct BaseAAStruct
        {
            public int mealIndex;
            public string foodName;
            public List<int> aaValues;
        }

        /// <summary>
        /// Struct containing a mapping format for ffq input files
        /// By each line
        /// </summary>
        public struct InputDataStruct
        {
            public string ffqID;
            public Dictionary<int, int> answers; // x = question number, y = answer
        }

        /// For above data: all same named variables within custom structs should equal same number

        /// <summary>
        /// Struct containing a mapping format for ffq output files
        /// </summary>
        public struct OutputDataStruct
        {
            public string ffq_ID;
            public Dictionary<string, int> totalAA; //string = aa int = total amount
        }

    }
}
