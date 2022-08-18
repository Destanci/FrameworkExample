using FrameworkExample.Northwind.Business.Abstract;
using FrameworkExample.Northwind.MvcWebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace FrameworkExample.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region Views

        [ActionName("ProductList")]
        public ActionResult ProductList()
        {
            var productResult = _productService.GetList();

            var model = new ProductListViewModel
            {
                Products = productResult.Entity.ToList(),
            };

            return View(model);
        }

        #endregion

        #region Actions



        #endregion
    }
}