using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogBirthday.Models
{
    public class DogBirthdayContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DogBirthdayContext() : base("name=DogBirthdayContext")
        {
        }

        public System.Data.Entity.DbSet<DogBirthday.Models.Dog> Dogs { get; set; }

        public System.Data.Entity.DbSet<DogBirthday.Models.Breed> Breeds { get; set; }
    }
}
