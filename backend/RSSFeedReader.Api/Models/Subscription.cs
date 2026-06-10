namespace RSSFeedReader.Api.Models;

public sealed class Subscription
{
    public string Url { get; init; } = string.Empty;
    public DateTimeOffset AddedAt { get; init; } = DateTimeOffset.UtcNow;
}
