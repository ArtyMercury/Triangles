using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace Max_sum_triangle
{

    class Program
    {
        static void Main(string[] args)
        {

            new Program().MaxSum();
        }
        public void MaxSum()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\triangles\simple_triangle.txt";
            int[][] dataTriangle = Triangle(path);
            int rows = dataTriangle.GetLength(0);
            int[] maxValue = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                maxValue[i] = dataTriangle[rows - 1][i];
            }

            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    maxValue[j] = dataTriangle[i][j] + Math.Max(maxValue[j], maxValue[j + 1]);
                }
            }

            Console.WriteLine("Max sum path of a triangle: {0}", maxValue[0]);
            Console.ReadLine();
        }


        private int[][] Triangle(string path)
        {
            string row;
            string[] rowNumber;
            int rows = 0;

            StreamReader r = new StreamReader(path);
            while ((row = r.ReadLine()) != null)
            {
                rows++;
            }

            int[][] dataTriangle = new int[rows][];

            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((row = r.ReadLine()) != null)
            {
                rowNumber = row.Split(' ');
                dataTriangle[j] = new int[rowNumber.Length];

                for (int i = 0; i < rowNumber.Length; i++)
                {
                    dataTriangle[j][i] = int.Parse(rowNumber[i]);
                }
                j++;
            }

            r.Close();

            return dataTriangle;
        }
    }
}
