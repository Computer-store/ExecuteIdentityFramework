using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;


namespace ExecuteIdentityFramework.DAO
{
    /// <summary>
    /// USE MSSQL DATABASE
    /// </summary>
    public class Users
    {
        private string _FName, _SName, _MName, _Adress, _Phone;
        private int _Id, _NETM, _NELM;
        public int Id { get; set; }
        public List<Positions> Position { get; set; }
        public string FirstName { 
            get 
            {
                return _FName;
            }
            set
            { 
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to FirstName argument");
                }
            } 
        }
        public string SecondName { get 
            {
                return _SName;
            } 
            set
            { 
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to SecondName argument");
                }
                else
                {
                    _SName = value;
                }
            }
        }
        public string MiddleName { set 
            { 
             if (value.Length==0)
                {
                    throw new ArgumentNullException("trying to assign the null value to MiddleName attribute");
                }
                else
                {
                    _MName = value;
                }
            }
            get 
            {
                return _MName;
            }
        }
        public string Adress
        {
            get
            {
                return _Adress;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to Adress argument");
                }
                else
                {
                    _Adress = value;
                }
            }
        }
        public string PhoneNumber
        {
            set
            {
                if (value.Length > 0)
                {
                    if ((value.Length == 6) || (value.Length == 13))
                        _Phone = value;
                    else
                        throw new ArgumentOutOfRangeException("input uncorrect phone number, please check input value");
                }
                else
                    throw new ArgumentNullException("trying to assign the null value to PhoneNumber property");
            }
            get
            {
                return _Phone;
            }
        }
        public int NumberOfExistsInTheCurrentMonth
        {
            set
            {
                if (value > 0)
                    _NETM = value;
                else
                    throw new ArgumentNullException("tryin to assign the null value to NuberOfExistsInTheCurrentMonth property");
            }
            get 
            {
                return _NETM;
            }
        }
        public int NumberOfExistsInTheLastMonth
        {
            set
            {
                if (value > 0)
                {
                    _NELM = value;
                }
                else
                {
                    throw new ArgumentNullException("trying to assign the null value to NumberOfExistsInTheLastMonth argument");
                }
            }
            get
            {
                return _NELM;
            }
        }
        public string Descripttion { get; set; }
        public  bool ? Status { get; set; } 
    }
}