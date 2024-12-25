using System;

namespace OOAD.lab1
{
    class QuadraticEquation2
    {
        // Thuộc tính
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        // Constructor 
        public QuadraticEquation2(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        // Phương thức giải phương trình bậc 2
        public double[] Resolve()
        {
            double delta = B * B - 4 * A * C;
            if (delta < 0)
            {
                return new double[0];
            }
            else if (delta == 0)
            {
                return new double[] { -B / (2 * A) };
            }
            else
            {
                return new double[] { (-B + Math.Sqrt(delta)) / (2 * A), (-B - Math.Sqrt(delta)) / (2 * A) };
            }
        }

    }

    class View 
    {
        public void ShowResult(QuadraticEquation2 qe2)
        {
            double[] results = qe2.Resolve();
            if (results.Length == 0)
            {
                Console.WriteLine("Phương trình vô nghiệm");
            }
            else if (results.Length == 1)
            {
                Console.WriteLine("Phương trình có nghiệm kép x = {0}", results[0]);
            }
            else
            {
                Console.WriteLine("Phương trình có 2 nghiệm phân biệt x1 = {0}, x2 = {1}", results[0], results[1]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhập a: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập b: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập c: ");
            double c = double.Parse(Console.ReadLine());

            QuadraticEquation2 qe2 = new QuadraticEquation2(a, b, c);

            View view = new View();
            view.ShowResult(qe2);
        }
    }
}
