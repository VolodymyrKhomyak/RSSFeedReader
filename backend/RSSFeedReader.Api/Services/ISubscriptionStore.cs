using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public interface ISubscriptionStore
{
    Task AddAsync(Subscription subscription);
    Task<IReadOnlyList<Subscription>> GetAllAsync();
}
