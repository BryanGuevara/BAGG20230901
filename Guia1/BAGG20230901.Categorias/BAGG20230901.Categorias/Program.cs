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

var categorias = new List<Categorias>();

var categoria = new Categorias
{
    Id = 1,
    Name = "Herramientas",
    Descripcion = "Todo tipo de herramientas, calidad insutrial"
};
categorias.Add(categoria);

app.MapGet("/categorias", () =>
{
    return categorias;
});

app.Run();

internal class Categorias
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
}