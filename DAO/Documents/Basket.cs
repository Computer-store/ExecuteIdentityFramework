using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecuteIdentityFramework.DAO
{
    public class Basket
    {
        private int _Count = 0;
        private int _Cost =  0;
        public ObjectId Id { get; set; }
        public Employees BuyerCipher { get; set; }
        public Products ProductCipher { get; set; }
        public int Count { get 
            {
                return _Count;
            } 
            set
            {
                if (value > 0)
                {
                    _Count = value;
                }
            }               
        }
        public int InterMediateCost
        {
            set
            {
                if (value > 0)
                {
                    _Cost = value;
                }
            }
            get
            {
                return _Cost;
            }
        }
    }
}