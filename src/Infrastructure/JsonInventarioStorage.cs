using System.Text.Json;
using System.Text.Json.Serialization;
using InventarioApp.Infrastructure;

using InventarioApp.Models;

namespace InventarioApp.Infrastructure;




public class JsonInventarioStorage
{
    private readonly Filemanager _fileManager;
    private readonly JsonSerializerOptions _jsonOptions;

    public JsonInventarioStorage()
    {
        _fileManager = new Filemanager();
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };
    }

    public void Guardar(List<Producto> productos, string ruta)
    {
        string json = JsonSerializer.Serialize(productos, _jsonOptions);
        _fileManager.Escribir(ruta, json);
    }

    public List<Producto> Cargar(string ruta)
    {
        if (!_fileManager.ExisteArchivo(ruta))
        {
            return new List<Producto>();
        }

        string json = _fileManager.Leer(ruta);
        return JsonSerializer.Deserialize<List<Producto>>(json, _jsonOptions) ?? new List<Producto>();
    }

    public string CrearBackup(string ruta)
    {
        if (!_fileManager.ExisteArchivo(ruta))
        {
            throw new FileNotFoundException("El archivo de inventario no existe.", ruta);
        }

        string directorio = Path.GetDirectoryName(ruta);
        string nombreSinExtencion = Path.GetFileNameWithoutExtension(ruta);
        string extension = Path.GetExtension(ruta);
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        string rutaBakup = Path.Combine
        (
            directorio ?? ".",
            $"{nombreSinExtencion}_backup{timestamp}{extension}"
        );

        File.Copy(ruta, rutaBakup);

        //string backupRuta = $"{Path.GetFileNameWithoutExtension(ruta)}_backup_{DateTime.Now:yyyyMMddHHmmss}.json";
        //_fileManager.Escribir(backupRuta, _fileManager.Leer(ruta));
        return rutaBakup;
    }

}