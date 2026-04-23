using System;
using TaskFlow.Services;
using TaskFlow.Models;

namespace TaskFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskService service = new TaskService();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DE TAREAS ---");
                Console.WriteLine("1. Crear tarea");
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Cambiar estado de tarea");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("0. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Descripción: ");
                        string desc = Console.ReadLine();
                        Console.Write("Responsable: ");
                        string resp = Console.ReadLine();
                        service.CrearTarea(titulo, desc, resp);
                        break;
                    case "2":
                        service.ListarTareas();
                        break;
                    case "3":
                        Console.Write("ID de la tarea: ");
                        int idEstado = int.Parse(Console.ReadLine());
                        Console.Write("Nuevo estado (0: Pendiente, 1: EnProgreso, 2: Completada): ");
                        int nuevoEstado = int.Parse(Console.ReadLine());
                        service.UpdateTaskStatus(idEstado, (Status)nuevoEstado);
                        break;
                    case "4":
                        Console.Write("ID de la tarea a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        service.EliminarTarea(idEliminar); // O EliminarTareaPorId según tu método
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}

