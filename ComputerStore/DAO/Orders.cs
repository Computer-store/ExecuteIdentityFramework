using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExecuteIdentityFramework.ComputerStore.DAO;

namespace ExecuteIdentityFramework.DAO
{
    public class Orders
    {
        private int _Count = -1;
        private double _Cost = -1;
        private string _ClientName, _Adress, _Phone;
        [BsonId]
        public int Id { get; set; }
        public Basket BasketStartState { get; set;  }
        public Basket BasketEndState { get; set; }
        public int ProductCount
        {
            get
            {
                if ((BasketEndState != null) && (BasketStartState != null))
                {
                    _Count = BasketStartState.Count;
                    return _Count;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ProductCount attribute is out of range");
                }
            }
         
        }
        public double Cost {
         
            get
            {
                if (_Cost > 0)
                    return _Cost;
                else
                    throw new ArgumentOutOfRangeException("Argument Cost is out of range");
            }
        }
        public DeliveryMethods DeliveryMethod { get; set; }
        public PayMethods PayMethod { get; set; }
        public string ClientFullName
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to assign the null value to ClientFullName attribute");
                }
                else
                {
                    _ClientName = value;
                }
            }
            get
            {
                return _ClientName;
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
                    throw new ArgumentNullException("trying to assign the null value to Adress attribute");
                }
                else
                {
                    _Adress = value;
                }
            }
        }
        public string Phone
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
        public DateTime Date
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
        public OrderStates Orderstate { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; } = false;
    }
}