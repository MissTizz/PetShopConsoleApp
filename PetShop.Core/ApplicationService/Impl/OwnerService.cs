
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepo;
        private readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepository;
            _petRepo = petRepository;
        }

        public Owner NewOwner(string FirstName, string LastName,
            string Address, string PhoneNumber, string Email)
        {
            //Create
            var owner = new Owner()
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
            return owner;
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepo.ReadByIdIncludePets(id);
            return owner;
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public Owner EditOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById((ownerUpdate.OwnerId));
            owner.FirstName = ownerUpdate.FirstName;
            owner.LastName = ownerUpdate.LastName;
            owner.Address = ownerUpdate.Address;
            owner.PhoneNumber = ownerUpdate.PhoneNumber;
            owner.Email = ownerUpdate.Email;
            _ownerRepo.Update(owner);
            return owner;
        }

        public void DeleteOwner(int id)
        {
            _ownerRepo.Delete(id);
        }
    }
}
