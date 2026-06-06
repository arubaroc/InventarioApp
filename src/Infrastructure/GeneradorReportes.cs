using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;

using InventarioApp.Models;

namespace InventarioApp.Infrastructure;

public class GeneradorReportes
{
    private readonly IEnumerable<Producto> _productos;

    public GeneradorReportes (IEnumerable<Producto> productos)
    {
        _productos = productos;
    }

    public string GenerarResumen()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Generador de resume --------------");
        sb.AppendLine($"Total de productos: {_productos.Count()} ");
        sb.AppendLine($"Valor total del inventario: {_productos.Sum(p => p.ValorTotal):F2}");

        var ProductoPorCategoria = _productos.GroupBy(p => p.Categoria).Select(g => new {Categoria = g.Key, Cantidad = g.Count()});

        sb.AppendLine("Productos por categoria");
        foreach (var categoria in ProductoPorCategoria)
        {
            sb.AppendLine($" {categoria.Categoria} : {categoria.Cantidad}");
        }

        return sb.ToString();

    }

    public string GenerarReporteStockBajo(int minimo = 5)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Productos con Stock bajo a {minimo}");

        var stockBajo = _productos.Where(p => p.Cantidad < minimo).OrderBy(p => p.Cantidad);

        if (!stockBajo.Any())
        {
            sb.AppendLine("No hay productos con Stock bajo");
            return sb.ToString();
        }

        foreach (var producto in stockBajo)
        {
            sb.AppendLine($" ID: {producto.Id}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio}");
        }

        return sb.ToString();
    }

    public string GenerarReporteTopProductos(int cantidad = 5)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Productos Top {cantidad} productos por su cantidad -----------");

        var top = _productos.OrderByDescending(p => p.Cantidad)

        return sb.ToString();
    }
}