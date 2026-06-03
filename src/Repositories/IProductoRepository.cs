using System.Collections.Generic;
using InventarioApp.Models;

namespace InventarioApp.Repositories;

public interface IProductoRepository
{
    IEnumerable<Producto> ObtenerTodos();
    Producto ObtenerPorId(int id);
    void Agregar(Producto producto);
    bool Actualizar(Producto producto);
    bool Eliminar(int id);
    int Cantidad { get; }
}

