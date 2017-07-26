using MyAssignment2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAssignment2.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModal product)
        {
            if(ModelState.IsValid)
            {
                List<ProductImageModal> imageDetails = new List<ProductImageModal>();
                for(int i=0;i<Request.Files.Count;i++)
                {
                    var file = Request.Files[i];
                    if(file!=null && file.ContentLength>0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ProductImageModal images = new ProductImageModal()
                        {
                            ImageUrl = fileName
                       

                        };
                    }
                }
            }
            return null;
        }
    }
}