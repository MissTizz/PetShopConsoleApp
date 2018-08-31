using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static int id = 1;
        public static IEnumerable<Pet> Pets;

        public static void InitData()
        {

            var pet1 = new Pet()
            {
                PetID = id++,
                Name = "Tina",
                Type = "Cow",
                Birthdate = DateTime.Parse("18/4/2012"),
                SoldDate = DateTime.Today,
                Color = "Pink",
                PreviousOwner = "Jesper Riis",
                Price = 1
            };

            var pet2 = new Pet()
            {
                PetID = id++,
                Name = "Tina Turner",
                Type = "Sheep",
                Birthdate = DateTime.Parse("18/4/2010"),
                SoldDate = DateTime.Parse("01/1/0001"),
                Color = "Pink",
                PreviousOwner = "",
                Price = 10
            };

            var pet3 = new Pet()
            {
                PetID = id++,
                Name = "SvansePer",
                Type = "Sheep",
                Birthdate = DateTime.Parse("18/4/2010"),
                SoldDate = DateTime.Parse("01/1/0001"),
                Color = "Pink",
                PreviousOwner = "",
                Price = 5
            };

            var pet4 = new Pet()
            {
                PetID = id++,
                Name = "Klaphat",
                Type = "Sheep",
                Birthdate = DateTime.Parse("18/4/2010"),
                SoldDate = DateTime.Parse("01/1/0001"),
                Color = "Pink",
                PreviousOwner = "",
                Price = 100
            };

            var pet5 = new Pet()
            {
                PetID = id++,
                Name = "Jesper",
                Type = "Lion",
                Birthdate = DateTime.Parse("18/4/2010"),
                SoldDate = DateTime.Parse("01/1/0001"),
                Color = "Pink",
                PreviousOwner = "",
                Price = 2.5
            };

            var pet6 = new Pet()
            {
                PetID = id++,
                Name = "Rogue",
                Type = "Cat",
                Birthdate = DateTime.Parse("18/4/2010"),
                SoldDate = DateTime.Parse("01/1/0001"),
                Color = "Pink",
                PreviousOwner = "",
                Price = 3.5
            };

            var pet7 = new Pet()
            {
                PetID = id++,
                Name = "Tina",
                Type = "Whale",
                Birthdate = DateTime.Parse("18/4/2010"),
                SoldDate = DateTime.Parse("01/1/0001"),
                Color = "Pink",
                PreviousOwner = "",
                Price = 150
            };

            Pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6, pet7 };
        }
    }
}
