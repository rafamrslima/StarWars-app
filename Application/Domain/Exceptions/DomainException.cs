using System;

namespace StarWars.App.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        { 
        }
    }
}
