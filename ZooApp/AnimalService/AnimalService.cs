using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Models;
using ZooAppViewModels;

namespace AnimalService
{
    public class AnimalServices
    {
        ZooContext db = new ZooContext();
        public List<ViewAnimal> GetAll()
        {
            //create db object

            //fetch db.animal data
            //pulls all data from database into ram
            List<Animal> animals = db.animals.ToList();
            //converting data into viewdata
            List<ViewAnimal> ViewAnimals = new List<ViewAnimal>();
            foreach (Animal animal in animals)
            {
                ViewAnimal viewanimals = new ViewAnimal()
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Quantity = animal.Quantity,
                    Origin = animal.Origin,
                  

                };
                ViewAnimals.Add(viewanimals);

            }
            //return
            return ViewAnimals;
        }

     

        public ViewAnimal Get(int? id)
        {
            Animal animal = db.animals.Find(id);
            return new ViewAnimal()
            {
                Id = animal.Id,
                Name = animal.Name,
              Quantity=animal .Quantity,
                Origin = animal.Origin,
               

            };

        }

      

        public Animal save(Animal animal)
        {

            animal = db.animals.Add(animal);
            db.SaveChanges();
            return (animal);


        }
        public bool  Update(Animal animal)
        {
            
            db.Entry(animal).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true ;
           

        }
        public bool  Delete(Animal animal)
        {
            Animal dbanimal = db.animals.Find(animal.Id);
            db.animals.Remove(dbanimal);
            db.SaveChanges();
            return true ;
        }


        public Animal    GetdbModel(int id)
        {
            return  db.animals.Find(id);
        }
    }
}