using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SourceControlFinalAssignment.DAL;
using SourceControlFinalAssignment.Models;
using log4net;

namespace SourceControlFinalAssignment.Controllers
{
    public class ProductsController : Controller
    {
        private ProductContext db = new ProductContext();
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProductsController));
        // GET: Products
        public ActionResult Index()
        {
            Log.Info("Executing Index Method");
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,Category,Price,Quantity,ShortDesc,LongDesc,ProductImage,DealerPhone,ProductRegion")] Product product)
        {
            Log.Info("Executing HttpPost Create Method");
            if (ModelState.IsValid)
            {
                Log.Info("ModelState is valid");
                //to save the product image
                if (product.ProductImage != null)
                {
                    string FileName = Path.GetFileName(product.ProductImage.FileName);
                    string FilePath = Path.Combine(HttpContext.Server.MapPath("~/ProductImages"), FileName);

                    product.ProductImagePath = FilePath;

                    //To copy and save file into server.  
                    product.ProductImage.SaveAs(product.ProductImagePath);
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Category,Price,Quantity,ShortDesc,LongDesc,ProductImage,DealerPhone")] Product product)
        {
            if (ModelState.IsValid)
            {

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
