
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        //Create
        Owner Create(Owner owner);

        //Read
        Owner ReadById(int id);
        IEnumerable<Owner> ReadAll();

        //Update 
        Owner Update(Owner ownerUpdate);

        //Delete
        void Delete(int id);

        Owner ReadByIdIncludePets(int i);
    }
}
