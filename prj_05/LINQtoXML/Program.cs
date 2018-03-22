using System;
using System.Linq;

namespace LINQtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLReader reader = new XMLReader($@"{AppDomain.CurrentDomain.BaseDirectory}\..\Customers.xml");
            reader.PutCustomerListToShop();
            //Console.WriteLine(ShopCustomers.AllCustomers.ExtendedToString());
            //1
            double costToCompare = 40000;
            Console.WriteLine(ShopCustomers.WithTotalOrdersCostGreaterThan(costToCompare).ExtendedToString());
            //2
            Console.WriteLine(ShopCustomers.AllCustomers.GroupBy(p => p.Country, p => p.Name,
                (country, name) => new { country, Name = name.ToOneString() }).ExtendedToString());
            var a = ShopCustomers.AllCustomers.GroupBy(p => p.Country, p => p.Name,
                (country, name) => new {country, Name = name.ToOneString()});
            //3
            costToCompare = 12000;
            Console.WriteLine(ShopCustomers.WithAnyOrderCostGreaterThan(costToCompare).ExtendedToString());
            //4
            Console.WriteLine(ShopCustomers.AllCustomers.Select(customer => customer.NameAndDateOfStartService()).ExtendedToString());
            //5
            Console.WriteLine(ShopCustomers.SortByDateOfStartService().Select(customer => customer.NameAndDateOfStartService()).ExtendedToString());
            Console.WriteLine(ShopCustomers.SortByTotalProfit().Select(customer => customer.NameAndDateOfStartService()).ExtendedToString());
            Console.WriteLine(ShopCustomers.SortByName().Select(customer => customer.NameAndDateOfStartService()).ExtendedToString());
            //6
            Console.WriteLine(ShopCustomers.WithIncorrectCodeInPhone().ExtendedToString());
            //7
            string anyCity = "Portland";
            Console.WriteLine(ShopCustomers.AverageProfitOnCity(anyCity));
            Console.WriteLine(ShopCustomers.AverageCountOfOrdersOnCity(anyCity));
            Console.WriteLine(ShopCustomers.AllCustomers.Where(customer => customer.City == anyCity).ExtendedToString());

            //8
            Console.WriteLine(ShopCustomers.StastisticsOnMonth().ExtendedToString());
            Console.WriteLine(ShopCustomers.StastisticsOnYear().ExtendedToString());
            Console.WriteLine(ShopCustomers.StastisticsOnYearAndMonth().ExtendedToString());

            Console.ReadKey();
        }
    }
}
