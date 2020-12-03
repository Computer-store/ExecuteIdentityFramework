using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ExecuteIdentityFramework.DAO;
using System.Configuration;
using System.Data.Entity;
using ExecuteIdentityFramework.ComputerStore.DAO;

namespace ExecuteIdentityFramework.DAO
{
    public class WorkWithDatabase
    {
        private string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                if (value.Length != 0)
                {
                    _ConnectionString = value;
                }
            }
        }
        public MongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }

        public WorkWithDatabase()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString;
            
            Client = new MongoClient(ConnectionString);

            Database = Client.GetDatabase("ComputerStore");

        }
        //------------------------//
        //-----------------------//
        public 
        //public DbSet<PayMethods> PayMethodsContext { get; set; }
        //public DbSet<SupplerCompanies> SupplerCompaniesContext { get; set; }
        //public DbSet<Users> UsersContext { get; set; }
        //public DbSet<Positions> PositionContext { get; set; }
        //public DbSet<Basket> BasketContext { get; set; }
        //public DbSet<Orders> OrdersContext { get; set; }
        //public DbSet<Products> ProductsContext { get; set; }


    }
}