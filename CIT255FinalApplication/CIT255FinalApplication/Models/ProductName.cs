using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255FinalApplication
{
   public class ProductName
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Location { get; set; }

        public ProductName()
        {

        }

        public ProductName(int id, string Name, double Price)
        {
            this.ID = id;
            this.Name = Name;
            this.Price = Price;
        }
        public ProductName(int id, string Name, double Price,int Location)
        {
            this.ID = id;
            this.Name = Name;
            this.Price = Price;
            this.Location = Location;
        }

    }
}
