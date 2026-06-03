# Sistema de Gestion de Inventario

Proyecto del curso **Fundamentos de .NET** 

## Requisitos
- .Net 10 SDK

## Como ejecutar
```
dotnet run
```

## Estructura del proyecto
InventarioApp/
├── Program.cs
├── InventarioApp.csproj
├── .gitignore
├── README.md
└── src/
    ├── Models/
    │   ├── CategoriaProducto.cs
    │   ├── EstadoProducto.cs
    │   ├── Producto.cs
    │   └── Proveedor.cs
    ├── Factories/
    │   └── ProductoFactory.cs
    └── Repositories/
        ├── IProductoRepository.cs
        └── InMemoryProductoRepository.cs


### InventarioApp/
- Program.cs # Punto de entrada
- InventarioApp.csproj # Configuracion
- .gitignore # Archivos ignorados por Git
- src/

## Progreso del curso
- [x] Modulo 1: El ecosistema .NET