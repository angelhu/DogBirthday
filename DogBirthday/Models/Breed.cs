using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBirthday.Models
{
    public class Breed
    {
        public int BreedID { get; set; }
        [Display(Name = "Breed")]
        public string Description { get; set; }

    }
}