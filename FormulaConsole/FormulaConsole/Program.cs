using System;

namespace FormulaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMonthlyLoanPayment(25000, 2, 3));
            Console.ReadLine();
        } 

        //static double CalRaised()
        //{
        //    double result = 1;

        //for(int i = 0; i < 24; i++)
        //    {
        //        result = result * 1.0025;
        //    }
        //    return result;
        //}

        static double GetNumerator(int n, double r)
        {
            double NumResult = 1;

            r = r + 1;

            for (int i = 0; i < n; i++)
            {
                NumResult = NumResult * r;
            }

            NumResult = NumResult - 1;

            return NumResult;
        }

        static double GetDenominator(double n, double r)
        {
            double DenResult = 1;
            double rcontainer = r;

            r = 1 + r;

            for (int i = 0; i < n; i++)
            {
                DenResult = DenResult * r;
            }

            DenResult = rcontainer * DenResult;

                return DenResult;
        }

        static double GetDiscountFactor(double NumResult, double DenResult)
        {
            Double DiscountFactor = 0;

            DiscountFactor = NumResult / DenResult;


            return DiscountFactor;
        }

        static int GetTermInYears(int term)
        {
            int TermInYears = 0;

            TermInYears = term * 12;

            return TermInYears;
        }

        static double GetRate(double rate)
        {
            double rateInPercent = 0;
            double r = 0;

            rateInPercent = rate / 100;
            r = rateInPercent / 12;

            return r;
        }


        static double GetMonthlyLoanPayment(double loanamnt, int term, double rate)
        {
            double monthlyLoanPayment = 0;
            rate = GetRate(rate); //0.0025
            term = GetTermInYears(term); //24

            double numResult = 0;
            numResult = GetNumerator(term, rate);
            double denResult = 0;
            denResult = GetDenominator(term, rate);
            double d = 0;
            d = GetDiscountFactor(numResult, denResult);

            monthlyLoanPayment = loanamnt / d;

            return monthlyLoanPayment;
        }

    }
}
