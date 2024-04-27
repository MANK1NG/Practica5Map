using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear un tablero 3x3 con un texto de ejemplo
            string textMap = "oooooiooo";
            int rows = 3;
            int cols = 3;
            int maxItems = 1; // Cambia esto si deseas tener más elementos en el tablero

            // Crear una instancia del tablero
            Board board = new Board(rows, cols, textMap, maxItems);

            // Mostrar el tablero
            Console.WriteLine("Tablero creado:");
            board.PrintBoard();
        }
    }
}
