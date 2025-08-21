using  RestEmployeeApi.Models;

namespace RestEmployeeApi.Services
{
    public interface IApiService
    {

        Task<IEnumerable<Employee>> ShowEmployAsync();
        Task<Employee?> SearchByEmpnoAsync(int id);
        Task<string> AddEmployAsync(Employee employ);
    }
}

