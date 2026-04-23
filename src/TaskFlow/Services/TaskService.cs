using System.Threading.Tasks;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> tareas = FileManager.Cargar();
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
                tareas.Add(tarea);
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
            if (tareas.Count == 0) return 1;
            return tareas.Max(t => t.Id) + 1;
        }
        public void ListarTareas()
        {
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
        public void UpdateTaskStatus(int id, Status newStatus)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);


            if (tarea != null)
            {
                tarea.Estado = newStatus;
                tarea.UpdateAt = DateTime.Now;
                Console.WriteLine("Estado actualizado correctamente!");
            }
            else
            {
                Console.WriteLine("No se encontro la tarea");
            }
        }
<<<<<<< feature/menu-tareas
<<<<<<< HEAD
        public void EliminarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
                FileManager.Guardar(tareas);
                Console.WriteLine("Tarea eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró la tarea con el ID especificado.");
            }
        }

=======
        public bool EliminarTareaPorId(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                Console.WriteLine("No se encontró la tarea");
                return false;
            }

            tareas.Remove(tarea);

            // Intentar guardar cambios en disco; informar si falla.
            bool guardado = FileManager.Guardar(tareas);
            if (guardado)
            {
                Console.WriteLine("Tarea eliminada correctamente!");
            }
            else
            {
                Console.WriteLine("Tarea eliminada, pero no se pudo guardar en disco.");
            }

            return true;
        }
>>>>>>> 47f49be5ed8511a600063a02ee4e5119233de645
=======
        public bool EliminarTarea(int id)
        {
            if (tareas == null) throw new InvalidOperationException("La lista de tareas no está inicializada.");
            var index = tareas.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                tareas.RemoveAt(index);
                Console.WriteLine("Tarea eliminada correctamente!");
                return true;
            }

            Console.WriteLine("No se encontró la tarea");
            return false;
        }
>>>>>>> devop
    }
}
