using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQtoXML
{
    public static class ShopCustomers
    {
        public static List<Customer> AllCustomers { get; } = new List<Customer>();
        public static void Add(Customer c)
        {
            AllCustomers.Add(c);
        }
        //1
        public static IEnumerable<Customer> WithTotalOrdersCostGreaterThan(double cost)
        {
            return AllCustomers.Where(customer => customer.TotalOrderSum > cost);
        }
        //2
        public static IEnumerable<Customer> GroupByCountry(string country)
        {
            return AllCustomers.Where(customer => customer.Country==country);
        }
        
        //3
        public static IEnumerable<Customer> WithAnyOrderCostGreaterThan(double cost)
        {
            return AllCustomers.Where(customer => customer.Orders.Any(order=>order.Total>cost));
        }
        //5
        public static IEnumerable<Customer> SortByDateOfStartService()
        {
            return AllCustomers.OrderBy(customer => customer.DateOfStartService);
        }
        
        public static IEnumerable<Customer> SortByTotalProfit()
        {
            return AllCustomers.OrderByDescending(customer => customer.TotalOrderSum);
        }
        public static IEnumerable<Customer> SortByName()
        {
            return AllCustomers.OrderBy(customer => customer.Name);
        }
        //6
        public static IEnumerable<Customer> WithIncorrectCodeInPhone()
        {
            return AllCustomers.Where(customer => !customer.IsCorrectCodeInPhone());
        }
        //7
        public static double AverageProfitOnCity(string city)
        {
            AllCustomers.Where(c => c.City.Equals(city, StringComparison.InvariantCulture)).Average(cus => cus.TotalOrderSum);
            double average = 0;
            int countOfCustomersFromCity = 0;
            foreach (var customer in AllCustomers)
            {
                if (customer.City == city)
                {
                    average += customer.TotalOrderSum;
                    countOfCustomersFromCity++;
                }
            }
            return average / countOfCustomersFromCity;
        }
        public static double AverageCountOfOrdersOnCity(string city)
        {
            double average = 0;
            int countOfCustomersFromCity = 0;
            foreach (var customer in AllCustomers)
            {
                if (customer.City == city)
                {
                    average += customer.Orders.Count;
                    countOfCustomersFromCity++;
                }
            }
            return average / countOfCustomersFromCity;
        }
        //8
        public static Dictionary<int, int> StastisticsOnMonth()
        {
            Dictionary<int, int> activity = new Dictionary<int, int>();
            foreach (var customer in AllCustomers)
            {
                foreach (var order in customer.Orders)
                {
                    AddToStatistics(order.OrderDate.Month, activity);
                }
            }
            return activity;
        }
        public static Dictionary<int, int> StastisticsOnYear()
        {
            Dictionary<int, int> activity = new Dictionary<int, int>();
            foreach (var customer in AllCustomers)
            {
                foreach (var order in customer.Orders)
                {
                    AddToStatistics(order.OrderDate.Year, activity);
                }
            }
            return activity;
        }
        public static Dictionary<string, int> StastisticsOnYearAndMonth()
        {
            Dictionary<string, int> activity = new Dictionary<string, int>();
            foreach (var customer in AllCustomers)
            {
                foreach (var order in customer.Orders)
                {
                    AddToStatistics($"{order.OrderDate.Year} {order.OrderDate.Month}", activity);
                }
            }
            return activity;

        }
        private static void AddToStatistics<TKey>(TKey itemForSort, Dictionary <TKey, int> activity)
        {
            if (activity.ContainsKey(itemForSort))
                activity[itemForSort]++;
            else
                activity.Add(itemForSort, 1);
        }
    }
}
