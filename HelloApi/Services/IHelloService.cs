using HelloApi.Dtos;

namespace HelloApi.Services;

public interface IHelloService
{
    Task<HelloResponseDto> SayHiAsync(HelloRequestDto request, CancellationToken cancellationToken = default);
}