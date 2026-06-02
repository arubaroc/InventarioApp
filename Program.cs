// ============================================================
// SISTEMA DE INVENTARIO - Clase 1.1
// ============================================================

using System.Reflection; // Importar el espacio de nombres para trabajar con ensamblados

var assembly = Assembly.GetExecutingAssembly(); // Obtener información del ensamblado actual
var version = assembly.GetName().Version; // Obtener la versión del ensamblado

if (args.Length > 0)
{
    var command = args[0].ToLower();
    switch (command)
    {
        case "--help":
        case "-h":
            MostrarAyuda();
            Environment.Exit(0);
            break;
        case "--version":
        case "-v":
            Console.WriteLine($"Versión del sistema: {version}");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine($"Comando desconocido: {args[0]}");
            Console.WriteLine("Use --help para ver los comandos disponibles.");
            Environment.Exit(2);
            break;
    }
}

int cantidadProductos = 0; // Variable para almacenar la cantidad de productos en el inventario
decimal valrTotalInventario = 0.0m; // Variable para almacenar el valor total del inventario
bool sistemaActivo = true; // Variable para controlar el estado del sistema
String nombreSistema = "Sistema de Gestión de Inventario"; // Variable para almacenar el nombre del sistema

Console.WriteLine("Estado del sistema");
Console.WriteLine($"Nombre: {nombreSistema}");
Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
Console.WriteLine($"Valor total del inventario: {valrTotalInventario:C}");
Console.WriteLine($"Activo: {(sistemaActivo ? "Sí" : "No")}");

//MostrarBanner();
Console.Write("Ingrese un comando (o 'salir' para terminar): ");
string? entrada = Console.ReadLine();

if (string.IsNullOrEmpty(entrada) || entrada.ToLower() == "salir")
{
    Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");//STDout
    Environment.Exit(0);
}

/*
Console.WriteLine("Estructura del proyecto:");
Console.WriteLine(" InventarioApp/");
Console.WriteLine(" ├── InventarioApp.csproj");
Console.WriteLine(" ├── Program.cs");
Console.WriteLine(" ├── README.md");
Console.WriteLine(" ├── .gitignore");
Console.WriteLine(" └── src/");
Console.WriteLine("     └── Models/");

Console.WriteLine("Configuracion .csproject: Define el proyecto y sus dependencias.");
Console.WriteLine("Carpeta src/ creada para organizar el código fuente.");
Console.WriteLine("Metadatos configurados");

Console.WriteLine();
Console.WriteLine("Proximos pasos: Agregar argumentos CLI yy configuración del repositorio en GitHub");
*/
void MostrarBanner()
{
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║   SISTEMA DE GESTIÓN DE INVENTARIO   ║");
    Console.WriteLine("╚══════════════════════════════════════╝");
    Console.WriteLine();
    Console.WriteLine($"Versión: {version}");
    Console.WriteLine($".NET: {Environment.Version}");
    Console.WriteLine($"Sistema: {Environment.OSVersion.Platform}");
    Console.WriteLine();
}


void MostrarAyuda()
{
    Console.WriteLine("USO: InventarioApp [comando] [opciones]");
    Console.WriteLine();
    Console.WriteLine("COMANDOS:");
    Console.WriteLine("  --help, -h      Muestra esta ayuda");
    Console.WriteLine("  --version, -v   Muestra la version del programa");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine(" dotnet run -- --help");
    Console.WriteLine(" dotnet run -- --version");
}