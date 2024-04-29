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
        public static void Main(string[] args)
        {
           /* // Crear un tablero 3x3 con un texto de ejemplo
            string textMap = "oooooiooo";
            int rows = 3;
            int cols = 3;
            int maxItems = 1; // Cambia esto si deseas tener más elementos en el tablero

            // Crear una instancia del tablero y jugador
            Board board = new Board(rows, cols, textMap, maxItems);
            Player player = new Player();

            // Mostrar el tablero
            Console.WriteLine("Tablero creado:");
            board.PrintBoard();

            //Pedir dirección
            Console.WriteLine("Dirección inicial(N, E, S, W): ");
            string iniDirecion=Console.ReadLine();

            Direction iniDirec= new Direction();
            if (iniDirecion == "E") iniDirec = Direction.East;
            else if (iniDirecion == "N") iniDirec = Direction.North;
            else if (iniDirecion == "W") iniDirec = Direction.West;
            else if (iniDirecion == "S") iniDirec = Direction.South;
            else Console.WriteLine("Error: información incorrecta");

            while (!player.GoalReached(board))
            {
                player.PickItem(board);

                Console.WriteLine("Tablero:");
                board.PrintBoard();
                Console.WriteLine("Juagador: "+ player.row+ player.col);
                
                player.Move(board, iniDirec);
            }
            if (player.GoalReached(board)) Console.WriteLine("Meta");*/
        }
    }
}
