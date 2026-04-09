using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Services
{
    public class TaskService
    {
        public void CrearTarea() { }

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
