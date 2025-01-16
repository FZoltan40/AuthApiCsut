using AuthApi.Services.Dtos;

namespace AuthApi.Services.IAuthService
{
    public interface IAuth
    {
        Task<object> Register(RegisterRequestDto registerRequestDto);
    }
}
