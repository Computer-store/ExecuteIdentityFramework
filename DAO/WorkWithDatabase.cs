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
        public WorkWithDatabase()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString;


        }
        public List<Basket> Basket { get; set; }
        public List<DeliveryMethods> DeliveryMethods {get; set;}
        //public List<>

    }
}