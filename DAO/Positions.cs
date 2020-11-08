using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace ExecuteIdentityFramework.DAO
{
    public class Positions
    {
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id < 0)
                {
                    throw new ArgumentOutOfRangeException("argument of out of range");
                }
            }
        }
    }
}