using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using HotelMgmt.Data.Repository;

namespace HotelMgmt.ConsoleApp
{
    class ManageRooms: MainScreen

    {
        IRepository<Rooms> roomsRepository;
        public ManageRooms()
        {
            roomsRepository = new RoomsRepository();
        }

        void PrintAll()
        {
            var collection = roomsRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{ item.Id} \t {item.RTCODE } \t {item.STATUS }");
            }
        }



        void AddRooms()
        {
            Rooms rooms = new Rooms();

            Console.Write("Enter Roomtype code = ");
            rooms.RTCODE = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Status = ");
            rooms.STATUS = Convert.ToBoolean(Console.ReadLine());

            roomsRepository.Insert(rooms);
            Console.WriteLine("Room has been added successfully");

        }


        void DeleteRooms()
        {
            Rooms rt = new Rooms();
            Console.Write("Enter Id to delete= ");
            int Id = Convert.ToInt32(Console.ReadLine());

            int n = roomsRepository.Delete(Id);

            if (n > 0)
                Console.WriteLine("Room deleted.");

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
                        AddRooms();
                        break;
                    case (int)Operations.Delete:
                        DeleteRooms();
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
