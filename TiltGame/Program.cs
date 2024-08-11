using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        //public static string path = "L:\\College\\Algorithm\\TiltGame\\[4] Tilt Game\\Project\\TiltGame\\Sample_Tests\\Case6.txt";
        public static string path = "L:\\College\\Algorithm\\TiltGame\\[4] Tilt Game\\Project\\TiltGame\\Complete Tests\\3 large\\Case 3\\Case6.txt";
        public static List<char[][]> BoardStates = new List<char[][]>();
        public static Stopwatch stopwatchClone = new Stopwatch();
        static void Main(string[] args)
        {
            int n; // Variable to store the size of the board
            char[][] board; // 2D array to represent the board
            string[] lines = File.ReadAllLines(path);
            //string[] lines = ReadFromFile(path, out n, out board); // Read input from file

            // Print the content read from the file
            //Console.WriteLine("Content read from input.txt:");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}
            //Console.WriteLine();

            // Display the board configuration

            Console.WriteLine();
            // Parse input
            n = int.Parse(lines[0]); // Parse the size of the board
            board = new char[n][]; // Initialize the board array
            for (int i = 0; i < n; i++)
            {
                string[] row = lines[i + 1].Split(','); // Split each row by comma
                board[i] = new char[n]; // Initialize each row in the board
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = row[j].Trim()[0]; // Trim excess whitespace and assign values to the board
                }
            }


            string[] targetCoords = lines[n + 1].Split(','); // Split target coordinates
            Tuple<int, int> target = Tuple.Create(int.Parse(targetCoords[0]), int.Parse(targetCoords[1])); // Create a tuple for target position

            // Solve the game
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            List<string> solution = SolveGame(board, target); // Find solution using BFS
            stopwatch.Stop();



            // Output the result
            using (StreamWriter outputFile = new StreamWriter("output.txt")) // Write output to file
            {
                if (solution != null)
                {
                    outputFile.WriteLine("Solvable");
                    outputFile.WriteLine("Min number of moves: " + solution.Count);
                    outputFile.WriteLine("Sequence of moves: " + string.Join(", ", solution));

                    if (path.Contains("Sample_Tests"))
                    {
                        outputFile.WriteLine();
                        Console.WriteLine("Sample Test Case");
                        outputFile.WriteLine("Sample Test Case");
                        Console.WriteLine();
                        outputFile.WriteLine();
                        Console.WriteLine();
                        outputFile.WriteLine();
                        Console.WriteLine("Initial");
                        outputFile.WriteLine("Initial");
                        Console.WriteLine();
                        outputFile.WriteLine();
                        for (int i = 0; i < n; i++)
                        {

                            for (int j = 0; j < n; j++)
                            {
                                if (j == n - 1)
                                {
                                    Console.Write(board[i][j]);
                                    outputFile.Write(board[i][j]);
                                }
                                else
                                {
                                    Console.Write(board[i][j] + " ,");
                                    outputFile.Write(board[i][j] + " ,");
                                }

                            }
                            Console.WriteLine();
                            outputFile.WriteLine();
                        }
                        BoardStates.Add(board);

                        int direction = 0;
                        switch (solution[0])
                        {
                            case "up":
                                direction = 0; break;
                            case "down":
                                direction = 1; break;
                            case "left":
                                direction = 2; break;
                            case "right":
                                direction = 3; break;

                        }
                        char[][] newBoard = Move(board, direction);
                        Console.WriteLine();
                        outputFile.WriteLine();
                        Console.WriteLine();
                        outputFile.WriteLine();
                        Console.WriteLine(solution[0].ToString());
                        outputFile.WriteLine(solution[0].ToString());
                        Console.WriteLine();
                        outputFile.WriteLine();
                        BoardStates.Add(newBoard);
                        for (int x = 1; x <= solution.Count; x++)
                        {
                            for (int i = 0; i < n; i++)
                            {

                                for (int j = 0; j < n; j++)
                                {
                                    if (j == n - 1)
                                    {
                                        Console.Write(newBoard[i][j]);
                                        outputFile.Write(newBoard[i][j]);
                                    }
                                    else
                                    {
                                        Console.Write(newBoard[i][j] + " ,");
                                        outputFile.Write(newBoard[i][j] + " ,");
                                    }

                                }
                                Console.WriteLine();
                                outputFile.WriteLine();
                            }

                            if (x == solution.Count)
                            {
                                break;
                            }
                            Console.WriteLine();
                            outputFile.WriteLine();
                            Console.WriteLine();
                            outputFile.WriteLine();
                            Console.WriteLine(solution[x].ToString());
                            outputFile.WriteLine(solution[x].ToString());
                            Console.WriteLine();
                            outputFile.WriteLine();

                            switch (solution[x])
                            {
                                case "up":
                                    direction = 0; break;
                                case "down":
                                    direction = 1; break;
                                case "left":
                                    direction = 2; break;
                                case "right":
                                    direction = 3; break;

                            }

                            newBoard = Move(newBoard, direction);
                            BoardStates.Add(newBoard);

                            //foreach (var item in newBoard)
                            //{
                            //    outputFile.WriteLine(item + string.Join(", ", solution));
                            //    Console.WriteLine(item + string.Join(", ", solution));
                            //}



                        }
                        Console.WriteLine();
                        outputFile.WriteLine();
                        Console.WriteLine();
                        outputFile.WriteLine();
                        //Console.WriteLine(BoardStates.Count);
                        //foreach (var bord in BoardStates)
                        //{
                        //    Console.WriteLine("Board List");
                        //    Console.WriteLine(bord.ToString());
                        //}

                    }

                }
                else
                {
                    Console.WriteLine("Not solvable");
                    outputFile.WriteLine("Not solvable");
                }

            }


            // Print the running time
            Console.WriteLine("Running time: " + FormatRunningTime(stopwatch.Elapsed));
            Console.WriteLine("Clone time: " + FormatRunningTime(stopwatchClone.Elapsed));
        }

        static string[] ReadFromFile(string fileName, out int n, out char[][] board)
        {
            string[] lines = File.ReadAllLines(fileName); // Read all lines from file

            // Parse input
            n = int.Parse(lines[0]); // Parse the size of the board
            board = new char[n][]; // Initialize the board array
            for (int i = 0; i < n; i++)
            {
                string[] row = lines[i + 1].Split(','); // Split each row by comma
                board[i] = new char[n]; // Initialize each row in the board
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = row[j].Trim()[0]; // Trim excess whitespace and assign values to the board
                }
            }

            return lines; // Return array of lines read from file
        }

        // Function to format the running time
        static string FormatRunningTime(TimeSpan timeSpan)
        {
            return $"{timeSpan.TotalSeconds} sec"; // Format the running time
        }



        // Function to solve the game using BFS
        static List<string> SolveGame(char[][] board, Tuple<int, int> target)
        {
            Queue<Tuple<char[][], List<string>>> queue = new Queue<Tuple<char[][], List<string>>>(); // Initialize queue for BFS
            HashSet<string> visited = new HashSet<string>(); // Initialize set to track visited states
            queue.Enqueue(Tuple.Create(board, new List<string>())); // Enqueue initial state of the game
            while (queue.Count > 0) // While there are states in the queue
            {
                //Console.WriteLine(queue.Count);
                var tuple = queue.Dequeue(); // Dequeue a state
                char[][] currentBoard = tuple.Item1; // Get the board configuration
                List<string> moves = tuple.Item2; // Get the moves made so far

                if (IsTargetReached(currentBoard, target)) // Check if target configuration is reached
                {
                    return moves; // Return the sequence of moves
                }
                string currstr = BoardToString(currentBoard);
                if (visited.Contains(currstr)) // Skip visited configurations
                {
                    continue;
                }
                visited.Add(currstr); // Mark current configuration as visited

                for (int direction = 0; direction < 4; direction++) // Iterate through all possible moves
                {
                    char[][] newBoard = null;
                    bool moved = false;
                    if (moves.Count == 0)
                    {
                        newBoard = Move(currentBoard, direction);
                        moved = true;
                    }
                    else if (direction == 2 || direction == 3)
                    {
                        if (moves[moves.Count - 1] == "up" || moves[moves.Count - 1] == "down")
                        {
                            newBoard = Move(currentBoard, direction);
                            moved = true;
                        }
                    }

                    else if (direction == 0 || direction == 1)
                    {
                        if (moves[moves.Count - 1] == "left" || moves[moves.Count - 1] == "right")
                        {
                            newBoard = Move(currentBoard, direction);
                            moved = true;
                        }
                    }

                    //char[][] newBoard = Move(currentBoard, direction); // Generate new board state
                    if (moved == true && !visited.Contains(BoardToString(newBoard))) // Check if new state is not visited
                    {
                        List<string> newMoves = new List<string>(moves); // Create new list for moves
                        newMoves.Add(new string[] { "up", "down", "left", "right" }[direction]); // Add move to the list
                        queue.Enqueue(Tuple.Create(newBoard, newMoves)); // Enqueue new state
                    }
                }


                //-----------------------------------------------------------------------------------------








            }
            return null; // Not solvable
        }

        // Function to generate the next board state after tilting in a given direction
        static char[][] Move(char[][] B, int direction)
        {
            //Console.WriteLine("aaaaaaaaaaaaaaaaaaaa");
            int n = B.Length;
            char[][] B_ = new char[n][];
            
            stopwatchClone.Start();
            for (int i = 0; i < n; i++)
            {
                B_[i] = (char[])B[i].Clone();
            }
            stopwatchClone.Stop();

            if (direction == 0)
            {
                for (int x = 0; x < n; x++)
                {
                    int y_ = 0;
                    for (int y = 0; y < n; y++)
                    {
                        if (B_[y][x] == 'o' && B_[y_][x] == '.')
                        {
                            Swap(ref B_[y][x], ref B_[y_][x]);
                            y_++;
                        }
                        if (B_[y][x] != '.' || B_[y_][x] != '.')
                        {
                            y_ = y;
                        }
                    }
                }
            }
            else if (direction == 1)
            {
                for (int x = 0; x < n; x++)
                {
                    int y_ = n - 1;
                    for (int y = n - 1; y >= 0; y--)
                    {
                        if (B_[y][x] == 'o' && B_[y_][x] == '.')
                        {
                            Swap(ref B_[y][x], ref B_[y_][x]);
                            y_--;
                        }
                        if (B_[y][x] != '.' || B_[y_][x] != '.')
                        {
                            y_ = y;
                        }
                    }
                }
            }
            else if (direction == 2)
            {
                for (int y = 0; y < n; y++)
                {
                    int x_ = 0;
                    for (int x = 0; x < n; x++)
                    {
                        if (B_[y][x] == 'o' && B_[y][x_] == '.')
                        {
                            Swap(ref B_[y][x], ref B_[y][x_]);
                            x_++;
                        }
                        if (B_[y][x] != '.' || B_[y][x_] != '.')
                        {
                            x_ = x;
                        }
                    }
                }
            }
            else if (direction == 3)
            {
                for (int y = 0; y < n; y++)
                {
                    int x_ = n - 1;
                    for (int x = n - 1; x >= 0; x--)
                    {
                        if (B_[y][x] == 'o' && B_[y][x_] == '.')
                        {
                            Swap(ref B_[y][x], ref B_[y][x_]);
                            x_--;
                        }
                        if (B_[y][x] != '.' || B_[y][x_] != '.')
                        {
                            x_ = x;
                        }
                    }
                }
            }



            //--------------------------------------------------------








            //Console.WriteLine("bbbbbbbbbbbbbbbbbbbbbb");
            return B_;
        }

        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        // Function to check if a position is valid on the board
        static bool IsValidPosition(char[][] board, int x, int y)
        {
            return 0 <= x && x < board[0].Length && 0 <= y && y < board.Length; // Check if position is within board boundaries
        }

        // Function to check if the target configuration is reached
        static bool IsTargetReached(char[][] board, Tuple<int, int> target)
        {
            return board[target.Item2][target.Item1] == 'o'; // Check if target position contains a slider
        }

        // Function to convert a board to a string
        static string BoardToString(char[][] board)
        {

            StringBuilder result = new StringBuilder();
            foreach (var row in board)
            {
                result.Append(new string(row));
                //result.Append(',');  // Directly append the comma here
            }
            // Remove the last comma to clean up the output, if board is not empty
            if (result.Length > 0)
            {
                //result.Remove(result.Length - 1, 1);
            }
            return result.ToString();


            //string result = "";
            //List<string> res= new List<string> ();
            //foreach (var row in board) // Iterate through rows
            //{
            //    //result += new string(row) + ","; // Concatenate row to the result string
            //    res.Add(new string(row) + ",");
            //}
            //result = String.Join("", res);
            //result = result.Substring(0, result.Length - 1);
            //return result; // Return string representation of the board
        }
    }
}
