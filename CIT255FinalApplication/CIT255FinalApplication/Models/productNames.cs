using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CIT255FinalApplication
{
    [XmlRoot ("ProductNames")]
    public class ProductNames
    {
        [XmlElement("ProductName")]
        public List<ProductName> productNames = new List<ProductName>();
    }
}
