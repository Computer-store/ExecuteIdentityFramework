using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ExecuteIdentityFramework.DAO
{
    /// <summary>
    /// USE Mongo Db database
    /// </summary>
    public class Products
    {
        private string _Cipher, _Name;
        private double _Price, _Rathing;
        private int _CountAll, _AmmontsProducts;
       [BsonId]
       public int Id { get; set; }

        public string Name
        {
            set
            {
                if ((value.Length > 0) && (value.Length<=50))
                {
                    _Name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The argument Name is out of range");
                }
            }
        }
        public SupplerCompanies SupplerCompany { get; set; }
        public double Price
        {
            set
            {
                if (value > 0)
                    _Price = value;
                else
                    throw new ArgumentOutOfRangeException("Price argument is out of range");
            }
            get
            {
                return _Price;
            }
        }
        public int CountAll
        {
            set
            {
                if (value > 0)
                {
                    _CountAll = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("CountAll rgument is out of range");
                }
            }
            get
            {
                return _CountAll;
            }
        }
        public int AmmountsProducts
        {
            set
            {
                if (value > 0)
                {
                    _AmmontsProducts = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("the AmmountsProducts argument is out of range");
                }
            }
            get
            {
                return _AmmontsProducts;
            }
        }
        public double Rathing { 
            get
            {
                _Rathing = (1 - (_CountAll - _AmmontsProducts) / _AmmontsProducts);
                return _Rathing;
            }
           
        }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
    }
}