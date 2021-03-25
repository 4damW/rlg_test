using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace CreateRenewLetter
{
    class CsvData
    {
        /*
         * This value could be passed into the constructor
         * to allow some flexibility on the source file.
         */
        private string filename = "Customer.csv";

        private List<List<string>> csvData;

        /*
         * I like this - you have a fixed file spec that you expect
         * and storing it up here it keeps it nice and readable and maintainable.
         */

        private readonly string[] headings = { "ID", "TITLE", "FIRSTNAME", "SURNAME", "PRODUCTNAME", "PAYOUTAMOUNT", "ANNUALPREMIUM" };
        private readonly string[] titles = { "MISS", "MR", "MRS" };

        public CsvData()
        {
            readCsvFile();
        }

        /// <summary>
        /// Returns the number of valid records in the input file
        /// </summary>
        /// <returns></returns>
        public int recordCount()
        {
            return csvData.Count();
        }

        /// <summary>
        /// Returns a valid record from the input file
        /// </summary>
        /// <param name="record"></param>
        /// <returns>csvData[record]</returns>
        public List<string> getCsvRecord(int record)
        {
            return csvData[record]; 
        }

        /// <summary>
        /// Reads the csv input file and stores valid data to a 2D list
        /// </summary>
        private void readCsvFile()
        {
            /*
             * Considering inverting some logic to avoid pyramid of doom, i.e.
             * if (file doesn't exist) return
             * if (file length is zero) return
             */

            if (File.Exists(filename))
            {
                if (new FileInfo(filename).Length != 0)
                {

                    /*
                     * Check out the File.ReadAllLines() method
                     * which does some of this work for you
                     */

                    var reader = new StreamReader(File.OpenRead(filename));

                    csvData = new List<List<string>>();

                    List<string> line = new List<string>(reader.ReadLine().Split(','));
                    csvData.Add(line);
                    validateHeadings();

                    while (!reader.EndOfStream)
                    {
                        line = new List<string>(reader.ReadLine().Split(','));
                        if (validateData(line))
                        {
                            csvData.Add(line);
                        }
                        else
                        {
                            Console.WriteLine("Invalid data found in input file.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File: \"" + filename + "\" is empty.");
                }
            }
            else
            {
                Console.WriteLine("File: \"" + filename + "\" not found.");
                csvData = new List<List<string>>();
            }
        }

        /// <summary>
        /// Validates the headings from an input file
        /// </summary>
        private void validateHeadings()
        {
            /*
             * Few points about this method
             *
             * a) It's doing a lot, and for me at least, takes a few passes to understand what it is doing.
             * b) The method name could be refined to better reflect that it in addition
             *    to validating the headings, it is also removing the row.
             *
             * I know the coding challenge is a bit wooly and doesn't specify whether a missing header
             * should result in not processing the file, but, if we were to assume it would then this
             * method could be simplified to compare both string[]'s and throwing if they don't match.
             *
             * For example:
             */

            if (!csvData[0].SequenceEqual(this.headings, StringComparer.OrdinalIgnoreCase))
            {
                throw new ApplicationException("Expected CSV header row not found.");
            }
            csvData.RemoveAt(0);

            /*
            int headingCount = 7;
            bool headingsExsit = true;

            for (int field = 0; field < csvData[0].Count(); field++)
            {
                headingCount--;
                try
                {
                    if (csvData[0][field].ToUpper() != headings[field])
                    {
                        Console.WriteLine("Field Heading: \"" + headings[field] + "\" does not exist.");
                        headingsExsit = false;
                    }
                }
                catch (IndexOutOfRangeException error)
                {
                    Console.WriteLine("Extra data found in input file. " + error.Message);
                }
            }

            if (headingsExsit & headingCount == 0)
            {
                csvData.RemoveAt(0);
            }
            else if (!headingsExsit & !validateData(csvData[0]))
            {
                csvData.RemoveAt(0);
            }
            */
        }

        /// <summary>
        /// Validates the data types of some parameters and returns a bool value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>validData</returns>
        private bool validateData(List<string> data)
        {
            /*
             *
             */

            int test;
            decimal testDec;

            bool validData = true;
            if (!int.TryParse(data[0], out test)) // Checking that the ID is an integer
            {
                validData = false;
            }
            else if (!titles.Contains(data[1].ToUpper())) // Checking that the title is a valid title
            {
                validData = false;
            }
            else if (int.TryParse(data[2], out test)) // Checking that the firstName is a string
            {
                validData = false;
            }
            else if (int.TryParse(data[3], out test)) // Checking that the surname is a string
            {
                validData = false;
            }
            else if (int.TryParse(data[4], out test)) // Checking that the productName is a string
            {
                validData = false;
            }
            else if (!decimal.TryParse(data[5], out testDec)) // Checking that the payoutAmount is a decimal
            {
                validData = false;
            }
            else if (!decimal.TryParse(data[6], out testDec)) // Checking that the annualPremium is a decimal
            {
                validData = false;
            }

            return validData;
        }
    }
}
