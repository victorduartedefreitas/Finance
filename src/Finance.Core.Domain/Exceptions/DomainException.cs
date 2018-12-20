﻿using System;

namespace Finance.Core.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
