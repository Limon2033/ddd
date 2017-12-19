using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string b;
            int n, s = 0, d, p = 0, q = 0, max, min;
            char a;
            Console.Write("Введите размер массива: ");
            n = int.Parse(Console.ReadLine());
            int[] x = new int[n];
            IO(x);
            s = Sum(s, x);
            Console.WriteLine("\n\nСумма всех элементов массива: " + s);
            d = s / n;
            Console.WriteLine("\nСреднее арифмитическое: " + d);
            Console.Write("\nСумма отрицательных(-) или положительных(+) чисел: ");
            a = char.Parse(Console.ReadLine());
            s = Sum(a, x);
            Console.WriteLine("Сумма {0} чисел={1}", a, s);
            Console.Write("\nСумма нечетных(1) или четных(2) чисел: ");
            a = char.Parse(Console.ReadLine());
            s = Sum(a, x);
            Console.WriteLine("Сумма {0} чисел={1}", a, s);
            Console.WriteLine("\nMax или min элемент массива: ");
            b = Console.ReadLine();
            max = Max(x, ref p);
            min = Min(x, ref q);
            if (b=="max")
                Console.WriteLine("Max элемент массива={0}, а его индекс={1}",max, p);
            else if (b=="min")
                Console.WriteLine("Min элемент массива={0}, а его индекс={1}",min, q);
            s = P(x, max, min, p, q);
            Console.WriteLine("\nПроизведение между max и min элементами массива="+s);
            Console.ReadKey();
        }

        private static int P(int[] x, int max, int min, int p, int q)
        {
            int i, s = 1;
            if (q < p)
                for (i = q + 1; i < p; i++)
                    s *= x[i];
            else
                for (i = p + 1; i < q; i++)
                    s *= x[i];
            return s;
        }

        private static int Min(int[] x, ref int q)
        {
            int min, i;
            min = x[0];
            for (i = 1; i < x.Length; i++)
                if (x[i] < min)
                {
                    min = x[i];
                    q = i;
                }
            return min;
        }

        private static int Max(int[] x, ref int p)
        {
            int i, max;
            max = x[0];
            for (i = 1; i < x.Length; i++)
                if (x[i] > max)
                {
                    max = x[i];
                    p = i;
                }
            return max;
        }

        private static int Sum(char a, int[] x)
        {
            int i, s = 0;
            switch (a)
            {
                case '-':
                    for (i = 0; i < x.Length; i++)
                        if (x[i] < 0)
                            s += x[i];
                    break;
                case '+':
                     for (i = 0; i < x.Length; i++)
                        if (x[i] > 0)
                            s += x[i];
                    break;
                case '1':
                    for (i = 0; i < x.Length; i++)
                        if (x[i] % 2 != 0)
                            s += x[i];
                    break;
                case '2':
                    for (i = 0; i < x.Length; i++)
                        if (x[i] % 2 == 0)
                            s += x[i];
                    break;
            }
            return s;
        }

        private static int Sum(int s, int[] x)
        {
            for (int i = 0; i < x.Length; i++)
                s += x[i];
            return s;
        }

        private static void IO(int[] x)
        {
            int i;
            for (i = 0; i < x.Length; i++)
            {
                Console.Write("x[{0}]=", i);
                x[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            for (i = 0; i < x.Length; i++)
                Console.Write(x[i] + " ");
        }
    }
}
