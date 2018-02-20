using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.cs;

namespace Zoo.Models
{
 public    class ZooContext:DbContext
    {
        public DbSet<Animal> animals { get; set; }
        public DbSet<Food>foods{ get; set; }
        public DbSet<AnimalFood> animalfoods { get; set; }

     
    }
}
