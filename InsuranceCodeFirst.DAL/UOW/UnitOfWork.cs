using InsuranceCodeFirst.DAL.Context;

namespace InsuranceCodeFirst.DAL.UOW
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task SaveChangeAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
