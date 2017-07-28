﻿using MyAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
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
            return View(db.Products.ToList());
        }

        public ActionResult Create()
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
                        imageDetails.Add(images);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"),images.ImageUrl);
                        file.SaveAs(path);
                    }
                }
                product.ImageDetails = imageDetails;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModal product = db.Products.Include(s =>s.ImageDetails).SingleOrDefault(x => x.ProductID == id);
            if(product==null)
            {
                return HttpNotFound();

            }
            return View(product);
        }
        public FileResult Download(string p, string d)
        {
            return File(Path.Combine(Server.MapPath("~/App_Data/Upload/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModal product)
        {
            if(ModelState.IsValid)
            {
                for(int i=0;i <Request.Files.Count;i++)
                {
                    var file = Request.Files[i];
                    if(file !=null && file.ContentLength>0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ProductImageModal imageModal = new ProductImageModal()
                        {
                            ImageUrl = fileName,
                            ProductId=product.ProductID
                        };
                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), imageModal.ProductId + fileName);
                        file.SaveAs(path);
                        db.Entry(imageModal).State = EntityState.Added;
                    }
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
           
        }

        [HttpPost]
        public JsonResult  DeleteFiles(int? id)
        {
            if(id==null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                ProductImageModal imageModal = db.ProductImages.Find(id);
                if (imageModal == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                db.ProductImages.Remove(imageModal);
                db.SaveChanges();

                var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), imageModal.ImageId + imageModal.ImageUrl);
                if(System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                ProductModal product = new ProductModal();
                if(product==null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                foreach(var item in product.ImageDetails)
                {
                    string path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), item.ProductId + item.ImageUrl);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
                db.Products.Remove(product);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }
       
    }
}