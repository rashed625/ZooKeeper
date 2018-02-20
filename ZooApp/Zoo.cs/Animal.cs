using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.cs;

namespace Zoo.Models
{
    public class Animal

    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        [StringLength(20)]
        [Index(IsUnique =true)]
        [Display(Name = "Animal Name")]

        public string  Name { get; set; }
        public string  Origin { get; set; }
        [Required]
        [Display(Name = "Quantity(Animal)")]

        public int Quantity { get; set; }
        public virtual  ICollection<AnimalFood> animalfood { get; set; }
    }
   
  
}
