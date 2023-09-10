var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var producto = new List<Producto>();

app.MapPost("/producto", (Producto client) =>
{
    producto.Add(client);
    return Results.Ok();
});

app.MapPut("/producto/{id}", (int id, Producto product) =>
{
    var existingProducto = producto.FirstOrDefault(x => x.Id == id);
    if (existingProducto != null)
    {
        existingProducto.Name = product.Name;
        existingProducto.Descripcion = product.Descripcion;
        existingProducto.price = product.price;
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/producto/{id}", (int id) =>
{
    var existingProducto = producto.FirstOrDefault(c => c.Id == id);
    if (existingProducto != null)
    {
        producto.Remove(existingProducto);
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/producto/{id}", (int id) =>
{
    var product = producto.FirstOrDefault(x => x.Id == id);
    return product;
});

app.MapGet("/producto", () =>
{
    return producto;
});

app.Run();

internal class Producto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
    public decimal price { get; set; }
}