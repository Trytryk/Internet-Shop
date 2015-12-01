using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5.Controllers
{
    public class ProductWebAPIController : ApiController
    {
        //private IProductRepository<Product> db;
        
        //public ProductWebAPIController(IProductRepository<Product> irepository)
        //{
        //    db = irepository;
        //}

        private ProductRepository db = new ProductRepository(new ProductContext());

        // GET api/values
        public IEnumerable<Product> Get()
        {

            return db.GetAll();

        }
    }
}
