using System;
using System.Collections.Generic;
using System.Text;

namespace HotelMgmt.ConsoleApp
{
    class MainScreenFactory
    {
        public MainScreen GetObject(int choice)
        {
            switch (choice)
            {
                case (int)Options.Roomtypes:
                    return new ManageRoomtypes();
                case (int)Options.Rooms:
                    return new ManageRooms();
                case (int)Options.Customers:
                    return new ManageCustomers();
                case (int)Options.Services:
                    return new ManageServices();

            }
            return null;
        }
    }
}
