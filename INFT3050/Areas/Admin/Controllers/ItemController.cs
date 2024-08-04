using Microsoft.AspNetCore.Mvc;
using INFT3050.Models;
using Microsoft.AspNetCore.Authorization;
using INFT3050.Areas.Admin.Models;

namespace INFT3050.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ItemController : Controller
    {
        private VitaStoreContext context { get; set; }
        private IWebHostEnvironment hostenv { get; set; }
        public ItemController(VitaStoreContext itemctx, IWebHostEnvironment webenv)
        {
            context = itemctx;
            hostenv = webenv;
        }


        [HttpGet]
        public IActionResult AddItem()
        {
            // set a ViewBag (keyword in MVC) property named "Action" to the string "AddItem"
            // this is used to pass additional data to the view
            ViewBag.Action = "AddItem";

            // return the "EditStaff" view, providing it with a new, empty instance of the Item model
            // this is used to render a form for creating a new Item
            return View("~/Areas/Admin/Views/Item/EditItem.cshtml", new Item());
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            /*var vm = new ItemImageListViewModel()
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };*/
            ViewBag.Action = "EditItem";
            var item = context.Items.Find(id);
            return View("~/Areas/Admin/Views/Item/EditItem.cshtml", item);
        }

        [HttpPost]
        public IActionResult EditItem(Item item)
        {

            //check if the data type the user entered is valid
            if (ModelState.IsValid)
            {
                if (item.ItemID == 0)
                    context.Items.Add(item);
                else
                    context.Items.Update(item);
                context.SaveChanges();
                return RedirectToAction("ManageItem", "Item"); //first parameter - method, second parameter - controller
            }
            //if user input an invalid data type
            else
            {
                ViewBag.Action = item.ItemID == 0 ? "AddItem" : "EditItem"; //if not an existing item show add item view else show edit item view
                return View("~/Areas/Admin/Views/Item/EditItem.cshtml", item);
            }
        }

        //for deleting items
        //to get the item delete view
        //need to change this to a pop up prompt
        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            var item = context.Items.Find(id);
            return View("~/Areas/Admin/Views/Item/DeleteItem.cshtml", item);
        }

        //to delete the staff
        [HttpPost]
        public IActionResult DeleteItem(Item item)
        {
            context.Items.Remove(item);
            foreach (var i in context.Images)
            {
                if (i.ItemID == item.ItemID)
                {
                    context.Images.Remove(i);
                }
            }
            context.SaveChanges();
            return RedirectToAction("ManageItem", "Item"); //first parameter - method, second parameter - controller

        }

        [HttpGet]
        public IActionResult UploadImage(int id) 
        {
            // set a ViewBag (keyword in MVC) property named "Action" to the string "AddItem"
            // this is used to pass additional data to the view
            ViewBag.Action = "UploadImage";


            Item item = context.Items.Find(id);

            var vm = new UploadImageViewModel
            {
                //ItemInstance = item,
                ItemId = item.ItemID
            };

            // return the "EditStaff" view, providing it with a new, empty instance of the Item model
            // this is used to render a form for creating a new Item
            return View("~/Areas/Admin/Views/Item/UploadImage.cshtml", vm);
        }

       [HttpPost]
        public IActionResult UploadImage(UploadImageViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var item = context.Items.Find(model.ItemId);
                

                if (model.ImageFile != null)
                {
                    string uploadFolder = Path.Combine(hostenv.WebRootPath, "Image");
                    string fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    string filePath = Path.Combine(uploadFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    // Create new Image recordadd new image
                    var image = new Image
                    {
                        ItemID = model.ItemId,
                        ImagePath = fileName
                    };


                    context.Images.Add(image);
                    context.SaveChanges(); // Save image record
                }
                return RedirectToAction("ManageItem", "Item");
            }
            else
            {
                 //if not an existing item show add item view else show edit item view
                return View("~/Areas/Admin/Views/Item/UploadImage.cshtml", model);
            }

        }
       

        public IActionResult ManageItem()
        {
            var vm = new ItemImageListViewModel()
            {
                Items = context.Items.ToList(),
                Images = context.Images.ToList()
            };
            return View("~/Areas/Admin/Views/Item/ManageItems.cshtml", vm);
            
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteAllImages(int itemId)
        {
            var images = context.Images.Where(i => i.ItemID == itemId).ToList();
            string uploadFolder = Path.Combine(hostenv.WebRootPath, "Image");
            foreach (var image in images)
            {
                var filePath = Path.Combine(uploadFolder, image.ImagePath);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                context.Images.Remove(image);
            }
            context.SaveChanges();
            return RedirectToAction("ManageItem");
        }

        }
}
