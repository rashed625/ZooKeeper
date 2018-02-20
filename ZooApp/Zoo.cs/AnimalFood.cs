using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Models;

namespace Zoo.cs
{
    public class AnimalFood

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        [ForeignKey("animal")]
        [Required]
       
        public int animalId { get; set; }
        
        public virtual Animal animal { get; set; }
        [ForeignKey("food")]
        [Required]
      
        public int foodId { get; set; }
        

        public virtual Food food { get; set; }
        [Required]
        [Display(Name = "Food Quantity(KG)")]
        public float Quantity { get; set; }
    }
}
