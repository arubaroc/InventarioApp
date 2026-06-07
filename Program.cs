using InventarioApp.Factories;
using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infrastructure;
using InventarioApp.Services;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("=== Sistema de Inventario ===");

var servicio = new InventarioService();
bool activo = true;

while (activo)
{
    MostrarMenu();
    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            AgregarProducto();
            break;
        case "2":
            ListarProductos();
            break;
        case "3":
            BuscarPorId();
            break;
        case "4":
            EliminarProducto();
            break;
        case "5":
            BuscarPorCategoria();
            break;
        case "6":
            MostrarResumen();
            break;
        case "7":
            MostrarStockBajo();
            break;
        case "8":
            MostrarEstadisticas();
            break;
        case "9":
            ExportarCsv();
            break;
        case "10":
            activo = false;
            Console.WriteLine("\nHasta la proxima.!");
            break;
        default:
        Console.WriteLine("\nNo existe la oopcion seleccionada.");
        break;
        
            }
}



void MostrarMenu()
{
    Console.WriteLine("\n === SITEMA DE INVENTARIO ===");
    Console.WriteLine("1. Agregar Producto");
    Console.WriteLine("2. Listar Producto");
    Console.WriteLine("3. Buscar Producto Por ID");
    Console.WriteLine("4. Eliminar Producto");
    Console.WriteLine("5. Buscar por Categoría");
    Console.WriteLine("6. Ver Resumen");
    Console.WriteLine("7. Ver Stock Bajo");
    Console.WriteLine("8. Ver Estadisticas");
    Console.WriteLine("9. Exportar CSV");
    Console.WriteLine("10. Salir");
    Console.Write("\n Seleccione una opción: ");
}

void AgregarProducto()
{
    Console.Write("\nNombre: ");
    string nombre = Console.ReadLine() ?? "";

    Console.Write("\nDescripción: ");
    string descripcion = Console.ReadLine() ?? "objeto";

    Console.Write("\nPrecoi: ");
    decimal precio = decimal.Parse(Console.ReadLine() ?? "0");

    Console.Write("\nCantidad: ");
    int cantidad = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine("\nCategorias: Electrónica, Ropa, Alimentos, Hogar, Deportes, Libros, Muebles, Otros");
    Console.Write("Categoría: ");
    string categoriaStr = Console.ReadLine() ?? "Otros";

    if (Enum.TryParse<CategoriaProducto>(categoriaStr,true, out var categoria))
    {
        servicio.AgregarProducto(nombre,descripcion,precio,cantidad,categoria);
        Console.WriteLine("\nProducto agregado con éxito");
    } else
    {
        Console.WriteLine("\nCategoría no válida.");
    }
}

void ListarProductos()
{
    var productos = servicio.ObtenerTodosLosProductos();
    if (!productos.Any())
    {
        Console.WriteLine("\nNo hay productos.");
        return;
    }

    Console.WriteLine("\n=== PRODUCTOS ===");
    foreach (var producto in productos)
    {
        Console.WriteLine($"ID: {producto.Id} | Nombre: {producto.Nombre} | Descripcion: {producto.Descripcion} | Precio: {producto.Precio} | Cantidad: {producto.Cantidad} | Total: Q.{producto.ValorTotal} | Categoría: {producto.Categoria}");
    }

}

void ExportarCsv()
{
    string csv = servicio.ExportarCsv();
    Console.WriteLine($"\n{csv}");
}

void MostrarEstadisticas()
{
    Console.WriteLine("\n=== ESTADÍSTICAS ===");
    Console.WriteLine($"valor total del inventario: Q.{servicio.ObtenerValorTotalInventario()}");
    Console.WriteLine($"Precio promedio: Q.{servicio.ObtenerPrecioPromedio():F2}");
    var masCaro = servicio.ObtenerProductoMasCaro();
    if (masCaro != null)
    {
        Console.WriteLine($"Producto más caro: {masCaro.Nombre}(Q.{masCaro.Precio})");
    }
}

void MostrarStockBajo()
{
    var reporte = servicio.GenerarReporteStockBajo();
    Console.WriteLine($"\n{reporte}");
}

