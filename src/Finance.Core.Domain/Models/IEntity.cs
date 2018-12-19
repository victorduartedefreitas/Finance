using System;

namespace Finance.Core.Domain.Models
{
    public interface IEntity : ICloneable
    {
        Guid Id { get; }
    }
}
