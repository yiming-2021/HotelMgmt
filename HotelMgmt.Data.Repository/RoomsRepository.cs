using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using Dapper;
using System.Data;

namespace HotelMgmt.Data.Repository
{
    public class RoomsRepository : IRepository<Rooms>
    {
        HotelDbContext db;

        public RoomsRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Delete from Rooms where Id = @Id", new { Id = id });
        }

        public IEnumerable<Rooms> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<Rooms>("Select Id, RTCODE, STATUS from Rooms");
        }

        public Rooms GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Rooms>("Select Id, RTCODE, STATUS from Rooms where Id = @Id", new { Id = id });
        }

        public int Insert(Rooms item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Insert into Rooms values (@RTCODE, @STATUS)", item);
        }

        public int Update(Rooms item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Update Rooms set RTCODE=@RTCODE, STATUS = @STATUS where Id = @Id)", item);
        }
    }
}
