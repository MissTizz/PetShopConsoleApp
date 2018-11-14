using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetShopAppContext _ctx;


        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {
            var owner1 =_ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return owner1;
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.Include(o => o.Pets).
                FirstOrDefault(o => o.OwnerId == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner ownerUpdate)
        {
            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.Entry(ownerUpdate).Collection(o => o.Pets).IsModified = true;
            _ctx.SaveChanges();

            return ownerUpdate;
        }

        public void Delete(int id)
        {
            var ownerRemove = _ctx.Remove(new Owner() { OwnerId = id }).Entity;
            _ctx.SaveChanges();
        }

        public Owner ReadByIdIncludePets(int id)
        {
            var owner = _ctx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.OwnerId == id);
            return owner;
        }
    }
}
