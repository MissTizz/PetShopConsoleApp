using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var owner1 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Tina",
                LastName = "´Jønsson",
                Address = "DinMorVej 22",
                Email = "TJ@hotmail.com",
                PhoneNumber = "6969696969"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Jesper",
                LastName = "Riis",
                Address = "DinFarVej 69",
                Email = "JBR@hotmail.com",
                PhoneNumber = "9696969696"
            }).Entity;

            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Rogue",
                Type = "Cat",
                Birthdate = new DateTime(2014, 07, 31),
                SoldDate = new DateTime(2017, 03, 21),
                Color = "Cream",
                PreviousOwner = owner1,
                Price = 25,
            }).Entity;

            var pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Leo",
                Type = "Løve",
                Birthdate = new DateTime(2014, 07, 31),
                SoldDate = new DateTime(2017, 03, 21),
                Color = "Lyserød",
                PreviousOwner = owner2,
                Price = 343423,
            }).Entity;

            string password = "1234";
            byte[] passwordHashUser, passwordSaltUser, passwordHashAdmin, passwordSaltAdmin;
            CreatePasswordHash(password, out passwordHashUser, out passwordSaltUser);
            CreatePasswordHash(password, out passwordHashAdmin, out passwordSaltAdmin);

            List<User> users = new List<User>
            {
                new User {
                    UserName = "User",
                    PasswordHash = passwordHashUser,
                    PasswordSalt = passwordSaltUser,
                    IsAdmin = false
                },
                new User {
                    UserName = "Admin",
                    PasswordHash = passwordHashAdmin,
                    PasswordSalt = passwordSaltAdmin,
                    IsAdmin = true
                }
            };

            ctx.AddRange(users);
            ctx.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
