namespace InventarioApp.Models;

public class Producto
{
    private string _nombre = "";
    private decimal _precio;
    private int _cantidad;
    private string _descripcion = "";
    public int Id { get; set; }
    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(Nombre));
            _nombre = value.Trim();
        }
    }
    /// <summary>
    /// Obtiene o establece la descripción del producto.
    /// </summary>
    public string Descripcion
    {
        get => _descripcion;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La descripción del producto no puede estar vacía.", nameof(Descripcion));
            _descripcion = value.Trim();
        }
    }
    public decimal Precio
    {
        get => _precio;
        set
        {
            if (value < 0)
                throw new ArgumentException("El precio del producto no puede ser negativo.", nameof(Precio));
            _precio = value;
        }
    }
    public int Cantidad
    {
        get => _cantidad;
        set
        {
            if (value < 0)
                throw new ArgumentException("La cantidad del producto no puede ser negativa.", nameof(Cantidad));
            _cantidad = value;
        }
    }
    public CategoriaProducto Categoria { get; set; }
    public EstadoProducto Estado { get; set; } = EstadoProducto.Activo;
    public DateTime FechaRegistro { get; set; }
    public decimal ValorTotal => Precio * Cantidad;

    public override string ToString()
    => $"{Nombre} (ID: {Id}) - {Descripcion} - Q.{Precio:N2} x {Cantidad} = Q.{ValorTotal:N2} [{Categoria}, {Estado}]";
}
