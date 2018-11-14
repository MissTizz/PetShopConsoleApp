using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet addPet(string name, string type, DateTime birthdate, 
            DateTime soldDate, string color, Owner previousOwner, double price)
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
            return _petRepository.ReadPets()
                .OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> SortByPrice()
        {
            return _petRepository.ReadPets().OrderBy(pet => pet.Price).ToList();
        }

        public List<Pet> GetAllByType(string type)
        {
            var list = _petRepository.ReadPets();

            var queryContinued = list.Where(pet => pet.Type.Equals(type));

            return queryContinued.ToList();
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> SortByName(string name)
        {
            return _petRepository.ReadPets().Where(pet => pet.Name.Contains(name)).ToList();
        }

        public List<Pet> SortByType(string type)
        {
            return _petRepository.ReadPets().Where(pet => pet.Type.Contains(type)).ToList();
        }

        public Pet EditPet(Pet petEdit)
        {
            var pet = FindPetById(petEdit.PetId);
            pet.Name = petEdit.Name;
            pet.Type = petEdit.Type;
            pet.Birthdate = petEdit.Birthdate;
            pet.SoldDate = petEdit.SoldDate;
            pet.Color = petEdit.Color;
            pet.PreviousOwner = petEdit.PreviousOwner;
            pet.Price = petEdit.Price;
            _petRepository.Update(pet);
            return pet;
        }

        public Pet FindPetById(int id)
        {
            return _petRepository.ReadyById(id);
        }
    }
}
