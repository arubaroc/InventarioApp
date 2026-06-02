// ============================================================
// SISTEMA DE INVENTARIO - Por Alvaro Calderón
// ============================================================

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

//string nombreSistema = "Sistema de Gestion de Inventario";
int cantidadProductos = 0;
decimal valorTotalDelInventario = 0.00m;
//bool sistemaActivo = true;

MostarBanner();
bool continuar = true;

while (continuar)
{
    MostrarMenu();
    string comando = LeerEntrada("inventario");
    Console.WriteLine($"Comando ingresado: '{comando}'\n");
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


// void MostrarEstadoDelSistema()
// {
// Console.WriteLine("Estado del sistema");
// Console.WriteLine($"Nombre: {nombreSistema}");
// Console.WriteLine($"Cantidad de productos registrados: {cantidadProductos}");
// Console.WriteLine($"Valor total del inventario: Q.{valorTotalDelInventario:N2}");
// Console.WriteLine($"Sistema activo: {(sistemaActivo ? "Si" : "No")}\n");
// }

void MostarBanner()
{
    Console.WriteLine("==========================================");
    Console.WriteLine("    SISTEMA DE GESTIÓN DE INVENTARIO      ");
    Console.WriteLine("==========================================");
    Console.WriteLine();
}


void MostrarMenu()
{
    Console.WriteLine("Comandos disponibles:");
    Console.WriteLine("1.  listar   - Lista todos los productos");
    Console.WriteLine("2.  agregar   - Agrega un nuevo producto");
    Console.WriteLine("3.  buscar    - Busca un producto por nombre");
    Console.WriteLine("4.  salir     - Salir del programa \n");
}