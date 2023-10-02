namespace BAGG2309.Inventario.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
