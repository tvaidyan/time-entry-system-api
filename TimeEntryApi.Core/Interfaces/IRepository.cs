// Thanks to Chris Pratt for this pattern.
// https://cpratt.co/truly-generic-repository/

using System.Threading.Tasks;

public interface IRepository : IReadOnlyRepository
{
    void Create<TEntity>(TEntity entity, string createdBy = null)
        where TEntity : class, IEntity;

    void Update<TEntity>(TEntity entity, string modifiedBy = null)
        where TEntity : class, IEntity;

    void Delete<TEntity>(object id)
        where TEntity : class, IEntity;

    void Delete<TEntity>(TEntity entity)
        where TEntity : class, IEntity;

    void Save();

    Task SaveAsync();
}