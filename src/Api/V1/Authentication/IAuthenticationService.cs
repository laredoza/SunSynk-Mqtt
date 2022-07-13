using Api.Authentication.Response;

namespace Api.Authentication
{
    public interface IAuthenticationService<T>
    {
        Task<AuthResponse> RequestClientCredentialsTokenAsync();
    }
}