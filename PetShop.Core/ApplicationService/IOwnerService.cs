
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Impl
{
    public interface IOwnerService
    {
        //New Owner
        Owner NewOwner(string FirstName, string LastName,
            string Address, string PhoneNumber, string Email);

        //Create
        Owner CreateOwner(Owner owner);

        //Read
        Owner FindOwnerById(int id);
        Owner FindOwnerByIdIncludePets(int id);

        List<Owner> GetAllOwners();

        //Update
        Owner EditOwner(Owner ownerUpdate);

        //Delete
        void DeleteOwner(int id);
    }
}
