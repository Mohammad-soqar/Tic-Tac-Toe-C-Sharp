using System.Collections;

namespace TicTacToeGame
{
    class Program
    {
        public static ArrayList Ppos1 = new ArrayList();
        public static ArrayList Ppos2 = new ArrayList();
        public static ArrayList Cpos2 = new ArrayList();


        static void Main(string[] args)
        {
            char[][] board =
            {
                new char[] {'1', '|', '2', '|', '3'},
                new char[] { '-', '+', '-', '+', '-' },
                new char[] { '4', '|', '5', '|', '6' },
                new char[] { '-', '+', '-', '+', '-' },
                new char[] { '7', '|', '8', '|', '9' }
            };
            
            Console.WriteLine("if you want to play with cpu press 'C' and if you want 1vs1 press 'P' ");
            char s1 = Convert.ToChar(Console.ReadLine());
            PrintBoard(board);
            while (true)
            {
                

                if (s1 == 'C' || s1 == 'c') // Player vs CPU
                {
                    /*----------------Player turn----------------*/
                    Console.WriteLine("Player 1 enter your position: ");
                    var p1 = Convert.ToInt32(Console.ReadLine());
                    while (Cpos2.Contains(p1) || Ppos1.Contains(p1) || p1 > 9 || p1 < 1) //to check that the position is unique
                    {
                        Console.WriteLine("Wrong input enter another position");
                        p1 = Convert.ToInt32(Console.ReadLine());
                    }
                    placeOnBoard(board, p1, "Player1"); //to place the input
                    Console.WriteLine(CheckWin());

                    /*----------------CPU turn----------------*/

                    Random rand = new Random();
                    int c = rand.Next(1,9);
                    
                    while (Cpos2.Contains(c) || Ppos1.Contains(c) || p1 > 9 || p1 < 1) //to check that the position is unique
                    {
                        c = rand.Next(1, 9);
                    }
                    placeOnBoard(board, c, "Player2"); //to place the input
                    PrintBoard(board);
                    Console.WriteLine(CheckWin());

                }
                else if (s1 == 'P' || s1 == 'p')// Player1 vs Player2
                {
                    while (true)
                    {

                        /*----------------Player 1 turn----------------*/

                        Console.WriteLine("Player 1 enter your position: ");
                        var p1 = Convert.ToInt32(Console.ReadLine());
                        while (Ppos2.Contains(p1) || Ppos1.Contains(p1) || p1 > 9 || p1 < 1) //to check that the position is unique
                        {
                            Console.WriteLine("Wrong input enter another position");
                            p1 = Convert.ToInt32(Console.ReadLine());
                        }


                        placeOnBoard(board, p1, "Player1"); //to place the input
                        PrintBoard(board);
                        Console.WriteLine(); //spaces
                        Console.WriteLine(); //spaces
                        Console.WriteLine(CheckWin());

                        /*----------------Player 2 turn----------------*/

                        Console.WriteLine("Player 2 enter your position: ");
                        p1 = Convert.ToInt32(Console.ReadLine());
                        while (Ppos2.Contains(p1) || Ppos1.Contains(p1) || p1 > 9 || p1 < 1) //to check that the position is unique
                        {
                            Console.WriteLine("Wrong input enter another position");
                            p1 = Convert.ToInt32(Console.ReadLine());
                        }
                        placeOnBoard(board, p1, "Player2"); //to place the input
                        PrintBoard(board);
                        Console.WriteLine(); //spaces
                        Console.WriteLine(); //spaces
                        Console.WriteLine(CheckWin());
                    }
                }
               
            }
        }

        public static string CheckWin()
        {
            if (Ppos1.Contains(1) && Ppos1.Contains(2) && Ppos1.Contains(3) || Ppos1.Contains(4) && Ppos1.Contains(5) && Ppos1.Contains(6) ||
                Ppos1.Contains(7) && Ppos1.Contains(8) && Ppos1.Contains(9) || Ppos1.Contains(1) && Ppos1.Contains(5) && Ppos1.Contains(9) ||
                Ppos1.Contains(3) && Ppos1.Contains(5) && Ppos1.Contains(7))
            {
                return "Player 1 wins";
            }
            else if (Ppos2.Contains(1) && Ppos2.Contains(2) && Ppos2.Contains(3) || Ppos2.Contains(4) && Ppos2.Contains(5) && Ppos2.Contains(6) ||
                Ppos2.Contains(7) && Ppos2.Contains(8) && Ppos2.Contains(9) || Ppos2.Contains(1) && Ppos2.Contains(5) && Ppos2.Contains(9) ||
                Ppos2.Contains(3) && Ppos2.Contains(5) && Ppos2.Contains(7))
            {
                return "Player 2 wins";
            }
            else if (Cpos2.Contains(1) && Cpos2.Contains(2) && Cpos2.Contains(3) || Cpos2.Contains(4) && Cpos2.Contains(5) && Cpos2.Contains(6) ||
               Cpos2.Contains(7) && Cpos2.Contains(8) && Cpos2.Contains(9) || Cpos2.Contains(1) && Cpos2.Contains(5) && Cpos2.Contains(9) ||
               Cpos2.Contains(3) && Cpos2.Contains(5) && Cpos2.Contains(7))
            {
                return "CPU wins";
            }
            else if (Ppos1.Count + Ppos2.Count == 9)
            {
                return "tie );";
            }
            return "";

              
        }
        public static void placeOnBoard(char[][] gameBoard, int pos, String user)
        {
            char sympol = 'x';
            if (user == ("Player1"))
            {
                sympol = 'x';
                Ppos1.Add(pos);
            }
            else if (user == ("Player2"))
            {
                sympol = 'o';
                Ppos2.Add(pos);
            }

            switch (pos)
            {
                case 1: gameBoard[0][0] = sympol; break;
                case 2: gameBoard[0][2] = sympol; break;
                case 3: gameBoard[0][4] = sympol; break;
                case 4: gameBoard[2][0] = sympol; break;
                case 5: gameBoard[2][2] = sympol; break;
                case 6: gameBoard[2][4] = sympol; break;
                case 7: gameBoard[4][0] = sympol; break;
                case 8: gameBoard[4][2] = sympol; break;
                case 9: gameBoard[4][4] = sympol; break;
                    default: break;
           

            }
        }

            public static char[][] PrintBoard(char [][] board)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    Console.Write(board[row][col]);
                }
                Console.WriteLine();
            }

            return board;
        }
    }
}

