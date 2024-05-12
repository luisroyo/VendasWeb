using System;
namespace VendasWebMVC.Services.Exceptions
{
    public class IntegrityExcption : ApplicationException
    {
        public IntegrityExcption(string message) : base(message)
        {

        }
    }
}
