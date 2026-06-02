namespace InventarioApp.Factories;

using InventarioApp.models;
public static class ProductFactory
{
    private static int _nextId = 1;
    public static Producto crear(
        string nombre,
        string descripcion,
        decimal precio,
        int cantidad,
        CategoriaProducto categoria = CategoriaProducto.Otros)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(nombre));

        if (string.IsNullOrWhiteSpace(descripcion))
            throw new ArgumentException("La descripción del producto no puede estar vacía.", nameof(descripcion));

        if (precio < 0)
            throw new ArgumentException("El precio del producto no puede ser negativo.", nameof(precio));

        if (cantidad < 0)
            throw new ArgumentException("La cantidad del producto no puede ser negativa.", nameof(cantidad));

        return new Producto
        {
            Id = _nextId++,
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            Cantidad = cantidad,
            Categoria = categoria,
            FechaRegistro = DateTime.Now
        };
    }
}