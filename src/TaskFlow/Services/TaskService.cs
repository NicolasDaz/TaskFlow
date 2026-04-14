using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Service
{
    
    public class TaskService
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void UpdateTaskStatus(int id, Status newStatus)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);


            if (task != null)
            {
                task.Estado = newStatus;
                task.UpdateAt = DateTime.Now;
                Console.WriteLine("Estado actualizado correctamente!");
            }
            else
            {
                Console.WriteLine("No se encontro la tarea");
            }
        }
    }
}
