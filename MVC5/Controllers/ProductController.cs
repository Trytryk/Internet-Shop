using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase.Models;
using DataBase;
using System.IO;
using ImageResizer;

namespace MVC5.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository<Product> db;
        public ProductController(IProductRepository<Product> irepository) 
        {
            db = irepository;
        }
        public ActionResult Index()
        {
            return View(db.GetAll());
        }       

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Create(product,FileUpload(file));
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (db.GetElementById(Convert.ToInt16(id)) == null)
            {
                return HttpNotFound();
            }
            return View(db.GetElementById(Convert.ToInt16(id)));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public FileContentResult byteArrayToImageResized(int id, string w, string h)
        {
            byte[] byteArray = db.GetElementById(id).Pictures;
            try
            {
                using (var outStream = new MemoryStream())
                {
                    using (var inStream = new MemoryStream(byteArray))
                    {
                        var settings = new ResizeSettings(String.Format("width={0}&height={1}", w, h));
                        ImageResizer.ImageBuilder.Current.Build(inStream, outStream, settings);
                        var outBytes = outStream.ToArray();
                        return new FileContentResult(outBytes, "image/jpeg");
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Null reference exeption");
                return null;
            }
        }

        [HttpPost]
        public byte[] FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);

            }
            MemoryStream ms = new MemoryStream();

            file.InputStream.CopyTo(ms);
            byte[] array = ms.GetBuffer();

            return array;
        }

        
    }
}
