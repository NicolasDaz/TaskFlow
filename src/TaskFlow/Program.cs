using System;
using TaskFlow.Services;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow
{
    public class Program
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

                string opcion = ConsoleHelper.ReadNonEmptyString("Selecciona una opción: ");

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            Console.Clear();
                            string titulo = ConsoleHelper.ReadNonEmptyString("Título: ");
                            string desc = ConsoleHelper.ReadNonEmptyString("Descripción: ");
                            string resp = ConsoleHelper.ReadNonEmptyString("Responsable: ");
                            var creada = service.CrearTarea(titulo, desc, resp);
                            Console.WriteLine(creada != null ? $"Tarea creada: {creada}" : "No se pudo crear la tarea.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        ConsoleHelper.Pausa();
                        break;
                    case "2":
                        Console.Clear();
                        MostrarMenuListar(service);
                        break;
                    case "3":
                        Console.Clear();
                        try
                        {
                            int idEstado = ConsoleHelper.ReadInt("ID de la tarea: ");
                            int nuevoEstado = ConsoleHelper.ReadInt("Nuevo estado (0: Pendiente, 1: EnProgreso, 2: Completada): ");
                            if (!Enum.IsDefined(typeof(Status), nuevoEstado))
                            {
                                Console.WriteLine("Estado inválido.");
                                ConsoleHelper.Pausa();
                                break;
                            }
                            service.UpdateTaskStatus(idEstado, (Status)nuevoEstado);
                            Console.WriteLine("Estado actualizado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        ConsoleHelper.Pausa();
                        break;
                    case "4":
                        Console.Clear();
                        try
                        {
                            int idEliminar = ConsoleHelper.ReadInt("ID de la tarea a eliminar: ");
                            bool eliminado = service.EliminarTarea(idEliminar);
                            Console.WriteLine(eliminado ? "Tarea eliminada correctamente." : "No se encontró la tarea.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        ConsoleHelper.Pausa();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        ConsoleHelper.Pausa();
                        break;
                }
            }
        }

        private static void MostrarMenuListar(TaskService service)
        {
            while (true)
            {
                Console.WriteLine("\n--- LISTAR TAREAS ---");
                Console.WriteLine("1. Todas");
                Console.WriteLine("2. Por estado");
                Console.WriteLine("0. Volver");
                string opcion = ConsoleHelper.ReadNonEmptyString("Selecciona una opción: ");

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            var lista = service.ListarTareas();
                            MostrarLista(lista);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        ConsoleHelper.Pausa();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Estados disponibles:");
                            foreach (var name in Enum.GetNames(typeof(Status)))
                            {
                                Console.WriteLine($"- {name}");
                            }

                            int estadoNum = ConsoleHelper.ReadInt("Ingrese el número del estado (ej. 0, 1, 2): ");
                            if (!Enum.IsDefined(typeof(Status), estadoNum))
                            {
                                Console.WriteLine("Estado inválido.");
                                ConsoleHelper.Pausa();
                                break;
                            }
                            var filtradas = service.ListarTareasPorEstado((Status)estadoNum);
                            MostrarLista(filtradas);
                        }
                        catch (ArgumentNullException ex)
                        {   
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        ConsoleHelper.Pausa();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        ConsoleHelper.Pausa();
                        break;
                }
            }
        }

        private static void MostrarLista(System.Collections.Generic.List<TaskItem>? lista)
        {
            Console.Clear();
            if (lista == null || lista.Count == 0)
            {
                Console.WriteLine("No hay tareas para mostrar.");
                return;
            }

            foreach (var tarea in lista)
            {
                Console.WriteLine(tarea);
            }
        }
    }
}

