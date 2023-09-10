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

var proveedores = new List<Proveedor>();

app.MapPost("/proveedor", (Proveedor proveedor) =>
{
    proveedores.Add(proveedor);
    return Results.Ok();
});

app.MapGet("/proveedor", () =>
{
return proveedores;
});

app.MapDelete("/proveedor/{id}", (int id) =>
{
var existingProveedor = proveedores.FirstOrDefault(c => c.Id == id);
if (existingProveedor != null)
{
proveedores.Remove(existingProveedor);
return Results.Ok();
}
else
{
return Results.NotFound();
}
});

app.Run();

internal class Proveedor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Empresa { get; set; }
}