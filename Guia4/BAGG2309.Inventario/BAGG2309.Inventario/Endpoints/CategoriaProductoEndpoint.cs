namespace BAGG2309.Inventario.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddCategoriaProductoEndpoint(this WebApplication app)
        {
            app.MapGet("/categoria", () =>
            {
                return data;
            }).AllowAnonymous();

            app.MapPost("/categoria", (string name, string empresa) =>
            {
                data.Add(new { name, empresa });
            }).AllowAnonymous();

            app.MapDelete("/Categoria/{id}", () =>
            {
                data = new List<object>();
                return Results.Ok();
            }).AllowAnonymous();
        }
    }
}
