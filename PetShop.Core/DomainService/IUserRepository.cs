using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface IUserRepository
    {
        User GetUser(string username);
    }
}
