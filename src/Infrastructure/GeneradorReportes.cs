using System;
using System.Collections.Generic;
using System.ComponentModel;
// using System.Linq;
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
        sb.AppendLine($"Productos Top {cantidad}  por su cantidad -----------");

        var top = _productos.OrderByDescending(p => p.ValorTotal).Take(cantidad);

        if (!top.Any())
        {
            sb.AppendLine("No hay productos disponibles");
            return sb.ToString();
        }
        int posicion = 1;

        foreach (var producto in top)
        {
            sb.AppendLine($"{posicion}. {producto.Nombre} | {producto.Cantidad} | Valor: ${producto.ValorTotal:F2}");
            posicion++;
        }

        return sb.ToString();
    }

    public string ExportarCsv()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id, Nombre, Precio, Cantidad, Categoria, ValorTotal");

        foreach (var producto in _productos.OrderBy(p=> p.Id))
        {
            sb.AppendLine($"{producto.Id}, {producto.Nombre}, {producto.Precio:F2}, {producto.Cantidad}, {producto.Categoria}, {producto.ValorTotal:F2}");
        }

        return sb.ToString();
        
    }

    public string ExportarResumenJson()
    {
        var resumen = new
        {
            totalProductos = _productos.Count(),
            ValorTotalInventario = _productos.Sum(p=>p.ValorTotal),
            ProductosPorCategoria = _productos.GroupBy(p=>p.Categoria).Select(g => new {Categoria = g.Key, Cantidad = g.Count()}),
            TopProductos = _productos.OrderByDescending(p=> p.ValorTotal).Take(5).Select(p=> new {p.Id, p.Nombre, p.Cantidad, p.ValorTotal})
        };

        return JsonSerializer.Serialize(resumen, new JsonSerializerOptions {WriteIndented = true});
    }
    
}