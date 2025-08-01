using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<VideojuegosDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

// ENDPOINTS
app.MapGet("/api/videojuegos", async (VideojuegosDbContext db) =>
    await db.Videojuegos.ToListAsync());

app.MapGet("/api/videojuegos/{id}", async (int id, VideojuegosDbContext db) =>
    await db.Videojuegos.FindAsync(id) is Videojuego vj
        ? Results.Ok(vj)
        : Results.NotFound());

app.MapPost("/api/videojuegos", async (Videojuego videojuego, VideojuegosDbContext db) =>
{
    db.Videojuegos.Add(videojuego);
    await db.SaveChangesAsync();
    return Results.Created($"/api/videojuegos/{videojuego.Id}", videojuego);
});

app.MapPut("/api/videojuegos/{id}", async (int id, Videojuego input, VideojuegosDbContext db) =>
{
    var videojuego = await db.Videojuegos.FindAsync(id);
    if (videojuego is null) return Results.NotFound();

    videojuego.Nombre = input.Nombre;
    videojuego.Genero = input.Genero;
    videojuego.Consola = input.Consola;

    await db.SaveChangesAsync();
    return Results.Ok(videojuego);
});

app.MapDelete("/api/videojuegos/{id}", async (int id, VideojuegosDbContext db) =>
{
    var videojuego = await db.Videojuegos.FindAsync(id);
    if (videojuego is null) return Results.NotFound();

    db.Videojuegos.Remove(videojuego);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();


