using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService
{
    public interface IUserService
    {
        User GetUser(string username);
    }
}
