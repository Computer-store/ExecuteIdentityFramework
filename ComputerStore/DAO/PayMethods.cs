using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace ExecuteIdentityFramework.ComputerStore.DAO
{
    public class PayMethods
    {
        [BsonId]
        public int Id { get; set; }
        private string _PayMethod;
        public string PayMethod
        {
            set
            {
                if (value.Length > 0)
                {
                    _PayMethod = value;
                }
                else
                {
                    throw new ArgumentNullException("trying to assign the null value to PayMethod attribute");
                }
            }
            get
            {
                return _PayMethod;
            }
        }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
    }
}