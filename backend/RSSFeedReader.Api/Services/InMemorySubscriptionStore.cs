using System.Collections.Concurrent;
using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public sealed class InMemorySubscriptionStore : ISubscriptionStore
{
    private readonly ConcurrentQueue<Subscription> _subscriptions = new();

    public Task AddAsync(Subscription subscription)
    {
        if (subscription is null)
        {
            throw new ArgumentNullException(nameof(subscription));
        }

        _subscriptions.Enqueue(subscription);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Subscription>> GetAllAsync()
    {
        var items = _subscriptions.ToArray();
        return Task.FromResult((IReadOnlyList<Subscription>)items);
    }
}
