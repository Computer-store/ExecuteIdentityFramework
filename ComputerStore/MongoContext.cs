using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using ExecuteIdentityFramework.DAO;
using ExecuteIdentityFramework.ComputerStore.DAO;
using System.Configuration;
using System.Threading.Tasks;

namespace ExecuteIdentityFramework.ComputerStore
{
    public class MongoContext
    {
        IGridFSBucket GridFS;
        /// <summary>
        /// Database
        /// </summary>
        private IMongoDatabase Database { get; set; }
        /// <summary>
        /// Collections
        /// </summary>
        private IMongoCollection<SupplerCompanies> SupplerCompaniesCollection { get; set; }
        private string _ConnectionString;
        
       
        public string ConnectionString
        {
            set
            {
                _ConnectionString = value;
            }
            get
            {
                return _ConnectionString;
            }
        }
        
        public MongoContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString;
            var connnection = new MongoUrlBuilder(ConnectionString);
            MongoClient client = new MongoClient();
            Database = client.GetDatabase(connnection.DatabaseName);
            GridFS = new GridFSBucket(Database);
            SupplerCompaniesCollection = Database.GetCollection<SupplerCompanies>("SupplerCompanies");
            
        }
        public void InsertSupplerCompanyAsync(SupplerCompanies company)
        {
           Task task1 =  Task.Factory.StartNew(() => SupplerCompaniesCollection.InsertOneAsync(company));
           task1.Wait();
        }
        public List<SupplerCompanies> GetAllSupplerCompanies()
        {
            var query =  SupplerCompaniesCollection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }
        public SupplerCompanies GetSupplerCompanyById(string id)
        {
            var company = SupplerCompaniesCollection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
            return company;
        }
        public void UpdateSupplerCompany(string id, SupplerCompanies company)
        {
            company.Id = new ObjectId(id);
            var filter = Builders<SupplerCompanies>.Filter.Eq(s => s.Id, company.Id);
            SupplerCompaniesCollection.ReplaceOneAsync(filter, company);
        }
        public void RemoveSupplerCompany(string id)
        {
            SupplerCompanies company = new SupplerCompanies();
            company.Id = new ObjectId(id);
            var filter = Builders<SupplerCompanies>.Filter.Eq(s => s.Id, company.Id);
            SupplerCompaniesCollection.DeleteOneAsync(filter);
        }
    }
}