using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infrastructure;
using InventarioApp.Factories;
using System.Runtime.CompilerServices;

namespace InventarioApp.Services;

public class InventarioService
{
    private readonly InMemoryProductoRepository _repository;
    private readonly JsonInventarioStorage _storage;
    private readonly string _rutaInventario;

    public InventarioService(string rutaInventario = "inventario.json")
    {
        _repository = new InMemoryProductoRepository();
        _storage = new JsonInventarioStorage();
        _rutaInventario = rutaInventario;

        CargarInventario();
    }

    private void CargarInventario()
    {
        if (File.Exists(_rutaInventario))
        {
            var productos = _storage.Cargar(_rutaInventario);
            foreach (var producto in productos)
            {
                _repository.Agregar(producto);
            }
        }
    }

    public void AgregarProducto(string nombre, string descripcion, decimal precio, int cantidad, CategoriaProducto categoria)
    {
        var producto = ProductoFactory.Crear(nombre, descripcion, precio, cantidad, categoria);
        _repository.Agregar(producto);
        _Persistir();
    }

    public IEnumerable<Producto> ObtenerTodosLosProductos()
    {
        return _repository.ObtenerTodos();
    }

    public Producto? ObtenerProductoPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public void ActualizarProducto(int id, string nombre, string descripcion, decimal precio, int cantidad, CategoriaProducto categoria)
    {
        var producto = _repository.ObtenerPorId(id);

        if (producto != null)
        {
            producto.Nombre = nombre;
            producto.Descripcion = descripcion;
            producto.Cantidad = cantidad;
            producto.Precio = precio;
            producto.Categoria = categoria;
            _repository.Actualizar(producto);
            _Persistir();
        }
    }

    public void EliminarProducto(int id)
    {
        _repository.Eliminar(id);
        _Persistir();
    }

    public IEnumerable<Producto> BuscarPorCategoria(CategoriaProducto categoria)
    {
        return _repository.BuscarPorCategoria(categoria);
    }

    public IEnumerable<Producto> BuscarPorNombre(string nombre)
    {
        return _repository.BuscarPorNombre(nombre);
    }

    public IEnumerable<Producto> ObtenerProductoBajoStrock(int minimo = 5)
    {
        return _repository.ObtenerProductosConStockBajo(minimo);
    }

    public decimal ObtenerValorTotalInventario()
    {
        return _repository.ObtenerValorTotalInventario();
    }

    public decimal ObtenerPrecioPromedio()
    {
        return _repository.ObtenerPrecioPromedio();
    }

    public Producto? ObtenerProductoMasCaro()
    {
        return _repository.ObtenerProductoMasCaro();
    }

    //Metodos para los reportes

    public string GenerarResumen()
    {
        var productos = _repository.ObtenerTodos();
        var generador = new GeneradorReportes(productos);
        return generador.GenerarResumen();
    }

    public string GenerarReporteStockBajo(int minimo = 5)
    {
        var productos = _repository.ObtenerTodos();
        var generador = new GeneradorReportes(productos);
        return generador.GenerarReporteStockBajo(minimo);
    }
    public string GenerarReporteTopProductos(int cantidad = 5)
    {
        var productos = _repository.ObtenerTodos();
        var generador = new GeneradorReportes(productos);
        return generador.GenerarReporteTopProductos(cantidad);
    }

    public string ExportarCsv()
    {
        var productos = _repository.ObtenerTodos();
        var generador = new GeneradorReportes(productos);
        return generador.ExportarCsv();
    }

    private void _Persistir()
    {
        _storage.CrearBackup(_rutaInventario);
        var productos = _repository.ObtenerTodos().ToList();
        _storage.Guardar(productos, _rutaInventario);
    }




}