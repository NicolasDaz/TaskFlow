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
    }
}
