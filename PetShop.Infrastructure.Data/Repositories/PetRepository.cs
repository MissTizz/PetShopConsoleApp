using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet ReadyById(int id)
        {
            return _ctx.Pets
                .Include(pet => pet.PreviousOwner)
                .FirstOrDefault(pet => pet.PetId == id);
        }

        public Pet Update(Pet petUpdate)
        { 
            _ctx.Attach(petUpdate).State = EntityState.Modified;
            _ctx.Entry(petUpdate).Reference(p => p.PreviousOwner).IsModified = true;
            _ctx.SaveChanges();

            return petUpdate;
        }

        public void DeletePet(int id)
        {
            var petDelete = _ctx.Remove(new Pet() { PetId = id }).Entity;
            _ctx.SaveChanges();
        }
    }
}
