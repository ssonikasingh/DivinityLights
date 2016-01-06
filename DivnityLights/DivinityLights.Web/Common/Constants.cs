namespace DivinityLights.Web.Common 
{
    public static class Constants
    {
    }

    public struct ConfigKeys
    {
        public const string ImagePath = "ImagePath";
        public const string HomeCategoryCount = "HomeCategoryCount";
        public const string ProductsPerPage = "ProductsPerPage";
    }    
  
    public struct Controllers
    {
        public const string HomeController = "Home";
        public const string ProductController = "Product";
    }

    public struct Actions
    {
        public const string Index = "Index";
        public const string About = "About";
        public const string CategoryProducts = "CategoryProducts";
        public const string Product = "Product";
    }

    public struct Views
    {
        public const string CategoryProducts = "CategoryProducts"; 
    }

    public struct TempDataKeys
    {
        public const string Products = "Products";
    }

}