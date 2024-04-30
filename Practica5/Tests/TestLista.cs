using System;
using Game;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace Tests
{
    [TestFixture]
    public class TestLista
    {
        /// <summary>
        /// Clase Board
        /// </summary>
        [Test]
        public void IsBoardInicialize()
        {
            //Arange
            int rows = 3;
            int cols = 3;
            string textMap = "00g" + "0w0" + "i0i";
            int maxItems = 3;
            //Act
            Board board = new Board(rows, cols, textMap, maxItems);

            // Assert
            ClassicAssert.AreEqual('0', board.map[0,0]);
            ClassicAssert.AreEqual('0', board.map[0,1]);
            ClassicAssert.AreEqual('g', board.map[0,2]);
            ClassicAssert.AreEqual('0', board.map[1,0]);
            ClassicAssert.AreEqual('w', board.map[1,1]);
            ClassicAssert.AreEqual('0', board.map[1,2]);
            ClassicAssert.AreEqual('i', board.map[2,0]);
            ClassicAssert.AreEqual('0', board.map[2,1]);
            ClassicAssert.AreEqual('i', board.map[2,2]);

        }
        [Test]
        public void TamBoard()

        { 
            //Arange
            int rows = 3;
            int cols = 3;
            string textMap = "00g" + "0w0" + "i0i";
            int maxItems = 3;

            //Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool TamBoardCorrect = false;

            if (board.ROWS == 3 || board.COLS == 3)
            {
                TamBoardCorrect = true;
            }
            ClassicAssert.IsTrue(TamBoardCorrect, "ERROR: el tamaño del tablero no es correcto");
        }
        [Test]
        public void AddItems()

        {
            //Arange
            int rows = 3;
            int cols = 3;
            string textMap = "00g" + "0w0" + "i0i";
            int maxItems = 5;

            //Act
            Board board = new Board(rows, cols, textMap, maxItems);

            ClassicAssert.IsTrue(board.ContainsItem(2, 0));
            ClassicAssert.IsTrue(board.ContainsItem(2, 2));

        }

        ///<summary>
        /// Clase IsWallAt
        /// </summary>
        [Test]
        public void RetornoTrueSiHayPared()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "www" +"wiw" + "www";
            int maxItems = 1;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            bool result1 = board.IsWallAt(0, 0); 
            bool result2 = board.IsWallAt(1, 0); 
            bool result3 = board.IsWallAt(2, 2); 

            // Assert
            ClassicAssert.IsTrue(result1);
            ClassicAssert.IsTrue(result2);
            ClassicAssert.IsTrue(result3);
        }

        [Test]
        public void RetornoFalseSiNoHayPared()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "0w0" + "wiw" + "w0w";
            int maxItems = 1;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            bool result1 = board.IsWallAt(0, 0);
            bool result2 = board.IsWallAt(0, 2);
            bool result3 = board.IsWallAt(2, 1);

            // Assert
            ClassicAssert.IsFalse(result1);
            ClassicAssert.IsFalse(result2);
            ClassicAssert.IsFalse(result3);
        }
        [Test]
        public void RetornaTrueSiEstaFueraDeLosLimites()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "www" + "wiw" +"www";
            int maxItems = 1;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.IsWallAt(-1, 1); 
            bool result2 = board.IsWallAt(1, -1); 
            bool result3 = board.IsWallAt(3, 1);
            bool result4 = board.IsWallAt(1, 3);

            // Assert
            ClassicAssert.IsTrue(result1);
            ClassicAssert.IsTrue(result2);
            ClassicAssert.IsTrue(result3);
            ClassicAssert.IsTrue(result4);
        }

        ///<summary>
        ///Clase ContainItem
        /// </summary>
        [Test]
        public void RetornaTrueSiTieneItem()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "www" + "iiw" + "www";
            int maxItems = 4;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.ContainsItem(1, 1);
            bool result2 = board.ContainsItem(1, 0);
            

            // Assert
            ClassicAssert.IsTrue(result1);
            ClassicAssert.IsTrue(result2);
        }
        [Test]

        public void RetornaFalsoSiNoTieneItem()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "www" + "wiw" + "www";
            int maxItems = 1;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.ContainsItem(1, 0);
            bool result2 = board.ContainsItem(1, 2);


            // Assert
            ClassicAssert.IsFalse(result1);
            ClassicAssert.IsFalse(result2);
        }
        [Test]

        public void RetornaFalseSiEstaFueraDeLosLimites()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "www" + "wiw" + "www";
            int maxItems = 1;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.ContainsItem(-1, 1);
            bool result2 = board.ContainsItem(-2, 0);


            // Assert
            ClassicAssert.IsFalse(result1);
            ClassicAssert.IsFalse(result2);
        }

        ///<summary>
        ///Clase AdddItem
        ///</summary>
        [Test]

        public void AnadeItemCorrectamente()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "000" + "000";
            int maxItems = 5;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.AddItem(1, 1, 5);


            // Assert
            ClassicAssert.IsTrue(result1);
            ClassicAssert.IsTrue(board.ContainsItem(1,1));
        }
        [Test]
        public void RetornaFalsoSiItemEnRoca()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0w0" + "000";
            int maxItems = 5;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.AddItem(1, 1, 5);


            // Assert
            ClassicAssert.IsFalse(result1);
            ClassicAssert.IsFalse(board.ContainsItem(1, 1));
        }

        [Test]
        public void RetornaFalsoSiItemEnItem()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0i0" + "000";
            int maxItems = 5;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.AddItem(1, 1, 5);


            // Assert
            ClassicAssert.IsFalse(result1);
            ClassicAssert.AreEqual(1, board.numItemsInBoard);
        }
        [Test]
        public void RetornaFalsoSiItemFueraDeLosLimites()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "000" + "000";
            int maxItems = 5;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);

            bool result1 = board.AddItem(-1, 1, 5);
            bool result2 = board.AddItem(-2,-1, 5);


            // Assert
            
            ClassicAssert.IsFalse(result1);
            ClassicAssert.IsFalse(result2);
            ClassicAssert.AreEqual(0, board.numItemsInBoard);
        }
        [Test]
        public void RetornaFalsoSiSuperaItemsMaximos()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "000" + "000";
            int maxItems = 1;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            board.AddItem(0, 0, 5);
            bool result1 = board.AddItem(1, 1, 5);
           


            // Assert

            ClassicAssert.IsFalse(result1);
            ClassicAssert.AreEqual(1, board.numItemsInBoard);
        }
        ///<summary>
        ///Clase PickItem
        /// </summary>
        
        [Test]
        public void RetornaTrueSiRecojeItem()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0i0" + "000";
            int maxItems = 1;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            int numItems = 0;


            // Assert

            ClassicAssert.AreEqual(numItems, board.PickItem(1,1));
        }

        [Test]
        public void RetornaFalseSiItemNoExiste()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0i0" + "000";
            int maxItems = 1;

            // Act
            Board board = new Board(rows, cols, textMap, maxItems);


            // Assert

            ClassicAssert.AreEqual(-1, board.PickItem(0, 1));
        }
        [Test]
        public void RetornaFalseSiFueraDeLosLimites()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0i0" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);


            // Assert

            ClassicAssert.AreEqual(-1, board.PickItem(-10, 10));
        }


        [Test]
        public void RetornaTrueSiHayItemYFalseSiNoHay()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "iii" + "0i0" + "ii0";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            


            // Assert
            ClassicAssert.AreEqual(0, board.PickItem(0, 0));
            ClassicAssert.AreEqual(3, board.PickItem(1, 1));
            ClassicAssert.AreEqual(4, board.PickItem(2, 0));
        }
        ///<summary>
        ///Clase IsGoalAt
        /// </summary>

        [Test]
        public void RetornaTrueSiHayFinal()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0g0" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);



            // Assert
            ClassicAssert.IsTrue(board.IsGoalAt(1,1));
            
        }
        [Test]
        public void RetornaFalseSiNoHayFinal()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0g0" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);



            // Assert
            ClassicAssert.IsFalse(board.IsGoalAt(1, 0));

        }

        [Test]
        public void RetornaFalseSiFueraDeLosLimite()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "0g0" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);



            // Assert
            ClassicAssert.IsFalse(board.IsGoalAt(-1, 0));

        }

        ///<summary>
        ///Clase GetItem
        /// </summary>

        [Test]
        public void RetornaTrueSiItemObtenidoCorrectamente()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "000" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            board.AddItem(1, 1, 5); 


            // Assert
            Item item = board.GetItem(0); 
            ClassicAssert.AreEqual(1, item.row);
            ClassicAssert.AreEqual(1, item.col);
            ClassicAssert.AreEqual(5, item.value);
        }

        [Test]
        public void RetornaTrueSiUltimoItem()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "000" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);
            board.AddItem(1, 1, 5); 
            board.AddItem(1, 2, 10);


            // Assert
            Item item = board.GetItem(1);
            ClassicAssert.AreEqual(1, item.row);
            ClassicAssert.AreEqual(2, item.col);
            ClassicAssert.AreEqual(10, item.value);
        }

        [Test]
        public void RetornaTrueSiEstaOutRange()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            string textMap = "000" + "000" + "000";
            int maxItems = 5;


            // Act
            Board board = new Board(rows, cols, textMap, maxItems);



            // Assert
            ClassicAssert.Throws<IndexOutOfRangeException>(() => board.GetItem(1)); 

        }
    }
}
