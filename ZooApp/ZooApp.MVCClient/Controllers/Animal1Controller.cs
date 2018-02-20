using System.Web.Mvc;
using AnimalService;
using Zoo.Models;

namespace ZooApp.MVCClient.Controllers
{
    public class Animal1Controller : Controller
    {
        // GET: Animal1
        AnimalServices services = new AnimalServices();
        public ActionResult Index()
        {
          
            var viewanimal = services.GetAll();
            return View  (viewanimal);
            
        }
        public ActionResult Details(int ? id)
        {

            var detailsanimal = services.Get(id);
            return View(detailsanimal);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            services.save(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            services.GetdbModel(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Animal  animal)
        {
           bool update= services.Update(animal);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
         var  delete=  services.GetdbModel(id);
           
            return View(delete);
        }
        [HttpPost]
        public ActionResult Delete(Animal  animal)
        {
            bool delete=services.Delete(animal);
            return RedirectToAction("Index");
        }

    }
}