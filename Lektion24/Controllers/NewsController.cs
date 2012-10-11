using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion24.Models.Entities;
using Lektion24.Models.Contexts;
using Lektion24.Models.Repositories.Abstract;

namespace Lektion24.Controllers
{ 
    public class NewsController : Controller
    {
        public IRepository<News> _newsRepo;
        public IRepository<Category> _categoryRepo;
        public NewsController(IRepository<News> newsRepo,
                              IRepository<Category> categoryRepo)
        {
            _newsRepo = newsRepo;
            _categoryRepo = categoryRepo;
        }

        //
        // GET: /News/

        public ViewResult Index()
        {
            var news = _newsRepo.FindAll().OrderBy(n => n.Title).ToList();
            return View(news);
        }

        //
        // GET: /News/Details/5

        public ViewResult Details(Guid id)
        {
            News news = _newsRepo.FindByID(id);
            return View(news);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_categoryRepo.FindAll().OrderBy(c => c.Name).ToList(), "ID", "Name");
            return View();
        } 

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.ID = Guid.NewGuid();
                _newsRepo.Save(news);
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryID = new SelectList(_categoryRepo.FindAll().OrderBy(c => c.Name).ToList(), "ID", "Name", news.CategoryID);
            return View(news);
        }
        
        //
        // GET: /News/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            News news = _newsRepo.FindByID(id);
            ViewBag.CategoryID = new SelectList(_categoryRepo.FindAll().OrderBy(c => c.Name).ToList(), "ID", "Name", news.CategoryID);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                _newsRepo.Save(news);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(_categoryRepo.FindAll().OrderBy(c => c.Name).ToList(), "ID", "Name", news.CategoryID);
            return View(news);
        }

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            News news = _newsRepo.FindByID(id);
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            News news = _newsRepo.FindByID(id);
            _newsRepo.Delete(news);
            return RedirectToAction("Index");
        }
    }
}