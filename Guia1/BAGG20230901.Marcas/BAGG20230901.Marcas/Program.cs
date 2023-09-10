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

var marcas = new List<Marca>();

app.MapGet("/marca/{id}", (int id) =>
{
    var client = marcas.FirstOrDefault(x => x.Id == id);
    return client;
});

app.MapPost("/marca", (Marca client) =>
{
    marcas.Add(client);
    return Results.Ok();
});

app.MapPut("/marca/{id}", (int id, Marca marca) =>
{
    var existingMarca = marcas.FirstOrDefault(x => x.Id == id);
    if (existingMarca != null)
    {
  existingMarca = marcas.FirstOrDefault(x => x.Id == id);
   existingMarca.Name = marca.Name;
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});


app.Run();

internal class Marca
{
    public int Id { get; set; }
    public string Name { get; set; }
}