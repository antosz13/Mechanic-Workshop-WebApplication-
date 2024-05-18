using MechanicApp.Shared;

namespace MechanicApp
{
    public interface IJobService
    {
        Task Add(Job job);

        Task Delete(Guid id);

        Task<Job> Get(Guid id);

        Task<List<Job>> GetAll();

        Task Update(Job job);

        //Task<List<Client>> GetClientsOfJob(Guid jobId);
    }
}
