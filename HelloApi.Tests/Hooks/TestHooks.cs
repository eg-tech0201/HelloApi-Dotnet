using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using Reqnroll.BoDi;

namespace HelloApi.Tests.Hooks;

[Binding]
public class TestHooks
{
    private readonly IObjectContainer _container;

    public TestHooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void RegisterWebAppFactory()
    {
        // one in-memory API host per scenario
        _container.RegisterInstanceAs(new WebApplicationFactory<Program>());
    }
}