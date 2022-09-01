namespace Timesheets.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<bool> AddAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, T entity);
}