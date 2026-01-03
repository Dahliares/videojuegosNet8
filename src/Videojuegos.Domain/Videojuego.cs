
namespace Videojuegos.Domain;
public class Videojuego
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Plataforma { get; set; }
    public string? Genero { get; set; }
    public string? Saga { get; set; } 
    public string? Region { get; set; }
    public string? Idioma { get; set; } 
    public string? Estado { get; set; } 
    public string? Company { get; set; } 
    public string? Manual { get; set; }
    public string? Disco { get; set; }
    public string? Portada { get; set; }
    public string? Comentarios { get; set; } 
}
