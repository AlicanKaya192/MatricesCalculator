using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MatricesCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
        BackToTop:

            Console.Write("1. Number of rows in the matrice: ");
            int row1 = GetValidIntegerInput();

            Console.Write("1. Number of columns in the matrice: ");
            int column1 = GetValidIntegerInput();

            Console.Write("2. Number of rows in the matrice: ");
            int row2 = GetValidIntegerInput();

            Console.Write("2. Number of columns in the matrice: ");
            int column2 = GetValidIntegerInput();

            int[,] matrice1 = new int[row1, column1]; // 1.Matrice

            int[,] matrice2 = new int[row2, column2]; // 2.Matrice

            //1.Importing Matrice Elementss
            for (int i = 0; i < matrice1.GetLength(0); i++)
            {
                for (int j = 0; j < matrice1.GetLength(1); j++)
                {
                    Console.Write($"1.Matrice {i + 1}. row {j + 1}. enter column element: ");
                    matrice1[i, j] = GetValidIntegerInput();
                }
            }

            //2.Importing Matrice Elements
            for (int i = 0; i < matrice2.GetLength(0); i++)
            {
                for (int j = 0; j < matrice2.GetLength(1); j++)
                {
                    Console.Write($"2.Matrice {i + 1}. row {j + 1}. enter column element: ");
                    matrice2[i, j] = GetValidIntegerInput();
                }
            }

            string matrice1t = GetTransposeInput(); // Matrice 1 TRANPOSE APPROVAL

            string matrice2t = GetTransposeInput(); // Matrice 2 TRANPOSE APPROVAL

            if (matrice1t.ToUpper() == "Y") // If the user accepts transpose, the 1st matrice is ​​transposed
            {
                int[,] transposeMatrice1 = new int[matrice1.GetLength(1), matrice1.GetLength(0)];
                for (int i = 0; i < matrice1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice1.GetLength(1); j++)
                    {
                        transposeMatrice1[j, i] = matrice1[i, j];
                    }
                }
                matrice1 = transposeMatrice1;
            }

            if(matrice2t.ToUpper() == "Y") // //If the user accepts transpose, the 2st matrice is ​​transposed
            {
                int[,] transposeMatrix2 = new int[matrice2.GetLength(1), matrice2.GetLength(0)];
                for (int i = 0; i < matrice2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice2.GetLength(1); j++)
                    {
                        transposeMatrix2[j, i] = matrice2[i, j];
                    }
                }
                matrice2 = transposeMatrix2;
            }

            // Printing the Matrice 1
            Console.WriteLine("\nMatrice 1:");
            for (int i = 0; i < matrice1.GetLength(0); i++)
            {
                for (int j = 0; j < matrice1.GetLength(1); j++)
                {
                    Console.Write($"{matrice1[i, j],4} ");
                }
                Console.WriteLine();
            }

            // Printing the Matrice 2
            Console.WriteLine("\nMatrice 2:");
            for (int i = 0; i < matrice2.GetLength(0); i++)
            {
                for (int j = 0; j < matrice2.GetLength(1); j++)
                {
                    Console.Write($"{matrice2[i, j],4} ");
                }
                Console.WriteLine();
            }

            string requestedAction = null; // Selection parameter

            do
            {
                SelectionScreen();

                switch (requestedAction) // Transactions to be Performed According to the Selected Section
                {
                    case "1": // SUM

                        if (matrice1.GetLength(0) != matrice2.GetLength(0)) // 2 Measures the Equality of Matrice Rows According to the Rule
                        {
                            Console.WriteLine("Number of Rows of 2 Matrice is ​​Not Equal. Transaction Cannot Be Done");
                        }
                        else if (matrice1.GetLength(1) != matrice2.GetLength(1)) // 2 Measures the Equality of Matrice Columns According to the Rule
                        {
                            Console.WriteLine("The Number of Columns of 2 Matrice is ​​Not Equal. Transaction Cannot Be Done");
                        }
                        else
                        {
                            int[,] matriceSum = new int[matrice1.GetLength(0), matrice2.GetLength(1)];

                            for (int m = 0; m < matrice1.GetLength(0); m++)
                            {
                                for (int n = 0; n < matrice2.GetLength(0); n++)
                                {
                                    matriceSum[m, n] = matrice1[m, n] + matrice2[m, n];
                                }
                            }

                            Console.WriteLine("\nMatrice Sum :");
                            for (int i = 0; i < matriceSum.GetLength(0); i++)
                            {
                                for (int j = 0; j < matriceSum.GetLength(1); j++)
                                {
                                    Console.Write(matriceSum[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "2": // Subtraction

                        if (matrice1.GetLength(0) != matrice2.GetLength(0)) // 2 Measures the Equality of Matrice Rows According to the Rule
                        {
                            Console.WriteLine("Number of Rows of 2 Matrice is ​​Not Equal. Transaction Cannot Be Done");
                        }
                        else if (matrice1.GetLength(1) != matrice2.GetLength(1)) // 2 Measures the Equality of Matrice Columns According to the Rule
                        {
                            Console.WriteLine("The Number of Columns of 2 Matrice is ​​Not Equal. Transaction Cannot Be Done");
                        }
                        else
                        {
                            int[,] matrixSub = new int[matrice1.GetLength(0), matrice2.GetLength(1)];

                            for (int m = 0; m < matrice1.GetLength(0); m++)
                            {
                                for (int n = 0; n < matrice2.GetLength(0); n++)
                                {
                                    matrixSub[m, n] = matrice1[m, n] - matrice2[m, n];
                                }
                            }

                            Console.WriteLine("\nMtrice Subtraction :");
                            for (int i = 0; i < matrixSub.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrixSub.GetLength(1); j++)
                                {
                                    Console.Write(matrixSub[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "3": // Multiplication 

                        if (matrice1.GetLength(1) != matrice2.GetLength(0))   // 1. Reviews the columns of the Matrice and the rows of the 2nd matrice according to the Matrice Multiplication Rule.
                        {
                            Console.WriteLine("Matrices Are Not Suitable For Multiplication Operations");
                        }
                        else
                        {
                            int[,] matriceMult = new int[matrice1.GetLength(0), matrice2.GetLength(1)];

                            // Multiplication
                            for (int i = 0; i < matrice1.GetLength(0); i++) // rows of matrice1
                            {
                                for (int j = 0; j < matrice2.GetLength(1); j++) // columns of matrice2
                                {
                                    int sum = 0;
                                    for (int k = 0; k < matrice1.GetLength(1); k++) // columns of matrice1 and rows of matrice2
                                    {
                                        sum += matrice1[i, k] * matrice2[k, j];
                                    }
                                    matriceMult[i, j] = sum;
                                }
                            }

                            Console.WriteLine("\nMatrice Multiplication :");
                            for (int i = 0; i < matriceMult.GetLength(0); i++)
                            {
                                for (int j = 0; j < matriceMult.GetLength(1); j++)
                                {
                                    Console.Write(matriceMult[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }

                        break;
                    case "4":
                        Console.Clear();
                        goto BackToTop; // Returns to the beginning of the code for new matrices
                    case "5": // Finishes the program
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid selection!");  // Wrong Selection Warning
                        break;
                }
            } while (requestedAction != "5");

            // Checking the Value Entered for Matrices
            int GetValidIntegerInput()
            {
                while (true) // Infinite loop continues until a valid input is received
                {
                    try
                    {
                        string input = Console.ReadLine();
                        int number = Convert.ToInt32(input); // Attempts to convert string to integer

                        if (number == 0) // VALIDATES THE NUMBERS OF ROWS AND COLUMNS OF THE MATRICE
                        {
                            Console.Write("The value you enter cannot be zero. Please enter a valid number. : ");
                            continue;
                        }

                        return number; // Returns if there is no error
                    }
                    catch (FormatException)
                    {
                        Console.Write("Incorrect login! Please enter an integer. : ");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Mistake! The number you entered is too large or too small.");
                    }
                }
            }

            string GetTransposeInput()
            {
                while (true)
                {
                    Console.Write("Would you like to transpose? (Y/N): ");
                    string input = Console.ReadLine()?.Trim().ToUpper();  // Delete spaces and convert to uppercase

                    if (input == "Y" || input == "N")
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect login! Please enter 'Y' or 'N' only.");
                    }
                }
            }


            void SelectionScreen()
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Sum");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Enter New Matrices");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("-------------------------------");
                Console.Write("What is the transaction you want to do? : ");
                requestedAction = Console.ReadLine();
            }
        }
    }
}