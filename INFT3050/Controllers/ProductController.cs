using INFT3050.Models;
using Microsoft.AspNetCore.Mvc;

namespace INFT3050.Controllers
{
    public class ProductController : Controller
    {
        private VitaStoreContext context { get; set; }
        public ProductController(VitaStoreContext itemctx)
        {
            context = itemctx;
        }
        public IActionResult ProductDetails(int id)
        {
            var vm = new ProductDetailViewModel()
            {
                Product = context.Items.Find(id),
                Images = context.Images.ToList()
            };
            return View(vm);
        }

        public IActionResult ProdCat()
        {
            var vm = new ItemImageListViewModel()
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };
            return View(vm);
        }

        public IActionResult BrandPage()
        {
            var vm = new ItemImageListViewModel()
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };
            return View(vm);
        }


    }
}
