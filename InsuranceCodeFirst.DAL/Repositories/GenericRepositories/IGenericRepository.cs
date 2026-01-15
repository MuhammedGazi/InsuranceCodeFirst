namespace InsuranceCodeFirst.DAL.Repositories.GenericRepositories
{
    public interface IGenericRepository<Tentity> where Tentity : class
    {
        Task<Tentity> GetByIdAsync(int id);
        Task<List<Tentity>> GetAllAsync();
        IQueryable<Tentity> GetQueryable();
        Task CreateAsync(Tentity entity);
        void Update(Tentity entity);
        void Delete(Tentity entity);
    }
}
