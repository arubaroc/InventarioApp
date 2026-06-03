using InventarioApp.Factories;
using InventarioApp.Models;
using InventarioApp.Repositories;

Console.WriteLine("=== Sistema de Inventario ===");

var repositorio = new InMemoryProductoRepository();



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