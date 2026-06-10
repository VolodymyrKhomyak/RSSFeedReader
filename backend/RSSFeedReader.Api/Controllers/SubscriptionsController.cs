using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionStore _subscriptionStore;

    public SubscriptionsController(ISubscriptionStore subscriptionStore)
    {
        _subscriptionStore = subscriptionStore;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionResponse>>> GetSubscriptionsAsync()
    {
        var subscriptions = await _subscriptionStore.GetAllAsync();
        var response = subscriptions.Select(subscription => new SubscriptionResponse(subscription.Url));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscriptionAsync([FromBody] CreateSubscriptionRequest request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Url))
        {
            return BadRequest(new { error = "The 'url' field is required." });
        }

        var subscription = new Subscription
        {
            Url = request.Url.Trim(),
            AddedAt = DateTimeOffset.UtcNow
        };

        await _subscriptionStore.AddAsync(subscription);
        return CreatedAtAction(nameof(GetSubscriptionsAsync), null);
    }
}

public sealed class CreateSubscriptionRequest
{
    public string Url { get; set; } = string.Empty;
}

public sealed class SubscriptionResponse
{
    public SubscriptionResponse(string url)
    {
        Url = url;
    }

    public string Url { get; }
}
