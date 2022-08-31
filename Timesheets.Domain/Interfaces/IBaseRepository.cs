namespace Timesheets.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public Task<T> CreateAsync(T entity);

    public Task<T> GetByIdAsynс(Guid id);

    public Task<List<T>> GetAllAsync();

    public Task DeleteByIdAsync(Guid id);

    public Task<T> UpdateByIdAsync(Guid id, T entity);
}