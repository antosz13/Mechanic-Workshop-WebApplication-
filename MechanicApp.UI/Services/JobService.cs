using MechanicApp.Shared;
using System.Net.Http.Json;

namespace MechanicApp.UI.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _httpClient;

        public JobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddJobAsync(Job job)
        {
            await _httpClient.PostAsJsonAsync("/jobs", job);
        }

        public async Task DeleteJobAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/jobs/{id}");
        }

        public async Task<Job> GetJobAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Job>($"/jobs/{id}");
        }

        public async Task<IEnumerable<Job>> GetAllJobAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Job>>("/jobs");
        }

        public async Task UpdateJobAsync(Guid id, Job job)
        {
            await _httpClient.PutAsJsonAsync($"/jobs/{id}", job);
        }
    }
}
