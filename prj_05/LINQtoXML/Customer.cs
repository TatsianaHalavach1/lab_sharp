using System;
using System.Collections.Generic;
using System.Text;

namespace LINQtoXML
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; }
        public string Address { get; }
        public string City { get; }
        public string Postalcode { get; }
        public string Country { get; }
        public string Phone { get; }
        public string Fax { get; }
        public List<Order> Orders { get; } = new List<Order>();
        private double _totalOrderSum;
        private DateTime _dateOfStartService;

        public double TotalOrderSum
        {
            get
            {
                foreach (var order in Orders)
                {
                    _totalOrderSum += order.Total;
                }
                return _totalOrderSum;
            }
        }

        public DateTime DateOfStartService
        {
            get
            {
                _dateOfStartService = DateTime.MaxValue;
                foreach (var order in Orders)
                {
                    if (order.OrderDate < _dateOfStartService)
                        _dateOfStartService = order.OrderDate;
                }
                return _dateOfStartService;
            }
        }
        
        public Customer(string id, string name, string address, string city,
            string postalcode, string country, string phone, string fax, List<Order>orders = null)
        {
            Id = id ?? "";
            Name = name ?? "";
            Address = address ?? "";
            City = city ?? "";
            Postalcode = postalcode ?? "";
            Country = country ?? "";
            Phone = phone ?? "";
            Fax = fax ?? "";
            if(orders!=null)
                Orders.AddRange(orders);
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();
            resultString.AppendFormat($"Id: {Id}\n");
            resultString.AppendFormat($"Name: {Name}\n");
            resultString.AppendFormat($"Address: {Address}\n");
            resultString.AppendFormat($"City: {City}\n");
            resultString.AppendFormat($"Postalcode: {Postalcode}\n");
            resultString.AppendFormat($"Country: {Country}\n");
            resultString.AppendFormat($"Phone: {Phone}\n");
            resultString.AppendFormat($"Fax: {Fax}\n");
            foreach (var order in Orders)
            {
                resultString.Append(order);
            }
            return resultString.ToString();
        }

        public string NameAndDateOfStartService()
        {
            return $"{Name} {DateOfStartService.Month} {DateOfStartService.Year}";
        }

        public bool IsCorrectCodeInPhone()
        {
            if (Phone.StartsWith("(") && Phone.Contains(")"))
                return true;
            return false;
        }
    }
}
