using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Models
{
    public enum Status
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public Status Estado { get; set; } = Status.Pendiente;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

        public override string ToString()
        {

            return $"id:{Id}\nTitulo:{Title}\nDescripción:{(string.IsNullOrEmpty(Description) ? "Sin Descripción" : Description)}\nEstado:{CambioEstado()}\nCreación:{CreateAt.ToString("G")}\nActualización:{(UpdateAt.HasValue ? UpdateAt.Value.ToString("G") : "-")}\n--------------------------------------------------";

        }

        public String CambioEstado()
        {
            switch (Estado)
            {
                case Status.EnProgreso:
                    return "En Progreso";
                case Status.Pendiente:
                    return "Pendiente";
                case Status.Completada:
                    return "Completada";
                default:
                    return "";
            }
        }
    }
}
