using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
    public class Controller
    {
        #region FIELDS

        bool active = true;
        static IProductListRepository productListRepository;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            productListRepository = new ProductListRepositoryXML();

            ApplicationControl();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// method to manage the main menu screen
        /// </summary>
        private void ApplicationControl()
        {
            AppEnum.ManagerAction userActionChoice;

            ConsoleView.DisplayWelcomeScreen();

                while (active)
                {
                                  
                    userActionChoice = ConsoleView.GetUserActionChoice();

                    switch (userActionChoice)
                    {
                        case AppEnum.ManagerAction.None:
                            break;

                    case AppEnum.ManagerAction.ListAllProductNames:
                        ListAllProductsAvailable();
                        break;

                        case AppEnum.ManagerAction.DisplayProductNameDetail:
                        DisplayProductDetail();
                            break;

                        case AppEnum.ManagerAction.DeleteProductName:
                        DeleteProductName();
                            break;
                      
                        case AppEnum.ManagerAction.AddProductName:
                        AddProductName();                          
                            break;

                        case AppEnum.ManagerAction.UpdateProductName:
                        UpdateProductName();                           
                            break;

                        case AppEnum.ManagerAction.QueryProductNamesByPrice:
                        QueryProductNameByPrice();
                            break;
                        case AppEnum.ManagerAction.Quit:
                            active = false;
                            break;
                        default:
                            break;
                    }
                }

            ConsoleView.DisplayExitPrompt();
            }
        /// <summary>
        /// method to query an item based on the min and max value
        /// </summary>
        private static void QueryProductNameByPrice()
        {
            ProductNameBusiness productNameBusiness = new ProductNameBusiness(productListRepository);

            List<ProductName> matchingProductNames;
            int minimumPrice;
            int maxPrice;

            ConsoleView.GetPriceQueryMinMaxValues(out minimumPrice, out maxPrice);

            using (productNameBusiness)
            {
                matchingProductNames = productNameBusiness.QueryByPrice(minimumPrice, maxPrice);
            }

            ConsoleView.DisplayQueryResults(matchingProductNames);
            ConsoleView.DisplayContinuePrompt();
        }

        private static void UpdateProductName()
        {
            ProductNameBusiness productNameBusiness = new ProductNameBusiness(productListRepository);

            List<ProductName> productNames;
            ProductName productName;
            int productNameID;

            using (productNameBusiness)
            {
                productNames = productNameBusiness.SelectAll();
                productNameID = ConsoleView.GetProductNameID(productNames);
                productName = productNameBusiness.SelectById(productNameID);
                productName = ConsoleView.UpdateProductName(productName);
                productNameBusiness.Update(productName);
            }
        }

        private static void AddProductName()
        {
            ProductNameBusiness productNameBusiness = new ProductNameBusiness(productListRepository);

            ProductName productName;

            productName = ConsoleView.AddProductName();
            using (productNameBusiness)
            {
                productNameBusiness.Insert(productName);
            }

            ConsoleView.DisplayContinuePrompt();
        }

        private static void DeleteProductName()
        {
            ProductNameBusiness productNameBusiness = new ProductNameBusiness(productListRepository);

            List<ProductName> productNames;
            int productNameID;
            string message;

            using (productNameBusiness)
            {
                productNames = productNameBusiness.SelectAll();
                productNameID = ConsoleView.GetProductNameID(productNames);
                productNameBusiness.Delete(productNameID);
            }

            ConsoleView.DisplayReset();

            message = String.Format("Product ID: {0} had been deleted. ", productNameID);

            ConsoleView.DisplayMessage(message);
            ConsoleView.DisplayContinuePrompt();
        }

        private void DisplayProductDetail()
        {
            ProductNameBusiness productNameBusiness = new ProductNameBusiness(productListRepository);

            List<ProductName> productNames;
            ProductName productName;
            int productNameID;

            using (productNameBusiness)
            {
                productNames = productNameBusiness.SelectAll();
                productNameID = ConsoleView.GetProductNameID(productNames);
                productName = productNameBusiness.SelectById(productNameID);
            }

            ConsoleView.DisplayProductName(productName);
            ConsoleView.DisplayContinuePrompt();
        }

        private void ListAllProductsAvailable()
        {
            ProductNameBusiness productNameBusiness = new ProductNameBusiness(productListRepository);

            List<ProductName> productNames;

            using (productNameBusiness)
            {
                productNames = productNameBusiness.SelectAll();
                ConsoleView.DisplayAllProductNames(productNames);
                ConsoleView.DisplayContinuePrompt();
            }
         }
        #endregion
    }
}
