using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();

        Pet addPet(String name, String type, DateTime birthdate,
            DateTime soldDate, String color, String previousOwner, double price);

        Pet CreatePet(Pet pet);

        void DeletePet(int Id);

        List<Pet> SortByName(String name);

        List<Pet> SortByType(String type);

        List<Pet> SortByPrice();

        List<Pet> Get5CheapestPets();

        Pet EditPet(int id);
    }
}
