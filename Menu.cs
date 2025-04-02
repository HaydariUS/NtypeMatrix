using System;
using System.Collections.Generic;

namespace NtypeMatrix
{
    public class Menu
    {
        private List<Ntype> vec = new List<Ntype>();

        public Menu() { }

        public void Run()
        {
            int m;
            do
            {
                PrintMenu();
                m = int.TryParse(Console.ReadLine(), out int n) ? n : -1;
                switch (m)
                {
                    case 1:
                        GetElement();
                        break;
                    case 2:
                        OverrideElement();
                        break;
                    case 3:
                        PrintMatrix();
                        break;
                    case 4:
                        AddMatrix();
                        break;
                    case 5:
                        Sum();
                        break;
                    case 6:
                        Multiply();
                        break;
                }

            } while (m != 0);
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n0. - Quit");
            Console.WriteLine("1. - Get an element");
            Console.WriteLine("2. - Override an element");
            Console.WriteLine("3. - Print a matrix");
            Console.WriteLine("4. - Set a matrix");
            Console.WriteLine("5. - Add matrices");
            Console.WriteLine("6. - Multiply matrices");
            Console.Write("Choose: ");
        }

        private int GetMatrixIndex()
        {
            if (vec.Count == 0)
            {
                Console.WriteLine("No matrix available");
                return -1;
            }

            Console.Write("Enter matrix index: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > vec.Count)
            {
                Console.WriteLine("Invalid index");
                return -1;
            }
            return index - 1;
        }

        private void GetElement()
        {
            int index = GetMatrixIndex();
            if (index == -1) return;

            Console.Write("Enter row index: ");
            if (!int.TryParse(Console.ReadLine(), out int row) || row < 0 || row >= vec[index].Size)
            {
                Console.WriteLine("Invalid row index");
                return;
            }

            Console.Write("Enter column index: ");
            if (!int.TryParse(Console.ReadLine(), out int col) || col < 0 || col >= vec[index].Size)
            {
                Console.WriteLine("Invalid column index");
                return;
            }

            try
            {
                Console.WriteLine($"Element at [{row},{col}]: {vec[index][row, col]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range");
            }
        }

        private void OverrideElement()
        {
            int index = GetMatrixIndex();
            if (index == -1) return;

            Console.Write("Enter row index: ");
            if (!int.TryParse(Console.ReadLine(), out int row) || row < 0 || row >= vec[index].Size)
            {
                Console.WriteLine("Invalid row index");
                return;
            }

            Console.Write("Enter column index: ");
            if (!int.TryParse(Console.ReadLine(), out int col) || col < 0 || col >= vec[index].Size)
            {
                Console.WriteLine("Invalid column index");
                return;
            }

            Console.Write("Enter new value: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Invalid value");
                return;
            }

            try
            {
                vec[index][row, col] = value;
                Console.WriteLine("Element overridden successfully");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ReferenceToNullPartException)
            {
                Console.WriteLine("Only the elements in the diagonal, first column, and last column may be rewritten");
            }

        }

        private void PrintMatrix()
        {
            int index = GetMatrixIndex();
            if (index == -1) return;

            Console.WriteLine(vec[index]);
        }

        private void AddMatrix()
        {
            Console.Write("Enter matrix size: ");
            if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
            {
                Console.WriteLine("Invalid size");
                return;
            }

            Ntype matrix;
            try
            {
                matrix = new Ntype(size);
            }
            catch (NegativeSizeException)
            {
                Console.WriteLine("Matrix size must be positive");
                return;
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter value for first column element [{i},0]: ");
                if (!double.TryParse(Console.ReadLine(), out double val))
                {
                    Console.WriteLine("Invalid input. Please enter a number");
                    return;
                }
                matrix[i, 0] = val;
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter value for last column element [{i},{size - 1}]: ");
                if (!double.TryParse(Console.ReadLine(), out double val))
                {
                    Console.WriteLine("Invalid input. Please enter a number");
                    return;
                }
                matrix[i, size - 1] = val;
            }

            for (int i = 1; i < size - 1; i++)
            {
                Console.Write($"Enter value for diagonal element [{i},{i}]: ");
                if (!double.TryParse(Console.ReadLine(), out double val))
                {
                    Console.WriteLine("Invalid input. Please enter a number");
                    return;
                }
                matrix[i, i] = val;
            }

            vec.Add(matrix);
            Console.WriteLine("Matrix set successfully");
        }

        private void Sum()
        {
            if (vec.Count < 2)
            {
                Console.WriteLine("At least two matrices are required for addition");
                return;
            }

            int index1 = GetMatrixIndex();
            if (index1 == -1) return;

            int index2 = GetMatrixIndex();
            if (index2 == -1) return;

            try
            {
                Ntype result = vec[index1] + vec[index2];
                Console.WriteLine("Sum of matrices:");
                Console.WriteLine(result);
            }
            catch (DifferentSizeException)
            {
                Console.WriteLine("Matrices must be the same size to add");
            }
        }

        private void Multiply()
        {
            if (vec.Count < 2)
            {
                Console.WriteLine("At least two matrices are required for multiplication");
                return;
            }

            int index1 = GetMatrixIndex();
            if (index1 == -1) return;

            int index2 = GetMatrixIndex();
            if (index2 == -1) return;

            try
            {
                Ntype result = vec[index1] * vec[index2];
                Console.WriteLine("Product of matrices:");
                Console.WriteLine(result);
            }
            catch (DifferentSizeException)
            {
                Console.WriteLine("Matrices must be the same size to multiply");
            }
        }
    }
}
