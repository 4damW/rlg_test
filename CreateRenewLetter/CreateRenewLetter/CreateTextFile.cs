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

        public CreateTextFile(GetData data, DataCalculation calculate)
        {
            this.data = data;
            this.calculate = calculate;
            createText();
            createFile();
        }

        /// <summary>
        /// Creates the text that will be written to a text file
        /// </summary>
        private void createText()
        {
            text = DateTime.Now.Date.ToShortDateString()
                 + "\nFAO: " + data.getTitle() + " " + data.getFirstName() + " " + data.getSurname()
                 + "\nRE: Your Renewal"
                 + "\nDear " + data.getTitle() + " " + data.getSurname()
                 + "\nWe hereby invite you to renew your Insurance Policy, subject to the following terms."
                 + "\nYour chosen insurance product is " + data.getProductName() + "."
                 + "\nThe amount payable to you in the event of a valid claim will be £" + data.getPayoutAmount().ToString("0.00") + "."
                 + "\nYour annual premium will be £" + data.getAnnualPremium().ToString("0.00") + "."
                 + "\nIf you choose to pay by Direct Debit, we will add a credit charge of £" + calculate.getCreditCharge().ToString("0.00") + ", bringing the total to £" + calculate.getTotalPremium().ToString("0.00") + ". This is payable by an initial payment of £" + calculate.getInitMonthPayment().ToString("0.00") + ", followed by 11 payments of £" + calculate.getOtherMonthPayments().ToString("0.00") + "."
                 + "\nPlease get in touch with us to arrange your renewal by visiting https://www.regallutoncodingtest.co.uk/renew or calling us on 01625 123456."
                 + "\nKind Regards"
                 + "\nRegal Luton";
        }

        /// <summary>
        /// Creates text files and writes text to them
        /// </summary>
        private void createFile()
        {
            filename = data.getId() + "_" + data.getFirstName() + "_" + data.getSurname() + ".txt";

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
