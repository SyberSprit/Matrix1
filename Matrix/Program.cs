using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of Matrixes (1 or 2)");
            int num = int.Parse(Console.ReadLine());
            int mat1_size , mat2_size;
            char oprtr;
            if (num == 1)
            {
                Console.WriteLine("Enter the Matrix size:");
                mat1_size = int.Parse(Console.ReadLine());
                Matrix m = new Matrix(mat1_size, mat1_size);
                m.Size = mat1_size;
                if (m.Size > 0)
                {
                    m.SetMatrix(m);
                    Console.WriteLine("Your Matrix is:\n" + m);
                    Console.WriteLine("The value of determinant is: " + m.Determinant(m.Elemnts));
                }
            }
            else
            {
                Console.WriteLine("Enter the Matrix1 size:");
                mat1_size = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Matrix2 size:");
                mat2_size = int.Parse(Console.ReadLine());
                Matrix m1 = new Matrix(mat1_size, mat1_size);
                Matrix m2 = new Matrix(mat2_size, mat2_size);
                m1.Size = mat1_size;
                m2.Size = mat2_size;
                Console.WriteLine("Enter the Matrix1 elements:");
                m1.SetMatrix(m1);
                Console.WriteLine("Enter the Matrix2 elements:");
                m2.SetMatrix(m2);
                Console.Clear();
                Console.WriteLine("Matrix1 is:\n" + m1);
                Console.WriteLine("Matrix2 is:\n" + m2);
                Console.WriteLine("Choose your Operator (+ , -)");
                
                oprtr = char.Parse(Console.ReadLine());
                Matrix res = new Matrix(mat1_size, mat1_size);
                if (oprtr =='+')
                {
                    Console.WriteLine(res.Sum(m1, m2));
                }
                if (oprtr == '-')
                {
                    Console.WriteLine(res.Min(m1, m2));
                }
                


            }
            Console.ReadLine();
        }

    }
}