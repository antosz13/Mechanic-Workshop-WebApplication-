using MechanicApp.Shared;
using System.Net.Http.Json;

namespace MechanicApp.UI.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddClientAsync(Client client)
        {
            await _httpClient.PostAsJsonAsync("/clients", client);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/clients/{id}");
        }

        public async Task<Client> GetClientAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Client>($"/clients/{id}");
        }

        public async Task<IEnumerable<Client>> GetAllClientAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Client>>("/clients");
        }

        public async Task UpdateClientAsync(Guid id, Client client)
        {
            await _httpClient.PutAsJsonAsync($"/clients/{id}", client);
        }
    }
}
