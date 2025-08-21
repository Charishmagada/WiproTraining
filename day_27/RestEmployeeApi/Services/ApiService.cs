using RestEmployeeApi.Models;
using RestEmployeeApi.Services;
namespace RestEmployeeApi.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7129/api/Employee");
        }
        public async Task<string> AddEmployAsync(Employee employ)
        {
            var response = await _httpClient.PostAsJsonAsync("Employee", employ);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Employee?> SearchByEmpnoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Employee/{id}");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<IEnumerable<Employee>> ShowEmployAsync()
        {
            var response = await _httpClient.GetAsync("Employee");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Employee>>()
                   ?? Enumerable.Empty<Employee>();

        }
    }
}
