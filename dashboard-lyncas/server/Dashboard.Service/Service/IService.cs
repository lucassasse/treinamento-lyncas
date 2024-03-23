namespace Dashboard.Service.Service
{
    public interface IService<T, TDto, TViewModel>
    {
        TViewModel GetById(int Id);
        T Create(TDto model);
        T Update(TDto model, int id);
        T Delete(int id);
    }
}
