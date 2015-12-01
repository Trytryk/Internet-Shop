using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository<Product> db;
        
        public HomeController(IProductRepository<Product> irepository)
        {
            db = irepository;
        }
        public ActionResult GetAllFromWebAPI()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.GetAll().ToList());
        }

        public ActionResult GetProduct(int id)
        {
            Product product = db.GetElementById(id);
            return View(product);
        }
	}
}