using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Schema;
using TaskFlow.Models;

namespace TaskFlow.Utils
{
    public static class FileManager
    {
        public static readonly string carpetaData = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        public static readonly string rutaArchivo = Path.Combine(carpetaData, "tasks.json");

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };

        public static List<TaskItem> cargar() {
            try
            {
                ExisteArchivo();
                string archivo = File.ReadAllText(rutaArchivo);

                if (string.IsNullOrEmpty(archivo))
                {
                    return new List<TaskItem>();
                }

                return JsonSerializer.Deserialize<List<TaskItem>>(archivo);

            }catch(Exception ex)
            {
                Console.WriteLine($"Error al cargar las tareas: {ex.Message}");
                return new List<TaskItem>();
            }

        }

        public static bool Guardar(List<TaskItem> tareas)
        {
            try
            {
                ExisteArchivo();
                string archivo = JsonSerializer.Serialize(tareas, Options);
                File.WriteAllText(rutaArchivo, archivo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar las tareas: {ex.Message}");
                return false;
            }
        }

        public static void ExisteArchivo() {
            if (!Directory.Exists(carpetaData)) {
                Directory.CreateDirectory(carpetaData);
            }
            if (!File.Exists(rutaArchivo)) {
                File.WriteAllText(rutaArchivo, "[]");
            }
        }

    }
}
