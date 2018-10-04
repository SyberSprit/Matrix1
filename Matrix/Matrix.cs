using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        int row, column;
        int size;
        float[,] elemnts;
        public Matrix lower;
        public Matrix upper;
        public int Row
        {
            get => row;
            private set => row = value;
        }
        public int Column
        {
            get => column;
            private set => column = value;
        }
        public int Size
        {
            get => size;
            set => size = value;
        }
        public float[,] Elemnts
        {
            get => elemnts;
            set => elemnts = value;
        }
        public Matrix(int r, int c)
        {
            Row = r;
            Column = c;
            Elemnts = new float[Row, Column];
            // Decomposition();
        }
        public Matrix(Matrix m)
        {
            Row = m.Row;
            Column = m.Column;
            Elemnts = new float[Row, Column];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Elemnts[i, j] = m.Elemnts[i, j];

                }
            }
            //Decomposition();
        }
        public void SetMatVal(int i, int j, float val)
        {
            Elemnts[i, j] = val;
        }
        public Matrix(float[,] e)
        {
            Row = e.GetLength(0);
            Column = e.GetLength(1);
            Elemnts = new float[Row, Column];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Elemnts[i, j] = e[i, j];
                }
            }
            //Decomposition();
        }
        public float[] GetRow(int i)
        {
            float[] ar = new float[row];
            for (int k = 0; k < row; k++)
            {

                ar[k] = Elemnts[k, i];

            }
            return ar;
        }
        public float[] Getcolumn(int i)
        {
            float[] ar = new float[column];
            for (int k = 0; k < column; k++)
            {

                ar[k] = Elemnts[i, k];

            }
            return ar;
        }
        public Matrix GetRowMatrix(int i)
        {
            float[] res = GetRow(i);
            float[,] e = new float[1, res.Length];
            for (int j = 0; j < res.Length; j++)
            {
                e[0, j] = res[j];
            }
            return new Matrix(e);
        }
        public Matrix GetColumnMatrix(int i)
        {
            float[] res = Getcolumn(i);
            float[,] e = new float[res.Length, 1];
            for (int j = 0; j < res.Length; j++)
            {
                e[j, 0] = res[j];
            }
            return new Matrix(e);
        }
        static int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        static float[,] CreateSmallerMatrix(float[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            float[,] output = new float[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
        public float Determinant(float[,] input)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            if (order > 2)
            {
                float value = 0;
                for (int j = 0; j < order; j++)
                {
                    float[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * Determinant(Temp));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }

        }
        public void Decomposition()
        {
            lower = new Matrix(Row, Column);
            upper = new Matrix(Row, Column);

            for (int i = 0; i < Row; i++)
            {
                for (int k = i; k < Row; k++)
                {
                    float sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += (float)(lower.Elemnts[i, j] * upper.Elemnts[j, k]);
                    upper.Elemnts[i, k] = Elemnts[i, k] - sum;
                }
                for (int k = i; k < Row; k++)
                {
                    if (i == k)
                        lower.Elemnts[i, i] = 1;
                    else
                    {
                        float sum = 0;
                        for (int j = 0; j < i; j++)
                            sum += (float)(lower.Elemnts[k, j] * upper.Elemnts[j, i]);
                        lower.Elemnts[k, i] = (Elemnts[k, i] - sum) / upper.Elemnts[i, i];
                    }
                }
            }
        }
        public Matrix L_Decomposition()
        {
            Matrix lower = new Matrix(Row, Column);
            Matrix upper = new Matrix(Row, Column);
            for (int i = 0; i < Row; i++)
            {
                for (int k = i; k < Row; k++)
                {
                    float sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += (float)(lower.Elemnts[i, j] * upper.Elemnts[j, k]);
                    upper.Elemnts[i, k] = Elemnts[i, k] - sum;
                }
                for (int k = i; k < Row; k++)
                {
                    if (i == k)
                        lower.Elemnts[i, i] = 1;
                    else
                    {
                        float sum = 0;
                        for (int j = 0; j < i; j++)
                            sum += (float)(lower.Elemnts[k, j] * upper.Elemnts[j, i]);
                        lower.Elemnts[k, i] = (Elemnts[k, i] - sum) / upper.Elemnts[i, i];
                    }
                }
            }
            return lower;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    s += Elemnts[i, j] + "\t";
                }
                s += "\n";
            }
            return s;
        }
    }
}