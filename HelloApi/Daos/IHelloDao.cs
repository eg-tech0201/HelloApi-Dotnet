namespace HelloApi.Daos;

public interface IHelloDao
{
    Task SaveHelloRequestAsync(string firstname, CancellationToken cancellationToken = default);
}