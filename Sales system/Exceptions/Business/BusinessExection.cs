using System;

namespace Sales_system.Exceptions.Business
{
    public class BusinessExection : Exception
    {
        public BusinessExection(string message) : base(message)
        {
            
        }
    }
}