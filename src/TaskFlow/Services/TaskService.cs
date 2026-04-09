using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Service.cs
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
    }
}
