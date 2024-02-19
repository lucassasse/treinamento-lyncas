namespace Dashboard.Repository.RepositoryPattern
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
