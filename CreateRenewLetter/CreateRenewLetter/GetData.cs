using System.Collections.Generic;

namespace CreateRenewLetter
{
    class GetData
    {
        private int id;

        /*
         * C# provides an alternative to having get() methods for backing fields - Auto-Implemented Properties  
         * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
         */

        public string Title { get; }

        private string firstName;

        private string surname;

        private string productName;

        private decimal payoutAmount;

        private decimal annualPremium;

        public GetData(List<string> dataRecord)
        {
            this.id = int.Parse(dataRecord[0]);
            this.Title = dataRecord[1];
            this.firstName = dataRecord[2];
            this.surname = dataRecord[3];
            this.productName = dataRecord[4];
            this.payoutAmount = decimal.Parse(dataRecord[5]);
            this.annualPremium = decimal.Parse(dataRecord[6]);
        }

        public int getId()
        {
            return id;
        }

        //public string getTitle()
        //{
        //    return title;
        //}

        public string getFirstName()
        {
            return firstName;
        }

        public string getSurname()
        {
            return surname;
        }

        public string getProductName()
        {
            return productName;
        }

        public decimal getPayoutAmount()
        {
            return payoutAmount;
        }

        public decimal getAnnualPremium()
        {
            return annualPremium;
        }
    }
}
