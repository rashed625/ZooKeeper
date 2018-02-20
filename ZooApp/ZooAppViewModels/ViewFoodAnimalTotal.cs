using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.cs;

namespace ZooAppViewModels
{
  public  class ViewFoodAnimalTotal

    {
        public ViewFoodAnimalTotal()
        {
            

        }
        public ViewFoodAnimalTotal( AnimalFood animalfood)
        {
            Id = animalfood.Id;
            AnimalName = animalfood.animal.Name;
            TotalQuantity = animalfood.Quantity * animalfood.animal.Quantity;
            TotalPrice = TotalQuantity * animalfood.food.Price;

        }
        [Display(Name = "Animal Name")]
        public string AnimalName { get; set; }
        public int Id { get; set; }
        [Display(Name = "Total Quantity")]
        public double TotalQuantity { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
       

    }
}
