using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Tests.UnitTests;

public class SubscriptionStoreTests
{
    [Fact]
    public async Task AddAsync_ShouldStoreSubscriptionAndReturnIt()
    {
        var store = new InMemorySubscriptionStore();
        var subscription = new Subscription
        {
            Url = "https://example.com/feed.xml",
            AddedAt = DateTimeOffset.UtcNow
        };

        await store.AddAsync(subscription);
        var items = await store.GetAllAsync();

        Assert.Single(items);
        Assert.Equal("https://example.com/feed.xml", items[0].Url);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyCollectionWhenNoSubscriptions()
    {
        var store = new InMemorySubscriptionStore();
        var items = await store.GetAllAsync();

        Assert.Empty(items);
    }
}
