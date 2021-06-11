using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sdp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using sdp.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace sdp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IMenuRepository _foodRepository;

        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMenuRepository foodRepository, IWebHostEnvironment hostEnvironment)
        {
            _foodRepository = foodRepository;
            this.hostingEnvironment = hostEnvironment;
        }
        private string ProcessUploadedFile(MenuCreateViewModel model)
        {
            string uniquefilename = null;
            if (model.Photo != null)
            {

                string uploadfolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniquefilename = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;


                string filepath = Path.Combine(uploadfolder, uniquefilename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.Photo.CopyTo(filestream);
                }
            }

            return uniquefilename;
        }
        [Authorize(Roles="Admin")]
        [HttpGet]

        public ViewResult Edit(int id)
        {

            Menu food = _foodRepository.GetFood(id);
            MenuEditViewModel itemEditViewModel = new MenuEditViewModel
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price,
                Category = food.Category,
                Ingredients = food.Ingredients,

                ExistingPhotoPath = food.PhotoPath

            };
            return View(itemEditViewModel);
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(MenuEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Menu food = _foodRepository.GetFood(model.Id);
                food.Name = model.Name;
                food.Category = model.Category;
                food.Price = model.Price;
                food.Ingredients = model.Ingredients;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filepath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    food.PhotoPath = ProcessUploadedFile(model);
                }

                _foodRepository.Update(food);

                return RedirectToAction("index", new { id = food.Id });
            }
            return View(model);
        }
        public ViewResult Index()
        {

            var model = _foodRepository.GetAllFood();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int? id)
        {


            Menu food = _foodRepository.GetFood(id.Value);
            if (food == null)
            {
                Response.StatusCode = 404;
                return View("FoodNotFound", id.Value);
            }
            Menu model = food;
            
            return View(model);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]

        [Authorize(Roles = "Admin")]
        public ViewResult Create()
        {

            return View();
        }
      [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(MenuCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniquefilename = ProcessUploadedFile(model);

                Menu newFood = new Menu
                {
                    Name = model.Name,

                    PhotoPath = uniquefilename,

                    Category = model.Category,

                    Price = model.Price,

                    Ingredients = model.Ingredients

                };
                _foodRepository.Add(newFood);

                return RedirectToAction("index");
            }
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Menu food = _foodRepository.GetFood(id);
            MenuEditViewModel employeeEditViewModel = new MenuEditViewModel
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price,
                Category = food.Category,
                Ingredients = food.Ingredients,


                ExistingPhotoPath = food.PhotoPath

            };
            return View(employeeEditViewModel);

        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteConfirmed(int id)
        {

            if (ModelState.IsValid)
            {
                Menu fooditem = _foodRepository.GetFood(id);
                _foodRepository.Delete(id);

                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
