namespace InsuranceCodeFirst.Business.Services
{
    public interface IGenericService<TCreate, TUpdate, TResult>
    {
        Task<TUpdate> TGetByIdAsync(int id);
        Task<List<TResult>> TGetAllAsync();
        Task TCreateAsync(TCreate dto);
        Task TUpdateAsync(TUpdate dto);
        Task TDeleteAsync(int id);
    }
}
