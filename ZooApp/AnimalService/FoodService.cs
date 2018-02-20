using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Models;
using ZooAppViewModels;
using Zoo.cs;
namespace AnimalService
{
   public  class FoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFood> GetAll()
        {
           
            List<Food > food = db.foods .ToList();
            //converting data into viewdata
            List<ViewFood> Viewfoods = new List<ViewFood>();
            foreach (Food  foods in food )
            {
                ViewFood viewFoods = new ViewFood()
                {
                    Id = foods.Id,
                    Name = foods .Name,
                    Price=foods.Price,
                };
                Viewfoods.Add(viewFoods);

            }
            //return
            return Viewfoods;
        }



        public ViewFood Get(int? id)
        {
            Food  food = db.foods .Find(id);
            return new ViewFood ()
            {
                Id = food .Id,
                Name = food .Name,
                Price =food .Price
   

            };

        }

        public Food  save(Food  Foods)
        {

            db.foods.Add(Foods );
            db.SaveChanges();
            return (Foods );


        }

        public bool Update(Food food)
        {

            db.Entry(food ).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;


        }
        public bool Delete(Food food)
        {
            Food dbfood = db.foods.Find(food .Id);
            db.foods.Remove(dbfood);
            db.SaveChanges();
            return true;
        }


        public Food GetdbModel(int id)
        {
            return db.foods.Find(id);
        }
    }
}
