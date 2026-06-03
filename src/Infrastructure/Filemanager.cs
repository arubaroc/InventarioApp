namespace InventarioApp.Infrastructure;

public class Filemanager
{
    public void Escribir(string ruta, string contenido)
    {
        File.WriteAllText(ruta, contenido);
    }

    public string Leer(string ruta)
    {
        return File.ReadAllText(ruta);
    }

    public void Agregar(string ruta, string contenido)
    {
        File.AppendAllText(ruta, contenido);
    }

    public bool ExisteArchivo(string ruta)
    {
        return File.Exists(ruta);
    }

    public void EliminarArchivo(string ruta)
    {
        if (File.Exists(ruta))
        {
            File.Delete(ruta);
        }
    }

    public string[] LeerLineas(string ruta)
    {
        return File.ReadAllLines(ruta);
    }

    public void EscribirLineas(string ruta, IEnumerable<string> lineas)
    {
        File.WriteAllLines(ruta, lineas);
    }

    public void CrearDirectorio(string ruta)
    {
        if (!Directory.Exists(ruta))
        {
            Directory.CreateDirectory(ruta);
        }
    }

    public string[] ObtenerArchivos(string directorio, string patron = "*")
    {
        if (Directory.Exists(directorio))
        {
            return Directory.GetFiles(directorio, patron);
        }
        return Array.Empty<string>();
    }

}