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

        public override void Run()
        {
            PrintAll();
        }
    }
}
