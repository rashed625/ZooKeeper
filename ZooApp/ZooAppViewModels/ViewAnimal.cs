using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.cs;

namespace ZooAppViewModels
{
  public   class ViewAnimal
    {
        public int Id { get; set; }
        [Display(Name = "Animal Name")]
        public string Name { get; set; }
        [Display(Name = "Quantity(Animal)")]


        public int  Quantity { get; set; }
        public string Origin { get; set; }
      
    }
    public class ViewFood
    {
      
        public int Id { get; set; }
        [Display(Name = "Food Name")]
        public string Name { get; set; }
        public float  Price { get; set; }

    }
}
