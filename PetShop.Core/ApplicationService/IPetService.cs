using PetShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();

        //New Pets
        Pet addPet(string name, string type, DateTime birthdate,
            DateTime soldDate, string color, Owner previousOwner, double price);

        //Create
        Pet CreatePet(Pet pet);

        //Delete
        void DeletePet(int id);


        Pet FindPetById(int id);
        List<Pet> SortByName(string name);
        List<Pet> SortByType(string type);
        List<Pet> SortByPrice();
        List<Pet> Get5CheapestPets();
        List<Pet> GetAllByType(string type);


        //Update
        Pet EditPet(Pet petEdit);
    }
}
