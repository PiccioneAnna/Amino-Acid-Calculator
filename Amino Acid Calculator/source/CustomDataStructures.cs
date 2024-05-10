using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amino_Acid_Calculator.source
{

    internal class CustomDataStructures
    {

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
        public struct BaseMealIds
        {
            public List<int> mealIDs;
            public List<string> mealNames;
            public List<int> mealIndex; // in reference to the UK/US baseAA Value Database
        }



    }
}
