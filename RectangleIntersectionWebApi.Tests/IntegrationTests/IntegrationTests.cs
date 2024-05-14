using Microsoft.AspNetCore.Mvc.Testing;
using RectangleIntersectionWebApi;
using Xunit;
using System.Threading.Tasks;
using System.Net.Http;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public IntegrationTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetIntersectingRectangles_ReturnsSuccessAndCorrectContentType()
    {
        // Act: Request intersecting rectangles passing the parameters directly in the query string
        var response = await _client.GetAsync("/api/rectangles/intersect?x1=1&y1=1&x2=11&y2=11");

        // Assert: Ensure we got a successful response that is also returning JSON
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }
}