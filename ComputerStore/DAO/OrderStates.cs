using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExecuteIdentityFramework.DAO
{
    public class OrderStates
    {
        private string _OrderState, _Description;
        [BsonId]
        public int Id { get; set; }
        
        public string State {
            get
            {
                return _OrderState;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to to OrderState property");
                }
                else
                {
                    _OrderState = value;
                }
            }
        }
        public string Description
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to Description property");
                }
                else
                {
                    _Description = value;
                }
            }
        }
        public bool status { get; set; } = true;
    }
}