using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            pet.PetID = FakeDB.id++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }

        public void DeletePet(int id)
        {
            var pets = FakeDB.Pets.ToList();
            var petDelete = pets.FirstOrDefault(pet => pet.PetID == id);
            pets.Remove(petDelete);
            FakeDB.Pets = pets;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }
    }
}
