namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        void Remove(T entity);
    }
}
