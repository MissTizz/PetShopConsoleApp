using System;
using System.Collections.Generic;

namespace PetShop.Core.Entities
{
    public class Pet
    {
        public int PetId { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime SoldDate { get; set; }

        public double Price { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public Owner PreviousOwner { get; set; }
    }
}
