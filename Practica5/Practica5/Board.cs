using System;
namespace Game
{
    public enum Direction {North, East, South, West};

    public struct Item
    { 
        public int value;
        public int row;
        public int col;
    }

    public class Board
    {


        /// <summary>
        /// Matrix of chars that represent the board:
        /// - 0: Empty space
        /// - w: Wall
        /// - i: Item
        /// - g: Goal
        /// </summary>
        char[,] map;

        /// <summary>
        /// Number of rows and cols of the map
        /// </summary>
        public int ROWS, COLS;

        /// <summary>
        /// Array with the items contained in this board
        /// </summary>
        Item[] itemsInBoard;

        /// <summary>
        /// The number items in this board.
        /// </summary>
        public int numItemsInBoard;


        public void PrintBoard()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    

    /// <summary>
    /// Creates a new board. 
    /// </summary>
    /// <param name="r">Number of rows</param>
    /// <param name="c">Number of columns</param>
    /// <param name="textMap">String of size r*c that represents the map (walls, goals and empty spaces)</param>
    /// <param name="maxItems">Max number of items contained in the board.</param>
    public Board(int r, int c, string textMap, int maxItems)
        {
            // Establecer el número de filas y columnas del tablero
            ROWS = r; 
            COLS = c;
            // Inicializar la matriz que representa el tablero y el arreglo de ítems
            map = new char[ROWS, COLS];
            itemsInBoard = new Item[maxItems];
            numItemsInBoard = 0;

            // Recorrer la cadena de texto que representa el mapa
            for (int i = 0; i < textMap.Length; i++)
            {
                // Calcular la fila y columna actual en base al índice
                int row = i / COLS;
                int col = i % COLS;

                // Asignar el carácter actual al mapa en la posición correspondiente
                map[row, col] = textMap[i];
                
                // Si el carácter actual es 'i', agregar un ítem en esa posición
                if (textMap[i] == 'i')
                {
                    // Agregar un ítem en la posición actual con valor 0
                    AddItem(row, col, 0); 
                }
            }
        }

        /// <summary>
        /// Checks if there is a wall in a position. If the position is out of bounds it returns the same 
        /// result as if a wall was there.
        /// </summary>
        /// <returns>True if there  is a wall in position (r,c); false, otherwise</returns>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        public bool IsWallAt(int r, int c)
        {
            // Verificar si la posición está dentro de los límites del tablero y si es una pared
            if (r < 0 || r >= ROWS || c < 0 || c >= COLS)
            {
                return true; // Fuera de los límites del tablero, considerado como una pared
            }
            // Verificar si el carácter en la posición es una pared
            return map[r, c] == 'w';
        }

        /// <summary>
        /// Checks if there is an item in a position. If the position is out of bounds it returns false
        /// </summary>
        /// <returns><c>true</c> if there  is an item in position (r,c); <c>false</c> otherwise</returns>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        public bool ContainsItem(int r, int c)
        {
            ///REVISAR
            if (r < 0 || r >= ROWS || c < 0 || c >= COLS)
            {
                return false; 
            }

            return map[r, c] == 'i';
        }

        /// <summary>
        /// Adds an item with a value in a position The position must be inside board bounds and it must be empty.
        /// The map should be updated with the new edded item.
        /// It throws an exception if the maximum number of items was exceeded.
        /// </summary>
        /// <returns><c>true</c>, if the item was added; <c>false</c> otherwise.</returns>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <param name="value">Item value</param>
        public bool AddItem(int r, int c, int value)
        {

            // Verificar si la posición está dentro de los límites del tablero, no es una pared o no contiene un ítem
            if (r < 0 || r >= ROWS || c < 0 || c >= COLS || IsWallAt(r, c) || ContainsItem(r, c))
            {
                return false; 
            }
            // Verificar si se excede el número máximo de ítems
            if (numItemsInBoard >= itemsInBoard.Length)
            {
                throw new Exception("Maximum number of items exceeded."); // Lanzar una excepción si se excede el número máximo de ítems
            }
            // Agregar el ítem  y actualizar el tablero
            itemsInBoard[numItemsInBoard] = new Item { row = r, col = c, value = value };
            numItemsInBoard++;

            map[r, c] = 'i'; 
            return true;
        }


        /// <summary>
        /// Picks an item in a position, if it exists
        /// </summary>
        /// <returns>
        /// The position of the item in the itemsInBoard array, 
        /// or -1 if there is not any item in that position
        /// </returns>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        public int PickItem(int r, int c)
        {
            // Verificar si hay un ítem en la posición especificada
            for (int i = 0; i < numItemsInBoard; i++)
            {
                if (itemsInBoard[i].row == r && itemsInBoard[i].col == c)
                {
                    // Si hay un ítem en la posición especificada, devolver su índice en el arreglo itemsInBoard
                    return i;
                }
            }
            // Si no hay ningún ítem en la posición especificada, devolver -1
            return -1;
        }


        /// <summary>
        /// Checks if a position is a goal
        /// </summary>
        /// <returns><c>true</c> if the position is a goal, <c>false</c> otherwise</returns>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
         public bool IsGoalAt(int row, int col)
        {
            // Verificar si el carácter en la posición especificada es una meta
            return map[row, col] == 'g';
        }

        /// <summary>
        /// Gets the i-th item in the itemsInBoard array. It throws an exception if the item does not exist.
        /// </summary>
        /// <returns>The item</returns>
        /// <param name="i">The index in the itemsInBoard array</param>
        public Item GetItem(int i)
        {
            // Verificar si el índice está dentro de los límites del arreglo itemsInBoard
            if (i < 0 || i >= numItemsInBoard)
            {
                throw new IndexOutOfRangeException("Item index out of range."); // Lanzar una excepción si el índice está fuera de rango
            }
            // Devolver el ítem en la posición especificada
            return itemsInBoard[i];
        }
       
    }
}

