using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.cs
{
   public  class Food
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
        [Display(Name = "Food Name")]
        public string Name { get; set; }
        [Required]
        public float  Price { get; set; }
        public virtual ICollection<AnimalFood> animalfood { get; set; }
    }
}
