using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecuteIdentityFramework.DAO
{
    public class OrderStates
    {
        private string _OrderState, _Description;
        public string Id { get;}
        public string OrderState {
            get
            {
                return _OrderState;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("trying to add null value to OrderState property");
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
                    throw new ArgumentNullException("trying to add null value to Description property");
                }
                else
                {
                    _Description = value;
                }
            }
        }
        public bool ? status { get; set; }
    }
}