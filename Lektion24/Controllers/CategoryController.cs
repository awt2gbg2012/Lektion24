using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion24.Models.Entities;
using Lektion24.Models.Repositories.Abstract;
using Lektion24.Models.ViewModels;

namespace Lektion24.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category> _categoryRepo;
        public CategoryController(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        //
        // GET: /Category/

        public ViewResult Index()
        {
            var categories = _categoryRepo.FindAll().OrderBy(c => c.Name).ToList();
            return View(categories);
        }

        //
        // GET: /Category/Edit/
        public ViewResult Edit(Guid id)
        {
            var categoryViewModel = new CategoryViewModel
            {
                Category = _categoryRepo.FindByID(id),
                SelectedStrings = new List<SelectedStringsViewModel> 
                                           {
                                                new SelectedStringsViewModel 
                                                { 
                                                    Selected = false,
                                                    Text = "FirstString"
                                                },
                                                new SelectedStringsViewModel 
                                                { 
                                                    Selected = false,
                                                    Text = "SecondString"
                                                }
                                           }
            };
            return View(categoryViewModel);
        }

        public PartialViewResult EditCategory(Guid id)
        {
            var categoryViewModel = new CategoryViewModel
            {
                Category = _categoryRepo.FindByID(id),
                SelectedStrings = new List<SelectedStringsViewModel> 
                                           {
                                                new SelectedStringsViewModel 
                                                { 
                                                    Selected = false,
                                                    Text = "FirstString"
                                                },
                                                new SelectedStringsViewModel 
                                                { 
                                                    Selected = false,
                                                    Text = "SecondString"
                                                }
                                           }
            };
            return PartialView("_EditCategoryViewModel", categoryViewModel);
        }

        //
        // POST: /Category/Edit/
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                var selectedString = categoryVM.SelectedStrings;
                _categoryRepo.Save(categoryVM.Category);
                TempData["message"] = string.Format("{0} was saved.", categoryVM.Category.Name);
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }
    }
}
