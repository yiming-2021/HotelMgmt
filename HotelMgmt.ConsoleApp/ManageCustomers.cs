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

        public override void Run()
        {
            PrintAll();
        }
    }
}
