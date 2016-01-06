using DivinityLights.BL;
using DivinityLights.Entities;
using DivinityLights.Web.Common;
using DivinityLights.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Configuration;

namespace DivinityLights.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Product(int id)
        {
            Product product = ProductManager.GetProduct(id);
            ProductViewModel model = DivinityConverter.ConvertToViewModel(product);
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CategoryProducts(int id, int page = 1)
        {
            CatProdViewModel model = null;
            Category category = CategoryManager.GetCategory(id);

            string productsPerPage = WebConfigurationManager.AppSettings[ConfigKeys.ProductsPerPage];
            int pageSize = 0;
            int.TryParse(productsPerPage, out pageSize);

            List<Product> products = ProductManager.GetProductsByCategory(id).ToList();
            model = DivinityConverter.ConvertToViewModel(products, category);


            if (model != null && model.Products != null && model.Products.Count() > 0)
                model.ProductsPaged = model.Products.ToPagedList(page, pageSize);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_Products", model)
                : View(Views.CategoryProducts, model);
        }
    }
}
