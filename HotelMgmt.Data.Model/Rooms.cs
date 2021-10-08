using System;
using System.Collections.Generic;
using System.Text;

namespace HotelMgmt.Data.Model
{
    public class Rooms
    {
        public int Id { get; set; }
        public int RTCODE { get; set; }
        public bool? STATUS { get; set; }

        public Roomtypes Roomtypes { get; set; }
    }
}
