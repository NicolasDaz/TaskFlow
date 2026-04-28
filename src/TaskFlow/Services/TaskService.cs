using System.Threading.Tasks;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> tareas;

        public TaskService()
        {
            tareas = CargarTareas();
        }
        public TaskItem? CrearTarea(string titulo, string descripción, string responsable)
        {
            TaskItem tarea = new TaskItem();

                tarea.Id = GenerarId();
                tarea.Title = titulo;
                tarea.Description = descripción;
                tarea.Responsible = responsable;
                tarea.Estado = Status.Pendiente;
                tarea.CreateAt = DateTime.Now;
                tareas.Add(tarea);
                GuardarCambios();
            return tarea;
        }
        public int GenerarId()
        {
            if (tareas.Count == 0) return 1;
            return tareas.Max(t => t.Id) + 1;
        }
        public List<TaskItem> ListarTareas()
        {
            return tareas;
        }

        public List<TaskItem> ListarTareasPorEstado(Status estado)
        {
            List<TaskItem> filtradas = tareas.Where(t => t.Estado == estado).ToList();

            if (filtradas.Count == 0)
            {
                throw new ArgumentNullException($"No hay tareas con estado: {estado}");
            }

            return filtradas;
        }
        public void UpdateTaskStatus(int id, Status newStatus)
        {
            if (id == 0) {
                throw new ArgumentException("El ID no puede ser nulo o cero.");
            }
            TaskItem? tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                throw new KeyNotFoundException($"No se encontró la tarea con ID: {id}");
            }

            tarea.Estado = newStatus;
            tarea.UpdateAt = DateTime.Now;
            GuardarCambios();

        }

        public void UpdateTaskResponsible(int id, string newResponsible)
        {
            if (id == 0) {
                throw new ArgumentException("El ID no puede ser nulo o cero.");
            }
            TaskItem? tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                throw new KeyNotFoundException($"No se encontró la tarea con ID: {id}");
            }

            tarea.Responsible = newResponsible;
            tarea.UpdateAt = DateTime.Now;
            GuardarCambios();
        }
        public bool EliminarTarea(int id)
        {
            if (id == 0) throw new ArgumentException("El ID no puede ser nulo o cero.");
            int index = tareas.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                tareas.RemoveAt(index);
                GuardarCambios();
                return true;
            }
            return false;
        }

        private void GuardarCambios()
        {
            FileManager.Guardar(tareas);
        }
        private List<TaskItem> CargarTareas()
        {
            return FileManager.Cargar();
        }
    }
}
