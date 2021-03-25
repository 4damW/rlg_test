using System;
using System.IO;

namespace CreateRenewLetter
{
    class CreateTextFile
    {
        private GetData data;

        private DataCalculation calculate;

        private string text;

        private string filename;

        public CreateTextFile(string outputDirectory, GetData data, DataCalculation calculate)
        {
            this.data = data;
            this.calculate = calculate;
            createText();
            createFile(outputDirectory);
        }

        /// <summary>
        /// Creates the text that will be written to a text file
        /// </summary>
        private void createText()
        {
            /*
             * Tip: The Environment class provides a static string property called NewLine which can be used as opposed to \n
             * The main advantage to this is cross platform support, so if you created a .NET Core application and ran it on
             * a UNIX environment you would receive the correct newline structure, i.e. \n for unix, or \r\n for windows.
             *
             * This is also how Console.WriteLine or StringBuilder.AppendLine ensures it correctly breaks lines regardless
             * of the platform it's running on.
             *
             * https://stackoverflow.com/questions/1015766/difference-between-n-and-environment-newline
             *
             * Caveat - if the file was to be opened on a platform different to where the code was running
             * then you'd need to have an alternative definition for the appropriate newline character sequence.
             */
            text = DateTime.Now.Date.ToShortDateString()
                 + Environment.NewLine + "FAO: " + data.Title + " " + data.getFirstName() + " " + data.getSurname()
                 + Environment.NewLine + "RE: Your Renewal"
                 + Environment.NewLine + "Dear " + data.Title + " " + data.getSurname()
                 + Environment.NewLine + "We hereby invite you to renew your Insurance Policy, subject to the following terms."
                 + Environment.NewLine + "Your chosen insurance product is " + data.getProductName() + "."
                 + Environment.NewLine + "The amount payable to you in the event of a valid claim will be £" + data.getPayoutAmount().ToString("0.00") + "."
                 + Environment.NewLine + "Your annual premium will be £" + data.getAnnualPremium().ToString("0.00") + "."
                 + Environment.NewLine + "If you choose to pay by Direct Debit, we will add a credit charge of £" + calculate.getCreditCharge().ToString("0.00") + ", bringing the total to £" + calculate.getTotalPremium().ToString("0.00") + ". This is payable by an initial payment of £" + calculate.getInitMonthPayment().ToString("0.00") + ", followed by 11 payments of £" + calculate.getOtherMonthPayments().ToString("0.00") + "."
                 + Environment.NewLine + "Please get in touch with us to arrange your renewal by visiting https://www.regallutoncodingtest.co.uk/renew or calling us on 01625 123456."
                 + Environment.NewLine + "Kind Regards"
                 + Environment.NewLine + "Regal Luton";
        }

        /// <summary>
        /// Creates text files and writes text to them
        /// </summary>
        private void createFile(string outputDirectory)
        {
            var filename = Path.Combine(outputDirectory, data.getId() + "_" + data.getFirstName() + "_" + data.getSurname() + ".txt");

            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, text);
                Console.WriteLine("File: \"" + filename + "\" has been created.");
            }
            else
            {
                Console.WriteLine("File: \"" + filename + "\" already exists.");
            }
        }
    }
}
