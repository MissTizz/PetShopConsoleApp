using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        Pet CreatePet(Pet pet);

        void DeletePet(int Id);

    }
}
