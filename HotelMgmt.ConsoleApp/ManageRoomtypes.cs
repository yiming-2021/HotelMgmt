using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using HotelMgmt.Data.Repository;

namespace HotelMgmt.ConsoleApp
{
    class ManageRoomtypes: MainScreen
    {
        IRepository<Roomtypes> roomtypesRepository;
        public ManageRoomtypes()
        {
            roomtypesRepository = new RoomtypesRepository();
        }

        void PrintAll()
        {
            var collection = roomtypesRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{ item.Id} \t {item.RTDESC } \t {item.Rent }");
            }
        }


        void AddRoomtypes()
        {
            Roomtypes rt = new Roomtypes();

            Console.Write("Enter Roomtype Description = ");
            rt.RTDESC = Console.ReadLine();
            Console.Write("Enter Rent = ");
            rt.Rent = Convert.ToInt32(Console.ReadLine());

            roomtypesRepository.Insert(rt);
            Console.WriteLine("Roomtype has been added successfully");

        }


        void DeleteRoomtypes()
        {
            Roomtypes rt = new Roomtypes();
            Console.Write("Enter Id to delete= ");
            int Id = Convert.ToInt32(Console.ReadLine());

            int n = roomtypesRepository.Delete(Id);

            if (n>0)
                Console.WriteLine("Roomtype deleted.");

        }


        //public override void Run()
        //{
        //    PrintAll();

        //}

        public override void Run()
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Menu m = new Menu();
                choice = m.Print(typeof(Operations));
                switch (choice)
                {
                    case (int)Operations.Add:
                        AddRoomtypes();
                        break;
                    case (int)Operations.Delete:
                        DeleteRoomtypes();
                        break;
                    case (int)Operations.Print:
                        PrintAll();
                        break;
                    case (int)Operations.Exit:
                        Console.WriteLine("Thanks for visit!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine("Press Enter to continue.....");
                Console.ReadLine();
            } while (choice != (int)Operations.Exit);
        }
    }
}
