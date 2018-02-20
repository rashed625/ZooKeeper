using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.cs;

namespace ZooAppViewModels
{
   public  class ViewTotalFood
    {
        public ViewTotalFood()
            {
            
            }

        public ViewTotalFood (AnimalFood animalfoods)
        {
            FoodName = animalfoods.food.Name;
            FoodPrice = animalfoods.food.Price;
            TotalQuantity = animalfoods.animal.Quantity * animalfoods.Quantity;

            TotalPrice = FoodPrice * TotalQuantity;
            Id = animalfoods.Id;
            FoodId = animalfoods.foodId;
        }
        public int Id { get; set; }
        public int FoodId { get; set; }
        [Display(Name = "Food Name")]
        public string   FoodName { get; set; }
        [Display(Name = "Food Price")]
        public double    FoodPrice { get; set; }
        [Display(Name = "Total Quantity")]
        public double TotalQuantity { get; set; }
        [Display(Name = "Total Price")]
        public double  TotalPrice { get; set; }
    }
}
