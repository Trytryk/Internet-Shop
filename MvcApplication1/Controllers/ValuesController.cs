using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MvcApplication1.Controllers
{
     [EnableCors(origins: "http://localhost:52673", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {

        private IProductRepository<Product> db;

        public ValuesController(IProductRepository<Product> irepository)
        {
            db = irepository;
        }
        
        // GET api/values
        public IEnumerable<Product> Get()
        {

            return db.GetAll(); 

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}