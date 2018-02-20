using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Zoo.Models;
using Zoo.cs;
using ZooAppViewModels;

namespace AnimalService
{
     public class AnimalFoodService
    {
        private ZooContext db = new ZooContext();
        public List<ViewTotalFood> GetTotalFoods()
        {
            IQueryable< System.Linq.IGrouping < int,AnimalFood >> animalFoodGroups = db.animalfoods.GroupBy(x => x.foodId);
            IQueryable<ViewTotalFood> totalFoods =
                from foodGroup in animalFoodGroups
                let totalQuantity = foodGroup.Sum(x => x.animal.Quantity * x.Quantity)
                let foods = foodGroup.FirstOrDefault()
                select new ViewTotalFood()
                {
                    FoodPrice = foods.food.Price,
                    FoodName = foods.food.Name,
                    TotalQuantity = totalQuantity,
                    TotalPrice = foods.food.Price * totalQuantity,
                    Id=foods.Id,
                    FoodId=foods.foodId
                };
            return totalFoods.ToList();

        }
        public List<ViewFoodAnimalTotal> GetViewTotalFoodsByFood(int foodsId)
        {
          IQueryable<AnimalFood> animalFoods= db.animalfoods.Where(x => x.foodId==foodsId);
            var totals = animalFoods.Select(animalfood => new ViewFoodAnimalTotal()
            {
                Id = animalfood.Id,
            AnimalName = animalfood.animal.Name,
            TotalQuantity = animalfood.Quantity * animalfood.animal.Quantity,
            TotalPrice = animalfood.Quantity * animalfood.animal.Quantity * animalfood.food.Price
        }).ToList();
            return totals;

           

        }
    }
}
