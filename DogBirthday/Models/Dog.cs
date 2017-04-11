using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBirthday.Models
{
    public class Dog
    {
        public int DogID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Gender")]
        public virtual Gender DogGender { get; set; }
        public DateTime Birthday { get; set; }

        [Display(Name = "Breed")]
        public int BreedID { get; set; }
        public virtual Breed DogBreed { get; set; }

        public string Owner { get; set; }

    }
}