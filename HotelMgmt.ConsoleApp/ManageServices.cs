using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using HotelMgmt.Data.Repository;

namespace HotelMgmt.ConsoleApp
{
    class ManageServices: MainScreen
    {
        IRepository<Services> servicesRepository;
        public ManageServices()
        {
            servicesRepository = new ServicesRepository();
        }

        void PrintAll()
        {
            var collection = servicesRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{ item.Id} \t {item.ROOMNO } \t {item.SDESC }\t {item.AMOUNT }\t {item.ServiceDate }");
            }
        }

        void AddServices()
        {
            Services sv = new Services();

            Console.Write("Enter Room Num = ");
            sv.ROOMNO = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Service Desciption = ");
            sv.SDESC = Console.ReadLine();
            Console.Write("Enter Amount = ");
            sv.AMOUNT = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Service Date = ");
            sv.ServiceDate = Convert.ToDateTime(Console.ReadLine());

            servicesRepository.Insert(sv);
            Console.WriteLine("Service has been added successfully");

        }


        void DeleteServices()
        {
            Rooms rt = new Rooms();
            Console.Write("Enter Id to delete= ");
            int Id = Convert.ToInt32(Console.ReadLine());

            int n = servicesRepository.Delete(Id);

            if (n > 0)
                Console.WriteLine("Service deleted.");

        }



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
                        AddServices();
                        break;
                    case (int)Operations.Delete:
                        DeleteServices();
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
