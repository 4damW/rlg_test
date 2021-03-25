using System;
using System.Collections.Generic;

namespace CreateRenewLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CsvData dataList = new CsvData();

            int records = dataList.recordCount();

            /*
             * Most declarations will allow the use of the var keyword when it's possible
             * for the type of the variable to be inferred, for example:
             *
             * var test = "string"; // it's definately a string!
             * var money = 15m; // etc.
             *
             * Not only does this save you some keystrokes, it can also make future refactoring
             * less painful as you only need to adjust the initialiser.
             *
             * Before
             * DataCalculation[] calculate = new DataCalculation[records];
             * List<DataCalculation> calculate = new List<DataCalculation>(records);
             *
             * After
             * var calculate = new DataCalculation[records];
             * var calculate = new List<DataCalculation>(records);
             */

            GetData[] data = new GetData[records];
            DataCalculation[] calculate = new DataCalculation[records];

            CreateTextFile[] text = new CreateTextFile[records];

            for (int index = 0; index < records; index++)
            {
                data[index] = new GetData(dataList.getCsvRecord(index));
                calculate[index] = new DataCalculation(data[index].getAnnualPremium());

                text[index] = new CreateTextFile(@"c:\temp", data[index], calculate[index]);
            }

            Console.Write("\nProgram has finnished. Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
