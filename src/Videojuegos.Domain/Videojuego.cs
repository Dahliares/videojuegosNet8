
namespace Videojuegos.Domain;
public class Videojuego
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string? Consola { get; set; }
    public string? Genero { get; set; }
    public string? Saga { get; set; } 
    public string? Formato { get; set; }
    public string? Idioma { get; set; } 
    public string? Estado { get; set; } 
    public string? Company { get; set; } 
    public string? Comentarios { get; set; } 
}
