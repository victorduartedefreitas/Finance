using Finance.Core.Domain.ValueTypes;
using System;

namespace Finance.Core.Domain.Models
{
    public interface ITransaction : ICloneable
    {
        #region Locals

        string Description { get; }
        Amount Amount { get; }
        DateTimeOffset TransactionDate { get; }

        #endregion
    }
}
