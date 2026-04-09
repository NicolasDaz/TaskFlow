using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Service.cs
{
    
    public class TaskService
    {

        public List<TaskItem> Tareas = FileManager.cargar();
        public void CrearTarea()
        {
            TaskItem tarea = new TaskItem();
            try
            {
                Console.WriteLine("Ingrese el título de la tarea:");
                tarea.Title = Console.ReadLine();
                Console.WriteLine("Ingrese la descripción de la tarea (opcional):");
                tarea.Description = Console.ReadLine();
                Console.WriteLine("Ingrese el responsable de la tarea:");
                tarea.Responsible = Console.ReadLine();
                tarea.Id = GenerarId();
                Tareas.Add(tarea);
                Console.WriteLine("Tarea creada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error se ha encontrado un error {ex.Message}");
            }
        }

        public int GenerarId()
        {
            if (Tareas.Count == 0) return 1;
            return Tareas.Max(t => t.Id) + 1;
        }
    }
}
