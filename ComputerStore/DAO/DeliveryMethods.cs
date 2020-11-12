using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace ExecuteIdentityFramework.DAO
{
    public class DeliveryMethods
    {
       [BsonId]
        public int Id { get; set; }
        private string _methname, _Description;
        public string MethodName
        {
            get
            {
                return _methname;
            }
            set
            {
                if (value.Length != 0)
                {
                    _methname = value;
                }
            }
        }
        public string Description { get
            {
                return _Description;
            }
            set
            {
                if (value.Length != 0)
                {
                    _Description = value;
                }
            }
        }
        public bool? Status { get; set; }
    }
}