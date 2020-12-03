﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecuteIdentityFramework.DAO
{
    public class SupplerCompanies
    {
        private string _CompanyName, _Adress, _Description;
        private double _Rathing;
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("CompanyName")]
        public string CompanyName
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to argument CompanyName");
                }
                else
                {
                    _CompanyName = value;
                }
            }
            get
            {
                return _CompanyName;
            }
        }
        [BsonElement("Address")]
        public string Adress
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to attribute Adress");
                }
                else
                {
                    _Adress = value;
                }
            }
            get
            {
                return _Adress;
            }
        }
        [BsonElement("Description")]
        public string Description
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to Description attribute");
                }
                else
                {
                    _Description = value;
                }
            }
            get
            {
                return _Description;
            }
        }
        [BsonElement("Rating")]
        public double Rating
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("argument Rathing is out of range");
                }
                else
                {
                    _Rathing = value;
                }
            }
        }
        [BsonElement("Status")]
        public bool Status { get; set; } = true;
    }
}