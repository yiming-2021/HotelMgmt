using System;
using System.Collections.Generic;
using System.Text;

namespace HotelMgmt.ConsoleApp
{
    class Dashboard
    {
        public void ShowDashboard()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Hotel Management";

            Menu m = new Menu();
            int choice = m.Print(typeof(Options));
            MainScreenFactory factory = new MainScreenFactory();
            MainScreen ms = factory.GetObject(choice);
            if (ms != null)
            {
                ms.Run();
            }

        }
    }
}
