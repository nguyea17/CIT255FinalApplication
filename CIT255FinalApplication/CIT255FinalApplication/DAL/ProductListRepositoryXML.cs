using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace CIT255FinalApplication
{
    public class ProductListRepositoryXML : IDisposable, IProductListRepository
    {       
            private List<ProductName> _productNames;

            /// <summary>
            /// method to write all products information to the data file
            /// </summary>   
            public ProductListRepositoryXML()
            {
                _productNames = ReadProductNamesData(DataSettings.dataFilePath);
            }
            /// <summary>
            /// method to read all products information from the data file and return it as a list of ProductName objects
            /// </summary>
            /// <param name="dataFilePath">path the data file</param>
            /// <returns>list of ProductName objects</returns>
            public List<ProductName> ReadProductNamesData(string dataFilePath)
            {            
                 ProductNames productNameFromFile = new ProductNames();

            //initialize a FileStream object for reading
            StreamReader sReader = new StreamReader(DataSettings.dataFilePath);

            //initialize an XML serializer object

            XmlSerializer deserializer = new XmlSerializer(typeof(ProductNames));

                 using (sReader)
                 {
                    object xmlObject = deserializer.Deserialize(sReader);
                productNameFromFile = (ProductNames)xmlObject;
                 }

                 return productNameFromFile.productNames;
            }
            /// <summary>
            /// method to save all of the list of product names to the text file
            /// </summary>
            public void Save()
            {
                //intialize a FileStream object for reading
                StreamWriter sWriter = new StreamWriter(DataSettings.dataFilePath, false);
                 
                XmlSerializer serializer = new XmlSerializer(typeof(List<ProductName>), new XmlRootAttribute("ProductNames"));

                 using (sWriter)
                 {
                     serializer.Serialize(sWriter, _productNames);
                 }
              }
            /// <summary>
            /// method to add a new product to a list
            /// </summary>
            /// <param name="productName"></param>
            public void Insert(ProductName productName)
            {
                 _productNames.Add(productName);

                 Save();
            }
            /// <summary>
            /// method to delete a product by product ID
            /// </summary>
            /// <param name="ID"></param>
            public void Delete(int ID)
            {
                _productNames.Remove(_productNames.FirstOrDefault(pn => pn.ID == ID));

                Save();
            }
            /// <summary>
            /// method to update an existing product
            /// </summary>
            /// <param name="productName"></param>
            public void Update(ProductName productName)
            {
                Delete(productName.ID);
                Insert(productName);

                Save();
            }
            /// <summary>
            /// method to return a product name object given the ID
            /// </summary>
            /// <param name="ID">int ID</param>
            /// <returns>product name object</returns>
            public ProductName SelectById(int ID)
            {
                ProductName productName = null;
                productName =_productNames.FirstOrDefault(pn => pn.ID == ID);

                return productName;
            }
            /// <summary>
            /// method to return a list of product objects
            /// </summary>
            /// <returns>list of product objects</returns>
            public List<ProductName> SelectAll()
            {
                return _productNames;
            }      
             /// <summary>
             /// method to handle the IDisposable interface contract
             /// </summary>
             public void Dispose()
             {
                _productNames = null;
             }
        }
    }

