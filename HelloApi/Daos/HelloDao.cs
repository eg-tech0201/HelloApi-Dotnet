namespace HelloApi.Daos;

public class HelloDao : IHelloDao
{
    public Task SaveHelloRequestAsync(string firstName, CancellationToken cancellationToken = default)
    {
        //dummy implementation --> no DB yet
        return Task.CompletedTask;
    }
}