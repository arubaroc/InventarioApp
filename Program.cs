// ============================================================
// SISTEMA DE INVENTARIO - Por Alvaro Calderón
// ============================================================

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

string nombreSistema = "Sistema de Gestion de Inventario";
int cantidadProductos = 0;
decimal valorTotalDelInventario = 0.00m;
bool sistemaActivo = true;

MostarBanner();
bool continuar = true;

while (continuar)
{
    MostrarMenu();
    string comando = LeerEntrada("inventario");
    continuar = ProcesarComando(comando);
    continuar = false;
}

// METODOS
bool ProcesarComando(string comando)
{
    switch (comando)
    {
        case "listar":
            ListarProductos();
            return true;
        case "agregar":
            AgregarProducto();
            return true;
        case "buscar":
            BuscarProducto();
            return true;
        case "salir":
            Console.WriteLine("Saliendo del programa...");
            return false;
        case "":
            return true;
        default:
            Console.WriteLine($"Error: se desconoce el comando: '{comando}'");
            Console.WriteLine("Comandos disponibles: listar, agregar, buscar, salir\n");
            return true;
    }
}

void ListarProductos()
{
    Console.WriteLine($"Lista de productos: {cantidadProductos}");
    Console.WriteLine($"Valor total del inventario: Q.{valorTotalDelInventario:N2}\n");
}

void AgregarProducto()
{

    Console.WriteLine($"Producto agregado: {cantidadProductos}");
}

void BuscarProducto()
{
    Console.WriteLine($"Buscando producto...");
}

string LeerEntrada(string prompt)
{
    // Console.Write($"{prompt}: ");
    // string? entrada = Console.ReadLine();
    // return string.IsNullOrWhiteSpace(entrada) ? "" : entrada.Trim().ToLower();
    string salida = "El prompt es: " + prompt;
    return salida;
}



/*
if (args.Length > 0)
{
    switch (args[0].ToLower())
    {
        case "--help":
        case "-h":
            MostrarAyuda();
            Environment.Exit(0);
            break;

        case "--version":
        case "-v":
            Console.WriteLine($"InventarioApp Version: {version}");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine($"Error: comando desconocido '{args[0]}'");
            Console.WriteLine("Usa --help para ver las opciones disponibles");
            Environment.Exit(2);
            break;
    }
}
*/


/*
string? nombre = null;
int longitud = nombre.Length;
Console.WriteLine($"La longitud del nombre es: {longitud}");
// Problema: ReadLine puede devolver null
Console.Write("Ingrese un entero: ");
string? entrada = Console.ReadLine();
int? longitud = entrada?.Length;
// Solucion Operador coalescing ??
//string comando = string.IsNullOrEmpty(entrada) ? "salir" : entrada;
string comandoLimpio = string.IsNullOrWhiteSpace(entrada) ? "salir" : entrada.Trim().ToLower();
Console.WriteLine($"Longitud: {longitud ?? 0}");
Console.WriteLine($"Comando: {comandoLimpio}");
*/

Console.WriteLine("Estado del sistema");
Console.WriteLine($"Nombre: {nombreSistema}");
Console.WriteLine($"Cantidad de productos registrados: {cantidadProductos}");
Console.WriteLine($"Valor total del inventario: Q.{valorTotalDelInventario:N2}");
Console.WriteLine($"Sistema activo: {(sistemaActivo ? "Si" : "No")}\n");
/*
// ------------------ cantidad ------------------
Console.Write("Ingrese una cantidad: ");
string? entrada = Console.ReadLine();
// Conversion segura TryParse
if (int.TryParse(entrada, out int cantidad))
{
    Console.Write($"Cantidad valida: {cantidad} \n");
    cantidadProductos = cantidad;
}
else
{
    Console.WriteLine("Error: Debe ingresar un numero entero");
}

// ------------------ precio ------------------
Console.Write("Ingrese un precio: ");
string? entradaPrecio = Console.ReadLine();
if (decimal.TryParse(entradaPrecio, out decimal precio))
{
    Console.Write($"Precio valido: {precio} \n");
    valorTotalDelInventario = cantidad * precio;
    Console.WriteLine($"Valor total del inventario: Q.{valorTotalDelInventario:N2}\n");
}
else
{
    Console.WriteLine("Error: Debe ingresar un numero decimal");
}
*/
/*
// Loop de nullabilidad
Console.WriteLine("Ingres algún comandos: listar, agregar, buscar, salir");
Console.WriteLine();

while (sistemaActivo)
{
    Console.Write("Inventario: ");
    string? entradaComando = Console.ReadLine();

    string comando = string.IsNullOrEmpty(entradaComando) ? "salir" : entradaComando.Trim().ToLower();
    //string comando = string.IsNullOrWhiteSpace(entradaComando) ? "salir" : entradaComando.Trim().ToLower();
    switch (comando)
    {
        case "salir":
            sistemaActivo = false;
            Console.WriteLine("Saliendo del programa...");
            break;
        case "listar":
            Console.WriteLine($"Lista de productos: {cantidadProductos}");
            break;
        case "":
            break;
        default:
            Console.WriteLine($"Error: se desconoce el comando: '{comando}'");
            Console.WriteLine("Comandos disponibles: listar, agregar, buscar, salir\n");
            break;
    }
}
*/
/*
Console.Write("Ingrese un comando o ingrese salir para terminar: ");
string? comandoSalir = Console.ReadLine();

if (string.IsNullOrWhiteSpace(comandoSalir) || comandoSalir.ToLower() == "salir")
{
    Console.WriteLine("Saliendo del programa...");
    Environment.Exit(0);
}
*/
/*
Console.WriteLine();
Console.WriteLine("Estructura del proyecto:");
Console.WriteLine("Configuracion .csproj");
Console.WriteLine("Carpet src/ creada");
Console.WriteLine("Metadatos configurados");
Console.WriteLine();
Console.WriteLine("Proximo paso: Agregar argumentos CL y configuracion de repositorio en github");
Console.WriteLine("==========================================");
*/
// Funciones

void MostarBanner()
{
    Console.WriteLine("==========================================");
    Console.WriteLine("    SISTEMA DE GESTIÓN DE INVENTARIO      ");
    Console.WriteLine("==========================================");
    Console.WriteLine();

    //     Console.WriteLine($"Version: {version}");
    //     Console.WriteLine($"Plataforma: {Environment.OSVersion}");
    //     Console.WriteLine($".NET Version: {Environment.Version}");
    //     Console.WriteLine();
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

void MostrarMenu()
{
    Console.WriteLine("Comandos disponibles:");
    Console.WriteLine("1.  listar   - Lista todos los productos");
    Console.WriteLine("2.  agregar   - Agrega un nuevo producto");
    Console.WriteLine("3.  buscar    - Busca un producto por nombre");
    Console.WriteLine("4.  salir     - Salir del programa \n");
}