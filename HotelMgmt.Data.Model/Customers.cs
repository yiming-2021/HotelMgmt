using System;
using System.Collections.Generic;
using System.Text;

namespace HotelMgmt.Data.Model
{
    public class Customers
    {
        public int Id { get; set; }
        public int ROOMNO { get; set; }
        public string CNAME { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public DateTime CHECKIN { get; set; }
        public int TotalPERSONS { get; set; }
        public int BookingDays { get; set; }
        public decimal? ADVANCE { get; set; }

        public Rooms Rooms { get; set; }

    } 
}
