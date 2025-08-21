using RestEmployeeCrud.Models;
using RestEmployeeCrud.Services;

namespace RestEmployeeCrud.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Set base address to API root, not including "Employee" twice
            _httpClient.BaseAddress = new Uri("https://localhost:7129/api/");
        }

        // Create a new employee
        public async Task<string> CreateEmployAsync(Employee employ)
        {
            var response = await _httpClient.PostAsJsonAsync("Employee", employ);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // Get all employees
        public async Task<IEnumerable<Employee>> GetEmployAsync()
        {
            var response = await _httpClient.GetAsync("Employee");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Employee>>()
                   ?? Enumerable.Empty<Employee>();
        }

        // Get employee by ID
        public async Task<Employee?> GetEmployByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Employee/{id}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<Employee>();
        }
    }
}