void MostrarResumen()
{
    var reporte = servicio.GenerarResumen();
    Console.WriteLine($"\n{reporte}");
}

void BuscarPorCategoria()
{
    Console.WriteLine("\nCategorias: Electrónica, Ropa, Alimentos, Hogar, Deportes, Libros, Muebles, Otros");
    Console.Write("Categoria: ");
    string categoriaStr = Console.ReadLine() ?? "Otros";

    if (Enum.TryParse<CategoriaProducto>(categoriaStr,true, out var categoria))
    {
        var productos = servicio.BuscarPorCategoria(categoria);
        if (!productos.Any())
        {
            Console.WriteLine("\nNo hau productos en esta categoría.");
            return;
        }
        Console.WriteLine($"=== PRODUCTOS EN LA CATEGORIA {categoria}===");
        foreach (var producto in productos)
        {
            Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Q{producto.Precio} | Cantidad: {producto.Cantidad}");

        }
    } else
    {
        Console.WriteLine("\nCategoría no válida.");
    } 

}

void EliminarProducto()
{
    Console.Write("\nId del producto a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var producto = servicio.ObtenerProductoPorId(id);
    if (producto != null)
    {
        servicio.EliminarProducto(id);
        Console.WriteLine("\nProducto eliminao.");
    } else
    {
        Console.WriteLine("\nProducto no encontrado.");
    }
}

void BuscarPorId()
{
    Console.Write("\nID del producto: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var producto = servicio.ObtenerProductoPorId(id);
    if (producto != null)
    {
        Console.WriteLine($"ID: {producto.Id}");
        Console.WriteLine($"Nombre: {producto.Nombre}");
        Console.WriteLine($"Descripción: {producto.Descripcion}");
        Console.WriteLine($"Precio: {producto.Precio}");
        Console.WriteLine($"Cantidad: {producto.Cantidad}");
        Console.WriteLine($"Valor Total: {producto.ValorTotal}");
        Console.WriteLine($"Categoría: {producto.Categoria}");
    }
    else
    {
        Console.WriteLine("\nProducto no encontrado.");
    }
}












/*
var productos = new List<Producto>
{
    ProductoFactory.Crear("Laptop", "lenovo",123.00m, 3, CategoriaProducto.Electronica),
    ProductoFactory.Crear("Camisa","polo", 45.00m,15,CategoriaProducto.Ropa),
    ProductoFactory.Crear("Arroz", "grano", 12.00m, 50, CategoriaProducto.Alimentos),
    ProductoFactory.Crear("Lampara", "electrica", 35.00m, 2, CategoriaProducto.Hogar),
    ProductoFactory.Crear("Balón", "hule", 25.00m, 8, CategoriaProducto.Juguetes),
    ProductoFactory.Crear("Mesa","madera",150.00m,4, CategoriaProducto.Muebles)
};

var generarador = new GeneradorReportes(productos);
Console.WriteLine("");
Console.WriteLine(generarador.GenerarResumen());
Console.WriteLine("\n");

Console.WriteLine(generarador.GenerarReporteStockBajo());
Console.WriteLine("\n");

Console.WriteLine(generarador.GenerarReporteTopProductos());
Console.WriteLine("\n");

Console.WriteLine(generarador.ExportarCsv());
Console.WriteLine("\n");

Console.WriteLine(generarador.ExportarResumenJson());




var almacenamiento = new JsonInventarioStorage();
var productos = new List<Producto>
{
    new Producto
    {
        Id = 1,
        Nombre = "Laptop HP",
        Descripcion = "Laptop HP Pavilion 15 con procesador Intel Core i7, 16GB RAM, 512GB SSD",
        Precio = 1200.00m,
        Cantidad = 10,
        Categoria = CategoriaProducto.Electronica,
        Estado = EstadoProducto.Activo
    },
    new Producto
    {
        Id = 2,
        Nombre = "Teléfono Samsung",
        Descripcion = "Teléfono Samsung Galaxy S21 con pantalla AMOLED, 128GB almacenamiento",
        Precio = 800.00m,
        Cantidad = 20,
        Categoria = CategoriaProducto.Electronica,
        Estado = EstadoProducto.Activo
    }
};


Console.WriteLine("---------------------------------------------");


string ruta = "inventario_text.json";

almacenamiento.CrearBackup(ruta);
almacenamiento.Guardar(productos, ruta);

Console.WriteLine("Inventario guardado correctamente");
var productosCargados = almacenamiento.Cargar(ruta);

Console.WriteLine("Inventario cargado correctamente: ");

foreach (var p in productosCargados)
{
    Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Cantidad: {p.Cantidad}, Categoria: {p.Categoria}, Estado: {p.Estado}");
}
*/


/*
var repositorio = new InMemoryProductoRepository();
var fileManager = new Filemanager();
string contenido = "Inventario actualizado";
fileManager.Escribir("inventario.txt", contenido);

string leerContenido = fileManager.Leer("inventario.txt");
Console.WriteLine($"Contenido del archivo: {leerContenido}");

var laptop = ProductoFactory.Crear(
    nombre: "Laptop HP",
    descripcion: "Laptop HP Pavilion 15 con procesador Intel Core i7, 16GB RAM, 512GB SSD",
    precio: 1200.00m,
    cantidad: 10,
    categoria: CategoriaProducto.Electronica
);

var telefono = ProductoFactory.Crear(
    nombre: "Teléfono Samsung",
    descripcion: "Teléfono Samsung Galaxy S21 con pantalla AMOLED, 128GB almacenamiento",
    precio: 800.00m,
    cantidad: 20,
    categoria: CategoriaProducto.Electronica
);
var mouse = ProductoFactory.Crear(
    nombre: "Mouse Logitech",
    descripcion: "Mouse inalámbrico Logitech MX Master 3 con batería recargable",
    precio: 100.00m,
    cantidad: 15,
    categoria: CategoriaProducto.Accesorios
);

var teclado = ProductoFactory.Crear(
    nombre: "Teclado Mecánico",
    descripcion: "Teclado mecánico Razer BlackWidow con retroiluminación RGB",
    precio: 150.00m,
    cantidad: 5,
    categoria: CategoriaProducto.Accesorios
);

var silla = ProductoFactory.Crear(
    nombre: "Silla Ergonómica",
    descripcion: "Silla ergonómica Herman Miller Aeron con soporte lumbar ajustable",
    precio: 1200.00m,
    cantidad: 3,
    categoria: CategoriaProducto.Muebles
);

var escritorio = ProductoFactory.Crear(
    nombre: "Escritorio de Oficina",
    descripcion: "Escritorio de oficina con superficie de madera y estructura metálica",
    precio: 300.00m,
    cantidad: 7,
    categoria: CategoriaProducto.Muebles
);

repositorio.Agregar(laptop);
repositorio.Agregar(telefono);
repositorio.Agregar(mouse);
repositorio.Agregar(teclado);
repositorio.Agregar(silla);
repositorio.Agregar(escritorio);

Console.WriteLine("Productos agregados al inventario:");

Console.WriteLine(($"Productos agregados: {repositorio.Cantidad}\n"));


// Consultas LINQ
Console.WriteLine("=== Productos por Categoría: Accesorios ===");
var electronica = repositorio.BuscarPorCategoria(CategoriaProducto.Electronica);
foreach (var producto in electronica)
{
    Console.WriteLine($" - {producto.Nombre} (Q.{producto.Precio})");
}

Console.WriteLine("\n=== Productos con 'Mouse' en el nombre ===");
var conMouse = repositorio.BuscarPorNombre("Mouse");
foreach (var producto in conMouse)
{
    Console.WriteLine($" - {producto.Nombre} (Q.{producto.Precio})");
}


Console.WriteLine("\n=== Obtener nombres de productos ===");
var nombres = repositorio.ObtenerNombresProductos();
Console.WriteLine($"\n Todos los nombres: {string.Join(", ", nombres)}");

var hayStockBajo = repositorio.ExisteStockBajo();
Console.WriteLine($"\n ¿Hay productos con stock bajo? {(hayStockBajo ? "Sí" : "No")}");

*/