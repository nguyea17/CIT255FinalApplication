using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
    /// <summary>
    /// create a business class to achieve separation concern principle
    /// 
    /// </summary>
   public class ProductNameBusiness : IDisposable
    {
        IProductListRepository _productListRepository;

        public ProductNameBusiness(IProductListRepository repository)
        {
            _productListRepository = repository;
        }

        public void Insert(ProductName productName)
        {
            _productListRepository.Insert(productName);
        }
        public void Delete(int ID)
        {
            _productListRepository.Delete(ID);
        }
        public void Update(ProductName productName)
        {
            _productListRepository.Update(productName);
        }
        public ProductName SelectById(int id)
        {
            return _productListRepository.SelectById(id);
        }
        public List<ProductName> SelectAll()
        {
            return _productListRepository.SelectAll();
        }

        public List<ProductName> QueryByPrice(int minimumPrice, int maxPrice)
        {
            List<ProductName> productNames = _productListRepository.SelectAll();

            return productNames.Where(pn => pn.Price >= minimumPrice && pn.Price <= maxPrice).ToList();
        }
        public void Dispose()
        {
            _productListRepository = null;
        }
    }
}
