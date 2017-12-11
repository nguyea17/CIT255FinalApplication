using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
    public class AppEnum
    {
        public enum ManagerAction
        {
            None,
            ListAllProductNames,
            DisplayProductNameDetail,
            DeleteProductName,
            AddProductName,
            UpdateProductName,
            QueryProductNamesByPrice,
            QueryProductByLocation,
            Quit,
        }
    }
}
