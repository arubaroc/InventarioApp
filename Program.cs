using InventarioApp.Factories;
using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infrastructure;

Console.WriteLine("=== Sistema de Inventario ===");

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