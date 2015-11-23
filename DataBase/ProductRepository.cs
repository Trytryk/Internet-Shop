using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace DataBase
{
    public class ProductRepository : GenericProductRepository<Product>
    {
       // ProductContext context = new ProductContext();

        public ProductRepository(ProductContext context)
           : base(context)
       {
           
       }
       
        public override void Create(Product product, byte[] array)
        {
            product.Pictures = array;
            _dbset.Add(product);
            Save();
        }
    }
}
