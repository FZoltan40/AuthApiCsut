namespace AuthApi.Services.Dtos
{
    public record RegisterRequestDto(string UserName, string Password, string Email, DateTime BirthDate);
    public record LoginRequestDto(string UserName, string Password);
}
