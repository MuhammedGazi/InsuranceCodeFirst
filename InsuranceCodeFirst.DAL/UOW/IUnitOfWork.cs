namespace InsuranceCodeFirst.DAL.UOW
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();
    }
}
