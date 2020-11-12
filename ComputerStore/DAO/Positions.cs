using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace ExecuteIdentityFramework.DAO
{
    /// <summary>
    /// USE MSSQL DATABASE
    /// </summary>
    public class Positions
    {
       
        private string _PositionName, _Description;
        public int Id { get; set; }
        public string PositionName
        {
            get
            {
                return _PositionName;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to argument PositionName");
                }
                else
                {
                    _PositionName = value;
                }
            }
        }
        public string Description
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentOutOfRangeException("trying to assign the null value to argument Description");
                }
                else
                {
                    _Description = value;
                }
            }
        }
        public bool? Status { get; set; }
    }
}