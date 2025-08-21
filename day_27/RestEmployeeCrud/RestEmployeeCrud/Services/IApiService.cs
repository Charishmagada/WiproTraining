using RestEmployeeCrud.Models;

namespace RestEmployeeCrud.Services
{
    public interface IApiService
    {
        Task<IEnumerable<Employee>> GetEmployAsync();
        Task<Employee?> GetEmployByIdAsync(int id);
        Task<string> CreateEmployAsync(Employee employ);
    }
}
