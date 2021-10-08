using System;
using System.Collections.Generic;
using System.Text;

namespace HotelMgmt.Data.Model
{
    public class Services
    {
        public int Id { get; set; }
        public int ROOMNO { get; set; }
        public string SDESC { get; set; }
        public decimal? AMOUNT { get; set; }
        public DateTime ServiceDate { get; set; }

        public Rooms Rooms { get; set; }
    }
}
