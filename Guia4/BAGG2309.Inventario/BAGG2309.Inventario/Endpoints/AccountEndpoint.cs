using BAGG2309.Inventario.Auth;

namespace BAGG2309.Inventario.Endpoints
{
    public static class AccountEndpoint
    {
        public static void AddAccountEndPoints(this WebApplication app)
        {
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authServices) =>
            {

                if (login == "admin" && password == "12345")
                {
                    var token = authServices.Authenticate(login);
                    return Results.Ok(token);
                }
                else
                {
                    return Results.Unauthorized();
                }
            });
        }
    }
}
