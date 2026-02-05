using System.Net.Http;
using System.Net.Http.Json;
using EmployeeClient.Models;

namespace EmployeeClient.Services
{
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7114/")
                // ↑ WebAPI の URL に合わせて変更
            };
        }

        // 一覧取得（GET）
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee");
        }

        // 新規追加（POST）
        public async Task<bool> AddAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employee", employee);
            return response.IsSuccessStatusCode;
        }

        // 更新（PUT）
        public async Task<bool> UpdateAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employee/{employee.Id}", employee);
            return response.IsSuccessStatusCode;
        }

        // 削除（DELETE）
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/employee/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}