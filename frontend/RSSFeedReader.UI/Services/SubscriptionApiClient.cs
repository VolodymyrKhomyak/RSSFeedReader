using System.Net.Http.Json;

namespace RSSFeedReader.UI.Services;

public sealed class SubscriptionApiClient
{
    private readonly HttpClient _httpClient;

    public SubscriptionApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<SubscriptionItem>> GetSubscriptionsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<List<SubscriptionItem>>("api/subscriptions", cancellationToken);
        return response ?? new List<SubscriptionItem>();
    }

    public async Task AddSubscriptionAsync(string url, CancellationToken cancellationToken = default)
    {
        var request = new CreateSubscriptionRequest { Url = url };
        var result = await _httpClient.PostAsJsonAsync("api/subscriptions", request, cancellationToken);
        result.EnsureSuccessStatusCode();
    }
}

public sealed class CreateSubscriptionRequest
{
    public string Url { get; set; } = string.Empty;
}

public sealed class SubscriptionItem
{
    public string Url { get; set; } = string.Empty;
}
