using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecuteIdentityFramework.DAO
{
    /// <summary>
    /// USE Mongo Db database
    /// </summary>
    public class Basket
    {
        private int _Count = 0;
        private double _Cost =  0;

        [BsonId]
        public int Id { get; set; }

        public Users BuyerCipher { get; set; }
        public Products ProductCipher { get; set; }
        public int Count { 
            get 
            {
                return _Count;
            } 
            set
            {
                if (value > 0)
                {
                    _Count = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("argument Count is out of range");
                }
            }
           
        }
        public double InterMediateCost
        {
            set
            {
                _Cost = ProductCipher.Price;
            }
            get
            {
                return _Cost;
            }
        }
        public bool Visible { get; set; } = true;
    }
}