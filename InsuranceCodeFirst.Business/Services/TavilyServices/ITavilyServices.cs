namespace InsuranceCodeFirst.Business.Services.TavilyServices
{
    public interface ITavilyServices
    {
        Task<string> GetSearchQueryResultAsync(string query);
    }
}
