using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using HotelMgmt.Data.Repository;

namespace HotelMgmt.ConsoleApp
{
    class ManageCustomers:MainScreen
    {
        IRepository<Customers> customersRepository;
        public ManageCustomers()
        {
            customersRepository = new CustomersRepository();
        }

        void PrintAll()
        {
            var collection = customersRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{ item.Id} \t {item.ROOMNO } \t {item.CNAME }\t {item.ADDRESS }\t {item.PHONE }\t {item.EMAIL }\t {item.CHECKIN }\t {item.TotalPERSONS }\t {item.BookingDays }\t {item.ADVANCE }");
            }
        }

        void AddCustomers()
        {
            Customers c = new Customers();

            Console.Write("Enter Room Num = ");
            c.ROOMNO = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Name = ");
            c.CNAME = Console.ReadLine();
            Console.Write("Enter Address = ");
            c.ADDRESS = Console.ReadLine();
            Console.Write("Enter Phone num = ");
            c.PHONE = Console.ReadLine();
            Console.Write("Enter Email = ");
            c.EMAIL = Console.ReadLine();
            Console.Write("Enter Check in date = ");
            c.CHECKIN = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Total Persons = ");
            c.TotalPERSONS = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Booking days = ");
            c.BookingDays = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Booking days = ");
            c.ADVANCE = Convert.ToDecimal(Console.ReadLine());


            customersRepository.Insert(c);
            Console.WriteLine("Customer has been added successfully");

        }


        void DeleteCustomers()
        {
            Customers c = new Customers();
            Console.Write("Enter Id to delete= ");
            int Id = Convert.ToInt32(Console.ReadLine());

            int n = customersRepository.Delete(Id);

            if (n > 0)
                Console.WriteLine("Customer deleted.");

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
                        AddCustomers();
                        break;
                    case (int)Operations.Delete:
                        DeleteCustomers();
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
