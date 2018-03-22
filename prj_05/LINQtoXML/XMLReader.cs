using System.Collections.Generic;
using System.Xml.Linq;

namespace LINQtoXML
{
    class XMLReader
    {
        public XDocument Doc { get; }

        public XMLReader(string pathXmlFile)
        {
            Doc = XDocument.Load(pathXmlFile);
        }
        public void PutCustomerListToShop()
        {
            foreach (XElement customer in Doc.Root.Elements("customer"))
            {
                XElement id = customer.Element("id");
                XElement name = customer.Element("name");
                XElement address = customer.Element("address");
                XElement city = customer.Element("city");
                XElement postalcode = customer.Element("postalcode");
                XElement country = customer.Element("country");
                XElement phone = customer.Element("phone");
                XElement fax = customer.Element("fax");
                List<Order> orderList = new List<Order>();
                foreach (XElement order in customer.Element("orders").Elements("order"))
                {
                    XElement idOrder = order.Element("id");
                    XElement orderDate = order.Element("orderdate");
                    XElement total = order.Element("total");
                    orderList.Add(new Order(idOrder.Value, orderDate?.Value, total?.Value));
                }
                ShopCustomers.Add(new Customer(id.Value, name?.Value, address?.Value, city?.Value, postalcode?.Value, country?.Value, phone.Value, fax?.Value, orderList));
            }
        }
    }
}
