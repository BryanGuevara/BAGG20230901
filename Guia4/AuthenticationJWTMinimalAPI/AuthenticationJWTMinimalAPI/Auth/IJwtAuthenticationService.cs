namespace AuthenticationJWTMinimalAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
