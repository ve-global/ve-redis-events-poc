namespace Ve.Redis.Events.Common.Persistance
{
    public interface IRepository<T> where T : class
    {
        T Get(string key);
        void Set(string key, T entity);
    }
}