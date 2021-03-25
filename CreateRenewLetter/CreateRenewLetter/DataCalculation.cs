using System;

namespace CreateRenewLetter
{
    /*
     * Great stuff.
     *
     * Nice to see the use of a decimal for monetary precision and how you have chosen
     * to split out the functionality into it's own class and methods.
     */
    class DataCalculation
    {
        private decimal annualPremium;

        private decimal creditCharge;

        private decimal totalPremium;

        private decimal avrgMonthPremium;

        private decimal initMonthPayment;

        private decimal otherMonthPayments;

        public DataCalculation(decimal annualPremium)
        {
            this.annualPremium = annualPremium;

            /*
             * 99.9% .NET shops will be using PascalCase for method names
             *
             * A good page to check out is:
             *
             * https://blog.submain.com/coding-standards-c-developers-need/
             *
             * and of course
             *
             * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions
             */

            calculateCreditCharge();
            calculateTotalPremium();
            calculateMonthlyPayments();
        }

        /// <summary>
        /// Returns decimal value creditCharge
        /// </summary>
        /// <returns>creditCharge</returns>
        public decimal getCreditCharge()
        {
            return creditCharge;
        }

        /// <summary>
        /// Returns decimal value totalPremium
        /// </summary>
        /// <returns>totalPremium</returns>
        public decimal getTotalPremium()
        {
            return totalPremium;
        }

        /// <summary>
        /// Returns decimal value initMonthPayment
        /// </summary>
        /// <returns>initMonthPayment</returns>
        public decimal getInitMonthPayment()
        {
            return initMonthPayment;
        }

        /// <summary>
        /// Returns decimal value otherMonthPayments
        /// </summary>
        /// <returns>otherMonthPayments</returns>
        public decimal getOtherMonthPayments()
        {
            return otherMonthPayments;
        }

        /// <summary>
        /// Calculates creditCharge and rounds up value to two decimal places
        /// </summary>
        private void calculateCreditCharge()
        {
            creditCharge = Math.Ceiling((annualPremium * 0.05m) * 100) / 100;
        }

        /// <summary>
        /// Calculate totalPremium
        /// </summary>
        private void calculateTotalPremium()
        {
            totalPremium = annualPremium + creditCharge;
        }

        /// <summary>
        /// Calculates the monthly payments initMonthPayment and otherMonthPayments
        /// </summary>
        private void calculateMonthlyPayments()
        {
            avrgMonthPremium = totalPremium / 12;

            if (avrgMonthPremium % 0.01m == 0)
            {
                initMonthPayment = avrgMonthPremium;
                otherMonthPayments = avrgMonthPremium;
            }
            else
            {
                otherMonthPayments = Math.Round(totalPremium/12,2);
                initMonthPayment = totalPremium - (otherMonthPayments * 11);
                if(otherMonthPayments > initMonthPayment)
                {
                    avrgMonthPremium = initMonthPayment;
                    initMonthPayment = otherMonthPayments;
                    otherMonthPayments = avrgMonthPremium;
                }
            }
        }
    }
}
