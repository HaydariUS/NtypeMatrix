using System;
using System.Collections.Generic;

public class NegativeSizeException : Exception { }
public class DifferentSizeException : Exception { }
public class ReferenceToNullPartException : Exception { }

namespace NtypeMatrix
{
    public class Ntype
    {
        private readonly int size;
        private readonly List<double> fColumn;
        private readonly List<double> lColumn;
        private readonly List<double> diag;

        public Ntype(int size)
        {
            if (size <= 0) throw new NegativeSizeException();

            this.size = size;
            fColumn = new List<double>(new double[size]);
            lColumn = new List<double>(new double[size]);
            diag = new List<double>(new double[size]);
        }

        public int Size => size;

        public double this[int i, int j]
        {
            get => GetValue(i, j);
            set => SetValue(i, j, value);
        }

        private double GetValue(int i, int j)
        {
            if (i < 0 || j < 0 || i >= size || j >= size)
                throw new IndexOutOfRangeException();

            if (i == j) return diag[i];
            if (j == 0) return fColumn[i];
            if (j == size - 1) return lColumn[i];
            return 0;
        }

        private void SetValue(int i, int j, double value)
        {
            if (i < 0 || j < 0 || i >= size || j >= size)
                throw new IndexOutOfRangeException();

            if (i == j)
            {
                diag[i] = value;
            }
            else if (j == 0)
            {
                fColumn[i] = value;
            }
            else if (j == size - 1)
            {
                lColumn[i] = value;
            }
            else
            {
                throw new ReferenceToNullPartException();
            }
        }


        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += $"{this[i, j]}\t";
                }
                result += "\n";
            }
            return result;
        }

        public void Set(List<double> values)
        {
            if (values.Count != size * size)
            {
                throw new DifferentSizeException();
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this[i, j] = values[i * size + j];
                }
            }
        }


        public static Ntype operator +(Ntype a, Ntype b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();

            Ntype result = new Ntype(a.Size);

            for (int i = 0; i < a.Size; i++)
            {
                result.diag[i] = a.diag[i] + b.diag[i];
                result.fColumn[i] = a.fColumn[i] + b.fColumn[i];
                result.lColumn[i] = a.lColumn[i] + b.lColumn[i];
            }
            return result;
        }

        public static Ntype operator *(Ntype a, Ntype b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();

            Ntype result = new Ntype(a.Size);

            for (int i = 0; i < a.Size; i++)
            {
                result.diag[i] = a.diag[i] * b.diag[i];
                result.fColumn[i] = a.fColumn[i] * b.diag[i];
                result.lColumn[i] = a.lColumn[i] * b.diag[i];
            }
            return result;
        }
    }
}
