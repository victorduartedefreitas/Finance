namespace Finance.Core.Domain.Models
{
    public interface ICopiableEntity<TEntity>
        where TEntity : IEntity
    {
        void CopyFrom(TEntity original);
    }
}
