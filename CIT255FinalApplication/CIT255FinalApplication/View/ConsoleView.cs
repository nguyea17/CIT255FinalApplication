using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
   public static class ConsoleView
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        // window size   
        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        // horizontal and Price margins in console window for display
        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPALY_VERITCAL_MARGIN = ViewSettings.DISPALY_VERITCAL_MARGIN;

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        /// <summary>
        /// method to display the manager menu and get the user's choice
        /// </summary>
        /// <returns></returns>
        public static AppEnum.ManagerAction GetUserActionChoice()
        {
            AppEnum.ManagerAction userActionChoice = AppEnum.ManagerAction.None;     
                
            // set a string variable with a length equal to the horizontal margin and filled with spaces        
            string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

            // set up display area      
            DisplayReset();

            // display the menu        
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Main Menu Screen", WINDOW_WIDTH));
            DisplayMessage("");
          
            Console.WriteLine(
                leftTab + "1. List All Products Available" + Environment.NewLine +
                leftTab + "2. Display a Product Detail" + Environment.NewLine +
                leftTab + "3. Delete the Product  " + Environment.NewLine +
                leftTab + "4. Add a Product" + Environment.NewLine +
                leftTab + "5. Update a Product" + Environment.NewLine +
                leftTab + "6. Query a Product by Price" + Environment.NewLine +
                leftTab + "7. Query a Product by Location" + Environment.NewLine +
                leftTab + "E. Exit" + Environment.NewLine);

            DisplayMessage("");
            DisplayPromptMessage("Enter the number/letter for the menu choice.");
            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case '1':
                    userActionChoice = AppEnum.ManagerAction.ListAllProductNames;
                    break;
                case '2':
                    userActionChoice = AppEnum.ManagerAction.DisplayProductNameDetail;
                    break;
                case '3':
                    userActionChoice = AppEnum.ManagerAction.DeleteProductName;
                    break;
                case '4':
                    userActionChoice = AppEnum.ManagerAction.AddProductName;
                    break;
                case '5':
                    userActionChoice = AppEnum.ManagerAction.UpdateProductName;
                    break; ;
                case '6':
                    userActionChoice = AppEnum.ManagerAction.QueryProductNamesByPrice;
                    break;
                case '7':
                    userActionChoice = AppEnum.ManagerAction.QueryProductByLocation;
                    break;
                case 'E':
                case 'e':
                    userActionChoice = AppEnum.ManagerAction.Quit;
                    break;
                default:
                    DisplayMessage("");
                    DisplayMessage("");
                    DisplayMessage("It appears you have selected a wrong choice");
                    DisplayMessage("");
                    DisplayMessage("Press any key to try again or the ESC key to exit.");
                   
                    userResponse = Console.ReadKey(true);
                    if (userResponse.Key == ConsoleKey.Escape)
                    {
                        userActionChoice = AppEnum.ManagerAction.Quit;
                    }
                    break;
            }
            return userActionChoice;
        }
        /// <summary>
        /// method to display all products info
        /// </summary>
        public static void DisplayAllProductNames(List<ProductName> ProductNames)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display All Products Available", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the existing products are displayed below;");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("Product Name".PadRight(20));
            columnHeader.Append("$ Price ".PadRight(15));
            columnHeader.Append("Location".PadRight(25));

            DisplayMessage(columnHeader.ToString());

            foreach (ProductName ProductName in ProductNames)
            {
                StringBuilder ProductNameInfo = new StringBuilder();

                ProductNameInfo.Append(ProductName.ID.ToString().PadRight(8));
                ProductNameInfo.Append(ProductName.Name.PadRight(20));
                ProductNameInfo.Append(ProductName.Price.ToString().PadRight(15));
                ProductNameInfo.Append(ProductName.Location.ToString().PadLeft(4));

                DisplayMessage(ProductNameInfo.ToString());
            }
        }
        public static int DeleteProductName(List<ProductName> ProductNames)
        {
            DisplayReset();
            DisplayMessage("Delete a product from the list");
            DisplayMessage("");

            int ProductNameID = GetProductNameID(ProductNames);

            return ProductNameID;
        }
        /// <summary>
        /// method to get productID from the user's choice
        /// </summary>
        /// <param name="productNames"></param>
        /// <returns></returns>
        public static int GetProductNameID(List<ProductName> productNames)
        {
            int productNameID = -1;

            DisplayAllProductNames(productNames);

            DisplayMessage("");
            DisplayPromptMessage("Enter the product ID: ");

            productNameID = ConsoleUtil.ValidateIntegerResponse("Please enter the product ID: ", Console.ReadLine());

            return productNameID;
        }
        /// <summary>
        /// a method to add a new product to the List
        /// </summary>
        /// <returns></returns>
        public static ProductName AddProductName()
        {
            ProductName productName = new ProductName();

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Add a Product to the List", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the product name: ");
            productName.Name = Console.ReadLine();
            DisplayMessage("");
            while (productName.Name == "")
            {
                DisplayMessage("");
                DisplayPromptMessage("Enter the product name again: ");               
                productName.Name = Console.ReadLine();
                DisplayMessage("");
            }
            DisplayMessage("");

            DisplayPromptMessage("Enter the product's price: ");
            productName.Price = Convert.ToDouble(Console.ReadLine());
            DisplayMessage("");
            while (productName.Price < 0)
            {
                DisplayMessage(" ");
                DisplayPromptMessage("Please enter a positive number for price: ");
                DisplayMessage(" ");
                productName.Price = Convert.ToDouble(Console.ReadLine());
                DisplayMessage("");
            }           

            DisplayPromptMessage("Enter the product's location: ");
            productName.Location = ConsoleUtil.ValidateIntegerResponse("Please type a number for the product's location: ", Console.ReadLine());

            return productName;          
        }
        /// <summary>
        /// a method to display the detail of a specific product 
        /// </summary>
        /// <param name="productName"></param>
        public static void DisplayProductName(ProductName productName)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Product Detail", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("ID: {0}", productName.ID.ToString()));           
            DisplayMessage("");

            DisplayMessage(String.Format("Product Name: {0}", productName.Name));            
            DisplayMessage("");

            DisplayMessage(String.Format("Price: {0}", productName.Price.ToString()));
            DisplayMessage("");

            DisplayMessage(String.Format("Location: {0}", productName.Location.ToString()));
            DisplayMessage("");
        }
        /// <summary>
        /// a method to edit the product's info
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static ProductName UpdateProductName(ProductName productName)
        {
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Edit a product's information", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Current Name: {0}", productName.Name));
            DisplayMessage("");

            DisplayPromptMessage("Enter a new name or just press Enter to keep the current name: ");
            userResponse = Console.ReadLine();
            if(userResponse != "")
            {
                productName.Name = userResponse;
            }
            DisplayMessage("");
            DisplayMessage(String.Format("Current location: {0}", productName.Location.ToString()));
            DisplayMessage("");

            DisplayPromptMessage("Enter the new location in number or just press Enter to keep the current location: ");
            userResponse = Console.ReadLine();
            if(userResponse != "")
            {
                productName.Location = ConsoleUtil.ValidateIntegerResponse("Please type a number for the location.", userResponse);
            }

            DisplayMessage("");
            DisplayMessage(String.Format("Current price: {0}", productName.Price.ToString()));
            DisplayMessage("");

            DisplayPromptMessage("Enter the new price in number or just press Enter to keep the current price: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                productName.Price = ConsoleUtil.ValidateIntegerResponse("Please type a number for the price.", userResponse);

            }
            DisplayContinuePrompt();

            return productName;
        }
        /// <summary>
        /// query a product by Location
        /// </summary>
        /// <param name="location"></param>
        public static void QueryByLocation(out int location)
        {
            location = 0;
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Query a Product by Location", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the location: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                location = ConsoleUtil.ValidateIntegerResponse("Please enter the location you want to find a product. ", userResponse);

            }

            DisplayMessage("");
            DisplayMessage(String.Format("You have entered {0} as the location to find a product ", location));
            DisplayMessage("");

            DisplayContinuePrompt();


        }
        /// <summary>
        /// method to query a product based on the min and max price
        /// </summary>
        /// <param name="minimumPrice"></param>
        /// <param name="maxPrice"></param>
        public static void GetPriceQueryMinMaxValues(out int minimumPrice, out int maxPrice)
        {
            minimumPrice = 0;
            maxPrice = 0;
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Query a Product by Price", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the minimum price: ");
            userResponse = Console.ReadLine();
            if(userResponse != "")
            {
                minimumPrice = ConsoleUtil.ValidateIntegerResponse("Please enter the minimum price. ", userResponse);
            }

            DisplayMessage("");

            DisplayPromptMessage("Enter the maximum price: ");
            userResponse = Console.ReadLine();
            if(userResponse != "")
            {
                maxPrice = ConsoleUtil.ValidateIntegerResponse("Please enter the max price. ", userResponse);
            }

            DisplayMessage("");
            DisplayMessage(String.Format("You have entered {0} as the minimum price and {1} as the max price. ", minimumPrice, maxPrice));
            DisplayMessage("");

            DisplayContinuePrompt();

        }
        /// <summary>
        /// method to display query results
        /// </summary>
        /// <param name="matchingProductNames"></param>
        public static void DisplayQueryResults(List<ProductName> matchingProductNames)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display Product Query Results", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the matching products are displayed below: ");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("Product Name".PadRight(25));
            columnHeader.Append("$ Price".PadRight(15));
            columnHeader.Append("Location".PadRight(15));

            DisplayMessage(columnHeader.ToString());

            foreach (ProductName productName in matchingProductNames)
            {
                StringBuilder productNameInfo = new StringBuilder();

                productNameInfo.Append(productName.ID.ToString().PadRight(8));
                productNameInfo.Append(productName.Name.PadRight(25));
                productNameInfo.Append(productName.Price.ToString().PadRight(15));
                productNameInfo.Append(productName.Location.ToString().PadLeft(4));

                DisplayMessage(productNameInfo.ToString());
            }
        }
        /// <summary>
        /// reset display to default size and colors including the header
        /// </summary>
        public static void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Grocery Helper", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }
        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();
            Console.WriteLine(ConsoleUtil.Center("Press any key to continue.", WINDOW_WIDTH));
            ConsoleKeyInfo response = Console.ReadKey();
            Console.WriteLine();

            Console.CursorVisible = true;
        }
        /// <summary>
        /// display the Exit prompt
        /// </summary>
        public static void DisplayExitPrompt()
        {
            DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for using our application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }
        /// <summary>
        /// display the welcome screen
        /// </summary>
        public static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Grocery Helper", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message in the message area
        /// </summary>
        /// <param name="message">string to display</param>
        public static void DisplayMessage(string message)
        {
            // calculate the message area location on the console window
      
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                // create a list of strings to hold the wrapped text message
               
                List<string> messageLines;

                // call utility method to wrap text and loop through list of strings to display
           
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }
        /// <summary>
        /// display a message in the message area without a new line for the prompt
        /// </summary>
        /// <param name="message">string to display</param>
        public static void DisplayPromptMessage(string message)
        {
            // calculate the message area location on the console window
         
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // create a list of strings to hold the wrapped text message
           
            List<string> messageLines;

            // call utility method to wrap text and loop through list of strings to display
          
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }
        /// <summary>
        /// automatically assign new ID when a product adds to the list
        /// </summary>
        /// <param name="checkDuplicateId"></param>
        /// <returns></returns>
        public static int IncrementProductId(List<ProductName> checkDuplicateId)
        {
            ProductName lastProduct = checkDuplicateId[checkDuplicateId.Count - 1];

            int ID = lastProduct.ID;

            return ID += 1;

        }
        #endregion
    }
}
