using System;
using System.Text;

namespace LINQtoXML
{
    public class Order
    {
        public int Id { get; }
        public DateTime OrderDate { get; }
        public double Total { get; }

        public Order(string id, string orderDate, string total)
        {
            Id = int.Parse(id);
            OrderDate = DateTime.Parse(orderDate);
            Total = double.Parse(total);
        }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();
            resultString.AppendFormat($"\n\t{Id}\n");
            resultString.AppendFormat($"\tOrderDate: {OrderDate}\n");
            resultString.AppendFormat($"\tTotal: {Total}");
            return resultString.ToString();
        }
    }
}
