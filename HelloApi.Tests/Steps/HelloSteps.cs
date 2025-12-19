using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;

namespace HelloApi.Tests.Steps;

[Binding]
public class HelloSteps
{
    private readonly HttpClient _client;
    private HttpResponseMessage? _response;
    private Dictionary<string, object>? _json;

    public HelloSteps(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [When(@"I GET ""([^""]*)""")]
    public async Task WhenIGet(string path)
    {
        _response = await _client.GetAsync(path);
    }

    [Then(@"the response status should be (\d+)")]
    public void ThenTheResponseStatusShouldBe(int statusCode)
    {
        Assert.NotNull(_response);
        Assert.Equal((HttpStatusCode)statusCode, _response!.StatusCode);
    }

    [Then(@"the JSON field ""([^""]*)"" should be ""([^""]*)""")]
    public async Task ThenTheJsonFieldShouldBe(string field, string expected)
    {
        Assert.NotNull(_response);

        _json = await _response!.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        Assert.NotNull(_json);

        Assert.True(_json!.ContainsKey(field), $"Expected JSON to contain field '{field}'.");
        Assert.Equal(expected, _json[field]?.ToString());
    }
}