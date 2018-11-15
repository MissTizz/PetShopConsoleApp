using PetShop.Core.Entities;
using System.Collections.Generic;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        //Read Data
        IEnumerable<Pet> ReadPets(Filter filter = null);
        Pet ReadyById(int id);

        //Create Data
        Pet CreatePet(Pet pet);

        //Update Data
        Pet Update(Pet petUpdate);

        //Delete Data
        void DeletePet(int id);

        int Count();
    }
}
