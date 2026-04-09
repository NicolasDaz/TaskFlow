using TaskFlow.Service.cs;

namespace TaskFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskService service = new TaskService();

            Console.WriteLine("===== TaskFlow =====");
            Console.WriteLine("Listando tareas...\n");

            service.ListarTareas();
        }
    }
}
