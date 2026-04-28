using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Utils
{
    public static class ConsoleHelper
    {
        public static void Pausa()
        {
            Console.WriteLine();
            Console.Write("  Presione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        public static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) return input;
                Console.WriteLine("Entrada no válida. Intenta de nuevo.");
            }
        }
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value)) return value;
                Console.WriteLine("Entrada no válida. Introduce un número entero.");
            }
        }
    }
}
