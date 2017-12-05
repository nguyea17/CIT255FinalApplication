using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
    public interface IProductListRepository
    {
        List<ProductName> SelectAll();
        ProductName SelectById(int id);
        void Insert(ProductName obj);
        void Update(ProductName obj);
        void Delete(int id);
        void Save();
    }
}
