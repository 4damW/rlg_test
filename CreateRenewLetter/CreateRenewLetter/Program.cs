using System;

namespace CreateRenewLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvData dataList = new CsvData();

            int records = dataList.recordCount();

            GetData[] data = new GetData[records];
            DataCalculation[] calculate = new DataCalculation[records];
            CreateTextFile[] text = new CreateTextFile[records];

            for (int index = 0; index < records; index++)
            {
                data[index] = new GetData(dataList.getCsvRecord(index));
                calculate[index] = new DataCalculation(data[index].getAnnualPremium());
                text[index] = new CreateTextFile(data[index], calculate[index]);
            }

            Console.Write("\nProgram has finnished. Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
