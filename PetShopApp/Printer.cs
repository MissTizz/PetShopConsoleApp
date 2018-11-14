using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp
{
    class Printer
    {
        string[] menuItems =
           {
                "List of all pets",
                "Search for a pet by name",
                "Search for a pet by type",
                "Sort pets by price",
                "Get the 5 cheapest pets",
                "Add a pet",
                "Delete a pet",
                "Edit a pet",
                "Exit the program"
            };

        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;

            MenuSelection();
        }

        void ListAllPets(List<Pet> pets)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\tYou can see all the pets here :)" + Environment.NewLine);
            Console.ResetColor();

            foreach (var pet in pets)
            {
                PetCaller(pet);
            }

            Console.Write("\n\nType ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Menu");
            Console.ResetColor();
            Console.Write(" to get back to main menu" + Environment.NewLine);

            while (!Console.ReadLine().Equals("Menu"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't regonize your input. Try again!");
                Console.ResetColor();
            }
            Console.Clear();
            MenuSelection();
        }

        public void MenuSelection()
        {
            var selection = ShowMenu(menuItems);

            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        ListAllPets(pets);
                        break;
                    case 2:
                        SearchPetByName();
                        break;
                    case 3:
                        SearchPetByType();
                        break;
                    case 4:
                        SortPetsByPrice();
                        break;
                    case 5:
                        CheapestPets();
                        break;
                    case 6:
                        AddPet();
                        break;
                    case 7:
                        DeletePet();
                        break;
                    case 8:
                        EditPet();
                        break;
                    default:
                        break;
                }
                selection = 0;
            }
        }

        private void EditPet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\tYou can edit a pet here!" + Environment.NewLine);
            Console.WriteLine("Just enter the pets ID, and follow the steps :)" + Environment.NewLine);
            Console.ResetColor();

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Can't register the ID number, please try again!");
            }
            var pet = _petService.EditPet(id);
            if (pet != null)
            {
                PetCaller(pet);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nDo you want to edit this pet? Type Y/N");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nCould not find a pet with that ID, press enter to return to main menu");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                MenuSelection();
            }

            var ReadLine = Console.ReadLine();

            if (ReadLine.Equals("Y"))
            {

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew pet Name: ");
                    Console.ResetColor();
                    pet.Name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew pet Type: ");
                    Console.ResetColor();
                    pet.Type = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew pet Birthday: ");
                    Console.ResetColor();
                    pet.Birthdate = DateChecker();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew pet Sold Date: ");
                    Console.ResetColor();
                    pet.SoldDate = DateChecker();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew pet Color: ");
                    Console.ResetColor();
                    pet.Color = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew pet Previous Owner: ");
                    Console.ResetColor();
                    pet.PreviousOwner = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nNew price of pet: ");
                    Console.ResetColor();
                    pet.Price = PriceCheck();
                    Console.Clear();
                    MenuSelection();
            }
            else if (ReadLine.Equals("N"))
            {
                Console.Clear();
                MenuSelection();
            }
            else
            {
                Console.WriteLine("Please type Y for yes, and N for no");
                ReadLine = Console.ReadLine();
            }

            Console.Clear();
            MenuSelection();
        }

        private void DeletePet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\tYou can delete a pet here!" + Environment.NewLine);
            Console.WriteLine("Just enter the ID of the pet, that you want to delete :)" + Environment.NewLine);
            Console.ResetColor();

            var id = FindPetId();

                _petService.DeletePet(id);
                Console.WriteLine("Pet with the id {0} has been deleted", id);
                Console.ReadLine();
            
            Console.Clear();
            MenuSelection();
        }

        private void AddPet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\tYou can add a pet here!" + Environment.NewLine);
            Console.WriteLine("Just follow the steps, and I will add the pet for you :)" + Environment.NewLine);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nType the pet name");
            Console.ResetColor();
            Console.WriteLine("Pet Name: ");
            var petName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nType the pet type");
            Console.ResetColor();
            Console.WriteLine("Pet Type: ");
            var petType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nType the pet's birthday (dd-mm-yyyy)");
            Console.ResetColor();
            Console.WriteLine("Birth Date: ");
            var birthDate = DateChecker();
            var soldDate = DateTime.Parse("01/1/0001");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nType the pet's color");
            Console.ResetColor();
            Console.WriteLine("Color: ");
            var color = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nType the pet's previous owner");
            Console.ResetColor();
            Console.WriteLine("Previous Owner: ");
            var previousOwner = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nEnter the price of the pet");
            Console.ResetColor();
            Console.WriteLine("Price: ");
            var price = PriceCheck();
            var pet = _petService.addPet(petName, petType, birthDate, soldDate, color, previousOwner, price);
            _petService.CreatePet(pet);

            Console.Clear();
            MenuSelection();
        }
        DateTime DateChecker()
        {
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine(Environment.NewLine + "Can't regonize your input. Try again!");
            }
            return dateTime;
        }

        double PriceCheck()
        {
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine(Environment.NewLine + "Can't regonize your input. Try again!");
            }
            return price;
        }

        private int FindPetId()
        {
            Console.WriteLine("Insert the ID of the pet: ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id)
                    || id < 0)
            {
                Console.WriteLine("Can't register the ID number, please try again!");
            }
            return id;
        }

        private void CheapestPets()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\tYou can see the cheapest 5 pets here :)" + Environment.NewLine);
            Console.ResetColor();
            var list = _petService.Get5CheapestPets();
            foreach (var pet in list)
            {
                PetCaller(pet);

            }

            Console.Write("\n\nType ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Menu");
            Console.ResetColor();
            Console.Write(" to get back to main menu" + Environment.NewLine);

            while (!Console.ReadLine().Equals("Menu"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCan't regonize your input. Try again!");
                Console.ResetColor();
            }

            Console.Clear();
            MenuSelection();
        }

        private void SortPetsByPrice()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\tThe pets have been sorted by price :)" + Environment.NewLine);
            Console.ResetColor();

            var list = _petService.SortByPrice();
            foreach (var pet in list)
            { 
                PetCaller(pet);
            }

            Console.Write("\n\nType ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Menu");
            Console.ResetColor();
            Console.Write(" to get back to main menu" + Environment.NewLine);

            while (!Console.ReadLine().Equals("Menu"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCan't regonize your input. Try again!");
                Console.ResetColor();
            }

            Console.Clear();
            MenuSelection();
        }

        private void SearchPetByType()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\t\tYou can search for a pet here!" + Environment.NewLine);
            Console.WriteLine("Type what you recall from the pet type, and I will find the pet for you :)" + Environment.NewLine);
            Console.ResetColor();

            var type = Console.ReadLine();
            var list = _petService.SortByType(type);
            foreach (var pet in list)
            {
                PetCaller(pet);
            }

            Console.Write("\n\nType ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Menu");
            Console.ResetColor();
            Console.Write(" to get back to main menu" + Environment.NewLine);

            while (!Console.ReadLine().Equals("Menu"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCan't regonize your input. Try again!");
                Console.ResetColor();
            }

            Console.Clear();
            MenuSelection();
        }

        private void SearchPetByName()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\t\t\tYou can search for a pet here!" + Environment.NewLine);
            Console.WriteLine("Type what you recall from the pet name, and I will find the pet for you :)" + Environment.NewLine);
            Console.ResetColor();

            var Name = Console.ReadLine();
            var list = _petService.SortByName(Name);
            foreach (var pet in list)
            {
                PetCaller(pet);
            }

            Console.Write("\n\nType ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Menu");
            Console.ResetColor();
            Console.Write(" to get back to main menu" + Environment.NewLine);

            while (!Console.ReadLine().Equals("Menu"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCan't regonize your input. Try again!");
                Console.ResetColor();
            }

            Console.Clear();
            MenuSelection();
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + "\tWelcome to the PetShop menu!" + Environment.NewLine);
            Console.WriteLine("\tPlease select your action: " + Environment.NewLine);
            Console.ResetColor();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} : {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1 || selection > 9)
            {
                Console.WriteLine(Environment.NewLine + "Can't regonize your input. Try again!");
            }
            return selection;
        }

        void PetCaller(Pet pet)
        {
                Console.Write("\nPet ID: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.PetID}");
                Console.ResetColor();
                Console.Write("\nPet Name: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.Name} ");
                Console.ResetColor();
                Console.Write("\nPet Type: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.Type}");
                Console.ResetColor();
                Console.Write("\nPet Birthday ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.Birthdate} ");
                Console.ResetColor();
                Console.Write("\nPet Sold: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.SoldDate} ");
                Console.ResetColor();
                Console.Write("\nPet Color: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.Color} ");
                Console.ResetColor();
                Console.Write("\nPet Previous Owner: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.PreviousOwner} ");
                Console.ResetColor();
                Console.Write("\nPet Price: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{pet.Price}{Environment.NewLine}");
                Console.ResetColor();
        }
    }
}