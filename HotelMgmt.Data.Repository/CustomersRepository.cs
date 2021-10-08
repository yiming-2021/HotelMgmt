using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using Dapper;
using System.Data;

namespace HotelMgmt.Data.Repository
{
    public class CustomersRepository : IRepository<Customers>
    {
        HotelDbContext db;

        public CustomersRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Delete from Customers where Id = @Id", new { Id = id });
        }

        public IEnumerable<Customers> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<Customers>("Select * from Customers");
        }

        public Customers GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Customers>("Select * from Customers where Id = @Id", new { Id = id });
        }

        public int Insert(Customers item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Insert into Customers values (@ROOMNO, @CNAME, @ADDRESS, @PHONE, @EMAIL, @CHECKIN, @TotalPERSONS, @BookingDays, @ADVANCE)", item);
        }

        public int Update(Customers item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute(@"Update Customers set ROOMNO = @ROOMNO, CNAME = @CNAME, ADDRESS = @ADDRESS, PHONE = @PHONE, EMAIL = @EMAIL,
                                CHECKIN = @CHECKIN, TotalPERSONS = @TotalPERSONS, BookingDays = @BookingDays, ADVANCE = @ADVANCE where Id = @Id)", item);
        }
    }
}
