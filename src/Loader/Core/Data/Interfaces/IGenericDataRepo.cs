namespace StatStore.Loader.Core.Data.Interfaces
{
    public interface IGenericDataRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetByProperty(string name, object value);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
