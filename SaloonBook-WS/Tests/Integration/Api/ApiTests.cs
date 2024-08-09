using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Abstractions;

namespace Tests.Integration.api;

public class ApiTests : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebAppFactory<Program> _factory;
    private readonly ITestOutputHelper _testOutputHelper;


    public ApiTests(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _factory = factory;
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact(DisplayName = "GET - get appointments")]
    public async Task ApiAppointmentsTest()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/api/v1/PublicAppointment/GetAll");

        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());

        // Assert
        response.EnsureSuccessStatusCode();
        
        
    }
}