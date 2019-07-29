using System;

namespace Sistema.TSTOnline.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }

        public static void When(bool invalid, string message)
        {
            if (invalid)
                throw new DomainException(message);
        }
    }
}