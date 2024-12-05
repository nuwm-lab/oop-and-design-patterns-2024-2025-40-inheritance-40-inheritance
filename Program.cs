﻿using System;

namespace LabWork
{
    public class Function
    {
        protected double a0, a1, b0, b1;

        public Function()
        {
            Console.WriteLine("Введіть коефіцієнти функції:");
            Console.WriteLine($"\nЧисельник:");
            Console.Write($"a0 = ");
            while (!double.TryParse(Console.ReadLine(), out a0))
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                Console.Write($"a0 = ");
            }
            Console.Write($"a1 = ");
            while (!double.TryParse(Console.ReadLine(), out a1))
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                Console.Write($"a1 = ");
            }
            Console.WriteLine($"\nЗнаменник:");
            Console.Write($"b0 = ");
            while (!double.TryParse(Console.ReadLine(), out b0))
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                Console.Write($"b0 = ");
            }
            Console.Write($"b1 = ");
            while (!double.TryParse(Console.ReadLine(), out b1))
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                Console.Write($"b1 = ");
            }
        }

        public virtual void ShowCoefficients()
        {
            Console.WriteLine("\nКоефіцієнти функції:");
            Console.WriteLine($"{a1}x + {a0}");
            Console.WriteLine("------");
            Console.WriteLine($"{b1}x + {b0}");
        }

        public virtual void FindValue()
        {
            Console.Write("\nВведіть значення для x0 = ");
            double x0 = double.Parse(Console.ReadLine());
            double denominator = b1 * x0 + b0;
            if (denominator == 0)
            {
                Console.WriteLine("\nЗнаменник дорівнює 0, розрахунок неможливий.");
            }
            else
            {
                double result = (a1 * x0 + a0) / denominator;
                Console.WriteLine($"\nЗначення дробово-лінійної функції при x0 = {x0}: {result}");
            }
        }
    }

    public class FractionFunction : Function
    {
        private double a2, b2;

        public FractionFunction() : base()
        {
            Console.WriteLine("\nВведіть додаткові коефіцієнти для квадратичної функції:");
            Console.Write($"a2 = ");
            while (!double.TryParse(Console.ReadLine(), out a2))
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                Console.Write($"a2 = ");
            }
            Console.Write($"b2 = ");
            while (!double.TryParse(Console.ReadLine(), out b2))
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                Console.Write($"b2 = ");
            }
        }

        public override void ShowCoefficients()
        {
            Console.WriteLine("\nКоефіцієнти функції");
            Console.WriteLine($"{a2}x^2 + {a1}x + {a0}");
            Console.WriteLine("-------------");
            Console.WriteLine($"{b2}x^2 + {b1}x + {b0}");
        }

        public override void FindValue()
        {
            Console.Write("\nВведіть значення для x0 = ");
            double x0 = double.Parse(Console.ReadLine());
            double denominator = b2 * Math.Pow(x0, 2) + b1 * x0 + b0;
            if (denominator == 0)
            {
                Console.WriteLine("Знаменник дорівнює 0, розрахунок неможливий.");
            }
            else
            {
                double result = (a2 * Math.Pow(x0, 2) + a1 * x0 + a0) / denominator;
                Console.WriteLine($"\nЗначення дробової функції при x0 = {x0}: {result}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Function linearFunction = new Function();
            linearFunction.ShowCoefficients();
            linearFunction.FindValue();

            FractionFunction quadraticFunction = new FractionFunction();
            quadraticFunction.ShowCoefficients();
            quadraticFunction.FindValue();
        }
    }
}
