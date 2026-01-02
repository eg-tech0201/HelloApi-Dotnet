using HelloApi.Daos;
using HelloApi.Dtos;

namespace HelloApi.Services;

public class HelloService : IHelloService
{
    private readonly IHelloDao _dao;

    public HelloService(IHelloDao dao)
    {
        _dao = dao;
    }

    public async Task<HelloResponseDto> SayHiAsync(HelloRequestDto request, CancellationToken cancellationToken = default)
    {
        var firstName = request.FirstName?.Trim() ?? string.Empty;

        // dummy DB call - no DB yet :
        await _dao.SaveHelloRequestAsync(firstName, cancellationToken);

        return new HelloResponseDto
        {
            FirstName = firstName,
            Message = $"Hi {firstName}"
        };
    }
}