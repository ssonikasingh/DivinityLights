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
using System.IO;
using System.Configuration;

namespace DivinityLights.Web.Controllers
{
    public class ProductController : BaseController
    {
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            ProductListViewModel model = null;

            string productsPerPage = WebConfigurationManager.AppSettings[ConfigKeys.ProductsPerPage];
            int pageSize = 0;
            int.TryParse(productsPerPage, out pageSize);

            List<Product> products = ProductManager.GetProducts().ToList();
            model = DivinityConverter.ConvertToViewModel(products);


            if (model != null && model.Products != null && model.Products.Count() > 0)
                model.ProductsPaged = model.Products.ToPagedList(page, pageSize);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView(PartialViews.ListProducts, model)
                : View(Views.index, model);
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
          [Authorize]
        public ActionResult AddEdit(int id = 0)
        {
            ProductViewModel model = null;
            if (id > 0)
            {
                Product product = ProductManager.GetProduct(id);
                model = DivinityConverter.ConvertToViewModel(product);
            }
            else
            {
                model = new ProductViewModel();
            }

            model.CategoryList = new SelectList(CategoryManager.GetCategories(), "Id", "Name");

            return PartialView(PartialViews.AddEditProduct, model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult AddEdit(ProductViewModel model, List<HttpPostedFileBase> fileUploads, int page)
        {
            try
            {
                List<ProductImagesViewModel> lstimage = null;
                if (fileUploads != null && fileUploads.Count > 0 && fileUploads[0] != null)
                {
                    lstimage = new List<ProductImagesViewModel>();
                    foreach (HttpPostedFileBase image in fileUploads)
                    {
                        if (image != null)
                        {
                            var path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings[ConfigKeys.ImagePath].ToString()), image.FileName);
                            image.SaveAs(path);
                            lstimage.Add(new ProductImagesViewModel() { Image = image.FileName });
                        }
                    }
                }

                Product product = DivinityConverter.ConvertToEntity(model, lstimage);
                ProductManager.AddEditProduct(product);
                return RedirectToAction(Actions.Index, new { page = page });
            }
            catch
            {
                throw;
                //return RedirectToAction(Actions.Index, new { page = page });
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
                ? (ActionResult)PartialView(PartialViews.Products, model)
                : View(Views.CategoryProducts, model);
        }
    }
}
