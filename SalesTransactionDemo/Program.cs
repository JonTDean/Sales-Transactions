using System;

namespace SalesTransactionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Examples of sales using the three Constructors
            SalesTransactions januarySale = new SalesTransactions("January", 22, 5.5f);
            SalesTransactions februarySale = new SalesTransactions("February", 32);
            SalesTransactions marchSale = new SalesTransactions("March");

            // Examples of using the overloaded + operator, what's
            // really interesting is the implicit extension of multiple
            // operands that allow for growth.
            SalesTransactions janFebMarchSale = januarySale + februarySale + marchSale;

            // Terminal Logging
            saleReceipt(januarySale);
            saleReceipt(februarySale);
            saleReceipt(marchSale);
            salesReceiptTotal(janFebMarchSale);
            exitProgram();
        }

        private static void saleReceipt(SalesTransactions sale)
        {
            Console.WriteLine("Sales Transaction Receipt---");
            Console.WriteLine($"Name of the Transaction is: {sale.Name}");
            Console.WriteLine($"Sales Amount of the Transaction is: {sale.SalesAmount}");
            Console.WriteLine($"Commission Rate of the Transaction is: {sale.CommissionRate}");
            Console.WriteLine("End of Sales Receipt");
            exitProgram();
        }

        private static void salesReceiptTotal(SalesTransactions saleTotal)
        {
            Console.WriteLine("Sales Receipt Total---");
            Console.WriteLine($"saleTotal is equal to: {saleTotal.SalesAmount}");
            Console.WriteLine("Sales Receipt Total End");
            exitProgram();
        }

        private static void exitProgram()
        {

            Console.WriteLine("Press any Button to exit");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public class SalesTransactions
    {

        public string Name { get; private set; }
        public double Commission { get; private set; }
        public readonly float CommissionRate;
        double salesAmount;
        public double SalesAmount
        {
            get => salesAmount;
            private set
            {
                salesAmount = value;
                Commission = SalesAmount * CommissionRate;
            }
        }


        //  One constructor accepts values for the name, sales amount,
        //  and rate, and when the sales value is set, the constructor
        //  computes the commission as sales value times commission rate.
        public SalesTransactions(string Name, double SalesAmount, float CommissionRate)
        {
            this.Name = Name;
            this.SalesAmount = SalesAmount;
            this.CommissionRate = CommissionRate;
        }

        // The second constructor accepts a name and sales amount but sets the commission rate to 0.
        public SalesTransactions(string Name, double SalesAmount)
        {
            this.Name = Name;
            this.SalesAmount = SalesAmount;
            this.CommissionRate = 0;
        }

        // The third constructor accepts a name and sets all the other fields to 0. 
        public SalesTransactions(string Name)
        {
            this.Name = Name;
            this.SalesAmount = 0;
            this.CommissionRate = 0;
        }

        // An overloaded + operator adds the sales values for two SalesTransaction objects.
        public static SalesTransactions operator+(SalesTransactions obj1, SalesTransactions obj2)
        { 
            return new SalesTransactions("Final Sales Amount", obj1.salesAmount + obj1.salesAmount);
        } 
    }
}