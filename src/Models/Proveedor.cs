namespace InventarioApp.Models;

public record Proveedor
{
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string Telefono { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public override string ToString()
        => $"{Nombre} (ID: {Id}) Tel: {Telefono}, Email: {Email}";
}