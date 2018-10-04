using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Enter the Matrix size:");
            int mat_size = int.Parse(Console.ReadLine());
            Matrix m = new Matrix(mat_size, mat_size);
            m.Size = mat_size;
            SetMatrix(m);
            m.Decomposition();
            Console.WriteLine("Your Matrix:");
            Console.WriteLine(m);
            Console.WriteLine("L:");
            Console.WriteLine(m.lower);
            Console.WriteLine("U:");
            Console.WriteLine(m.upper);
            Console.ReadLine();
            void SetMatrix(Matrix matrix)
            {
                for (int i = 0; i < matrix.Size; i++)
                {
                    for (int j = 0; j < matrix.Size; j++)
                    {
                        Console.WriteLine("Set [" + i.ToString() + ',' + j.ToString() + ']');
                        matrix.SetMatVal(i, j, float.Parse(Console.ReadLine()));
                    }
                }
                Console.Clear();
            }
        }
    }
}
