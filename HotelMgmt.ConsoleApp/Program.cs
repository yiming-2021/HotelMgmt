using System;

namespace HotelMgmt.ConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ManageRoomtypes manageRoomtypes = new ManageRoomtypes();
//            manageRoomtypes.Run();

//            ManageRooms manageRooms = new ManageRooms();
//            manageRooms.Run();

//            ManageCustomers manageCustomers = new ManageCustomers();
//            manageCustomers.Run();

//            ManageServices manageServices = new ManageServices();
//            manageServices.Run();
//        }
//    }
//}


{
    class Program
    {
        static void Main(string[] args)
        {

            Dashboard dashboard = new Dashboard();
            dashboard.ShowDashboard();
        }
    }
}