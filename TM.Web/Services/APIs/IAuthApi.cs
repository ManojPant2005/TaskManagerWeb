using Refit;
using TM.Shared.DTOs;

namespace TM.Web.Services.APIs
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        [Post("/api/auth/register")]
        Task<QuizApiResponse> RegisterAsync(RegisterDto dto);
    }
}
