using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zoo.Models;
using Zoo.cs;
using AnimalService;
using ZooAppViewModels;
namespace ZooApp.MVCClient.Controllers
{
    public class AnimalFoodsController : Controller
    {
        private ZooContext db = new ZooContext();
        AnimalFoodService service = new AnimalFoodService();

        // GET: AnimalFoods
        public ActionResult Index()
        {
            var result = service.GetTotalFoods();
            ViewBag.total = result.Sum(x => x.TotalPrice);
            return View(result);
        }
        public ActionResult IndexDetails(int Id)
        {
            var foodtotals = service.GetViewTotalFoodsByFood(Id);
            ViewBag.total = foodtotals.Sum(x => x.TotalPrice);

            return View(foodtotals);

        }


        // GET: AnimalFoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.animalfoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // GET: AnimalFoods/Create
        public ActionResult Create()
        {
            ViewBag.animalId = new SelectList(db.animals, "Id", "Name");
            ViewBag.foodId = new SelectList(db.foods, "Id", "Name");
            return View();
        }

        // POST: AnimalFoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,animalId,foodId,Quantity")] AnimalFood animalFood)
        {
            if (ModelState.IsValid)
            {
                db.animalfoods.Add(animalFood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.animals, "Id", "Name", animalFood.animalId);
            ViewBag.foodId = new SelectList(db.foods, "Id", "Name", animalFood.foodId);
            return View(animalFood);
        }

        // GET: AnimalFoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.animalfoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.animals, "Id", "Name", animalFood.animalId);
            ViewBag.foodId = new SelectList(db.foods, "Id", "Name", animalFood.foodId);
            return View(animalFood);
        }

        // POST: AnimalFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,animalId,foodId,Quantity")] AnimalFood animalFood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalFood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.animals, "Id", "Name", animalFood.animalId);
            ViewBag.foodId = new SelectList(db.foods, "Id", "Name", animalFood.foodId);
            return View(animalFood);
        }

        // GET: AnimalFoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.animalfoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // POST: AnimalFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalFood animalFood = db.animalfoods.Find(id);
            db.animalfoods.Remove(animalFood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
