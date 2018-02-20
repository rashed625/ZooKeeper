using AnimalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoo.cs;
using ZooAppViewModels;

namespace ZooApp.MVCClient.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        FoodService service = new FoodService();
        public ActionResult Index()
        {
            var ViewFoods = service.GetAll();
            return View(ViewFoods);
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {
            var detailFood = service.Get(id);
            return View(detailFood);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(Food foods)
        {
            service.save(foods);
            return RedirectToAction("Index");
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int id)
        {
            service.GetdbModel(id);
            return View();
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(Food  foods)
        {
            bool update = service.Update(foods );
            return RedirectToAction("Index");
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = service.GetdbModel(id);

            return View(delete);
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(Food food)
        {
            bool delete = service.Delete(food );
            return RedirectToAction("Index");
        }
    }
}
