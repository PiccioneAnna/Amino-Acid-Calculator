using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Amino_Acid_Calculator.source.CustomDataStructures;

namespace Amino_Acid_Calculator.source
{
    public static class FileWriter
    {
        public static void WriteOutputsToFile(string dir, List<OutputDataStruct> outputData, List<String> aaNames)
        {
            var csv = new StringBuilder();

            var header = "ffq_Id";

            foreach (var name in aaNames) 
            {
                header += "," + name;
            }

            csv.AppendLine(header);

            foreach (var line in outputData)
            {
                var row = line.ffqID;

                foreach (var aaValue in line.totalAA)
                {
                    row += "," + aaValue.Value;
                }

                csv.AppendLine(row);
            }

            File.WriteAllText(dir + "/output.csv", csv.ToString());
        }     
    }
}
