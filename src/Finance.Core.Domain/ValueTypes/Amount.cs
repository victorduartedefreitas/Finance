using Finance.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Core.Domain.ValueTypes
{
    public sealed class Amount
    {
        #region Locals

        private decimal _value;

        #endregion

        #region Constructors

        public Amount(decimal value)
        {
            if (value < 0)
                throw new NegativeAmountException($"The {value} is not a valid amount. It should be a positive value.");

            _value = value;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return _value.ToString("C");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is decimal)
                return (decimal)obj == _value;
            if (obj is Amount)
                return ((Amount)obj)._value == _value;
            return false;
        }

        public override int GetHashCode()
        {
            return 988027 + _value.GetHashCode();
        }

        #endregion

        #region Operators

        public static implicit operator Amount(decimal value)
        {
            return new Amount(value);
        }

        public static implicit operator decimal(Amount value)
        {
            return value._value;
        }

        public static Amount operator - (Amount amount1, Amount amount2)
        {
            return amount1._value - amount2._value;
        }

        public static Amount operator + (Amount amount1, Amount amount2)
        {
            return amount1._value + amount2._value;
        }

        public static bool operator < (Amount amount1, Amount amount2)
        {
            return amount1._value < amount2._value;
        }

        public static bool operator > (Amount amount1, Amount amount2)
        {
            return amount1._value > amount2._value;
        }

        public static bool operator <= (Amount amount1, Amount amount2)
        {
            return amount1._value <= amount2._value;
        }

        public static bool operator >= (Amount amount1, Amount amount2)
        {
            return amount1._value >= amount2._value;
        }

        #endregion
    }
}
