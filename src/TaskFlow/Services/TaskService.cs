using TaskFlow.Models;
using TaskFlow.Utils;

public class TaskService
{
    public void CrearTarea() { }

    public void ListarTareas()
    {
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
