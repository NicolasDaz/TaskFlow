using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Services
{
    public class TaskService
    {
        public List<TaskItem> Tareas = FileManager.cargar();
        public TaskItem? CrearTarea(string titulo, string descripción, string responsable)
        {
            TaskItem tarea = new TaskItem();
            try
            {
                tarea.Id = GenerarId();
                tarea.Title = titulo;
                tarea.Description = descripción;
                tarea.Responsible = responsable;
                tarea.Estado = Status.Pendiente;
                tarea.CreateAt = DateTime.Now;
                Tareas.Add(tarea);
                FileManager.Guardar(Tareas);
                return tarea;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error se ha encontrado un error al crear la tarea {ex.Message}");
                return null;
            }
        }
        public int GenerarId()
        {
            if (Tareas.Count == 0) return 1;
            return Tareas.Max(t => t.Id) + 1;
        }
        public void ListarTareas()
        {
            List<TaskItem> tareas = FileManager.cargar();

            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Console.WriteLine($"\n===== LISTA DE TAREAS ({tareas.Count}) =====\n");
            foreach (TaskItem tarea in tareas)
            {
                Console.WriteLine(tarea.ToString());
            }
        }

        public void ListarTareasPorEstado(Status estado)
        {
            List<TaskItem> tareas = FileManager.cargar();
            List<TaskItem> filtradas = tareas.Where(t => t.Estado == estado).ToList();

            if (filtradas.Count == 0)
            {
                Console.WriteLine($"No hay tareas con estado: {estado}");
                return;
            }

            Console.WriteLine($"\n===== TAREAS {estado.ToString().ToUpper()} ({filtradas.Count}) =====\n");
            foreach (TaskItem tarea in filtradas)
            {
                Console.WriteLine(tarea.ToString());
            }
        }
    }
}
