using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using Dapper;
using System.Data;


namespace HotelMgmt.Data.Repository
{
    public class RoomtypesRepository: IRepository<Roomtypes>
    {
        HotelDbContext db;

        public RoomtypesRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Delete from Roomtypes where Id = @id", new {Id = id });
        }

        public IEnumerable<Roomtypes> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<Roomtypes>("Select Id, RTDESC, Rent from Roomtypes");
        }

        public Roomtypes GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Roomtypes>("Select Id, RTDESC, Rent from Roomtypes where Id = @Id", new { Id = id });
        }

        public int Insert(Roomtypes item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Insert into Roomtypes values (@RTDESC, @Rent)", item);
        }

        public int Update(Roomtypes item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Update Roomtypes set RTDESC=@RTDESC, Rent = @Rent where Id = @Id)", item);
        }
    }
}
