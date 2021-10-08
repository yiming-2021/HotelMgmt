using System;
using System.Collections.Generic;
using System.Text;
using HotelMgmt.Data.Model;
using Dapper;
using System.Data;

namespace HotelMgmt.Data.Repository
{
    public class ServicesRepository : IRepository<Services>
    {
        HotelDbContext db;

        public ServicesRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Delete from Services where Id = @Id", new { Id = id });
        }

        public IEnumerable<Services> GetAll()
        {
            IDbConnection conn = db.GetConnection();
            return conn.Query<Services>("Select * from Services");
        }

        public Services GetById(int id)
        {
            IDbConnection conn = db.GetConnection();
            return conn.QueryFirstOrDefault<Services>("Select * from Services where Id = @Id", new { Id = id });
        }

        public int Insert(Services item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Insert into Services values (@ROOMNO, @SDESC, @AMOUNT, @ServiceDate)", item);
        }

        public int Update(Services item)
        {
            IDbConnection conn = db.GetConnection();
            return conn.Execute("Update Services set  ROOMNO=@ROOMNO, SDESC=@SDESC, AMOUNT=@AMOUNT, ServiceDate=@ServiceDate where Id = @Id)", item);
        }
    }
}
