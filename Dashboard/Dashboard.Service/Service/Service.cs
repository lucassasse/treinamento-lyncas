using AutoMapper;
using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;

namespace Dashboard.Service.Service
{
    public class Service<T, TDto, TViewModel, TRepository> : IService<T, TDto, TViewModel>
        where T : BaseEntity
        where TDto : class
        where TViewModel : class
        where TRepository : IRepository<T>

    {
        public readonly TRepository _repository;
        public readonly IMapper _mapper;

        public Service(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual TViewModel GetById(int Id)
        {
            try
            {
                var entity = _repository.GetById(Id);
                var viewModel = _mapper.Map<TViewModel>(entity);
                return viewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurred while getting {typeof(T).Name} by Id.", ex);
            }
        }

        public virtual T Create(TDto model)
        {
            try
            {
                var entity = _mapper.Map<T>(model);
                return _repository.Create(entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurred while creating {typeof(T).Name}.", ex);
            }
        }

        public virtual T Update(TDto model, int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                _mapper.Map(model, entity);
                return _repository.Update(entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurred while updating {typeof(T).Name}.", ex);
            }
        }

        public virtual T Delete(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                _repository.Delete(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while deleting entity.", ex);
            }
        }        
    }
}
