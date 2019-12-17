using System;
using System.Collections.Generic;

namespace DogShelter.Models
{
    public class Dog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Adoption> Adoptions { get; set; }
    }
}