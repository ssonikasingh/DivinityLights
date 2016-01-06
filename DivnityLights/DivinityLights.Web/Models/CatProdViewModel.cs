using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace DivinityLights.Web.Models
{
    public class CatProdViewModel : BaseViewModel
    {       
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public PagedList.IPagedList<ProductViewModel> ProductsPaged { get; set; }


    }
}