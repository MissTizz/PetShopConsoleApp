using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        IEnumerable<Pet> Pets;
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet addPet(string name, string type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthdate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public void DeletePet(int Id)
        {
            _petRepository.DeletePet(Id);
        }

        public List<Pet> Get5CheapestPets()
        {
            Pets = new List<Pet>();
            var pet = Pets.ToList();
            pet.Clear();
            var list = _petRepository.ReadPets().ToList();
            foreach (var pets in list)
            {
                if(pets.SoldDate.Year == 0001)
                {
                    pet.Add(pets);
                }
            }
            return pet.OrderBy(pets => pets.Price).Take(5).ToList();
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> SortByName(string name)
        {
            return _petRepository.ReadPets().Where(pet => pet.Name.Contains(name)).ToList();
        }

        public List<Pet> SortByPrice()
        {
            return _petRepository.ReadPets().OrderByDescending(pet => pet.Price).ToList();
        }

        public List<Pet> SortByType(string type)
        {
            return _petRepository.ReadPets().Where(pet => pet.Type.Contains(type)).ToList();
        }

        public Pet EditPet(int id)
        {
            var list = _petRepository.ReadPets().ToList();
            foreach (var pets in list)
            {
                if(pets.PetID == id)
                {
                    return pets;
                }
            }
            return null;
        }
    }
}
