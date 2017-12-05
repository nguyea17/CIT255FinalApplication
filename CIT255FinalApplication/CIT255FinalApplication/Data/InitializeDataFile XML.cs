using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System;

namespace CIT255FinalApplication
{
    public class InitializeDataFileXML
    {
        public static void AddTestData()
        {
            List<ProductName> productNames = new List<ProductName>();

            // initialize the List of products
            productNames.Add(new ProductName() { ID = 1, Name = "Sugar", Price = 2, Location = 1 });
            productNames.Add(new ProductName() { ID = 2, Name = "Candy", Price = 1.5, Location = 1 });
            productNames.Add(new ProductName() { ID = 3, Name = "Coffee", Price = 4, Location = 1 });
            productNames.Add(new ProductName() { ID = 4, Name = "Jello", Price = 1.99, Location = 1 });
            productNames.Add(new ProductName() { ID = 5, Name = "Flour", Price = 3, Location = 2 });
            productNames.Add(new ProductName() { ID = 6, Name = "Bread", Price = 1.5, Location = 2 });
            productNames.Add(new ProductName() { ID = 7, Name = "Eggs", Price = 0.85, Location = 3 });
            productNames.Add(new ProductName() { ID = 8, Name = "Milk", Price = 2.75, Location = 3});
            productNames.Add(new ProductName() { ID = 9, Name = "Cheese", Price = 4, Location = 3 });
            productNames.Add(new ProductName() { ID = 10, Name = "Meat", Price = 8, Location = 3 });
            productNames.Add(new ProductName() { ID = 11, Name = "Spaghetti", Price = 3, Location = 4 });
            productNames.Add(new ProductName() { ID = 12, Name = "Canned Soup", Price = 4.5, Location = 4 });
            productNames.Add(new ProductName() { ID = 13, Name = "Brown Rice", Price = 10, Location = 4 });
            productNames.Add(new ProductName() { ID = 14, Name = "Taco Shell", Price = 1.99, Location = 4 });
            productNames.Add(new ProductName() { ID = 15, Name = "Salad Dressing", Price = 3.5, Location = 4 });

            WriteAllProductNames(productNames, DataSettings.dataFilePath);
        }

        /// <summary>
        /// method to write all products info to the data file
        /// </summary>
        /// <param name="productNames">list of products info</param>
        /// <param name="dataFilePath">path to the data file</param>
        public static void WriteAllProductNames(List<ProductName> productNames, string dataFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductName>), new XmlRootAttribute("ProductNames"));

            StreamWriter sWriter = new StreamWriter(dataFilePath);

            using (sWriter)
            {
                serializer.Serialize(sWriter, productNames);
            }
        }
    }
}
