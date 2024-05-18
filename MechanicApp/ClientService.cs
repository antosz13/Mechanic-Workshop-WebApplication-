using MechanicApp.Shared;
using Microsoft.EntityFrameworkCore;


namespace MechanicApp
{
    public class ClientService : IClientService
    {
        private readonly AppContext _context;
        private readonly ILogger<IClientService> _logger;

        public ClientService(ILogger<ClientService> logger, AppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Add(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Client added");
        }

        public async Task Delete(Guid id)
        {
            var client = await Get(id);

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }

        public async Task<Client> Get(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            _logger.LogInformation("Client retrieved: {@Client}", client);
            return client;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task Update(Client newClient)
        {
            var client = await Get(newClient.ClientId);
            client.Name = newClient.Name;
            client.Address = newClient.Address;
            client.Email = newClient.Email;

            await _context.SaveChangesAsync();
        }

        /*
        public async Task<List<Job>> GetJobsOfPerson(Guid clientId)
        {
            var client = await Get(clientId);

            return client.Jobs.ToList();
        }

        */



    }
}
