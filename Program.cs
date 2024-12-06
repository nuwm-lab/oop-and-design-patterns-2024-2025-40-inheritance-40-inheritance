using System;

namespace LabWork
{
    public interface IFunction
    {
        void ShowCoefficients();
        void FindValue();
    }

    /// <summary>
    /// Базовий клас для дробово-лінійної функції.
    /// </summary>
    public class Function : IFunction
    {
        private double a0, a1, b0, b1;

        // Властивості для доступу до полів
        protected double A0 => a0;
        protected double A1 => a1;
        protected double B0 => b0;
        protected double B1 => b1;

        // Конструктор
        public Function()
        {
            Console.WriteLine("Введіть коефіцієнти для дробово-лінійної функції:");
            a0 = ReadCoefficient("a0");
            a1 = ReadCoefficient("a1");
            b0 = ReadCoefficient("b0");
            b1 = ReadCoefficient("b1");
        }

        // Метод зчитування коефіцієнта з перевіркою
        protected double ReadCoefficient(string name)
        {
            double value;
            do
            {
                Console.Write($"{name} = ");
                if (double.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            } while (true);
        }

        // Показ коефіцієнтів
        public virtual void ShowCoefficients()
        {
            Console.WriteLine("\nКоефіцієнти дробово-лінійної функції:");
            Console.WriteLine($"Чисельник: {a1}x + {a0}");
            Console.WriteLine($"Знаменник: {b1}x + {b0}");
        }

        // Обчислення значення функції
        public virtual void FindValue()
        {
            Console.Write("\nВведіть значення x0: ");
            if (!double.TryParse(Console.ReadLine(), out double x0))
            {
                Console.WriteLine("Некоректне значення. Розрахунок неможливий.");
                return;
            }

            double denominator = b1 * x0 + b0;
            if (denominator == 0)
            {
                Console.WriteLine("Знаменник дорівнює 0, розрахунок неможливий.");
            }
            else
            {
                double result = (a1 * x0 + a0) / denominator;
                Console.WriteLine($"Значення дробово-лінійної функції при x0 = {x0}: {result}");
            }
        }
    }

    /// <summary>
    /// Похідний клас для дробової функції.
    /// </summary>
    public class FractionFunction : Function
    {
        private double a2, b2;

        // Конструктор
        public FractionFunction() : base()
        {
            Console.WriteLine("\nВведіть додаткові коефіцієнти для дробової функції:");
            a2 = ReadCoefficient("a2");
            b2 = ReadCoefficient("b2");
        }

        // Показ коефіцієнтів
        public override void ShowCoefficients()
        {
            Console.WriteLine("\nКоефіцієнти дробової функції:");
            Console.WriteLine($"Чисельник: {a2}x^2 + {A1}x + {A0}");
            Console.WriteLine($"Знаменник: {b2}x^2 + {B1}x + {B0}");
        }

        // Обчислення значення функції
        public override void FindValue()
        {
            Console.Write("\nВведіть значення x0: ");
            if (!double.TryParse(Console.ReadLine(), out double x0))
            {
                Console.WriteLine("Некоректне значення. Розрахунок неможливий.");
                return;
            }

            double denominator = b2 * Math.Pow(x0, 2) + B1 * x0 + B0;
            if (denominator == 0)
            {
                Console.WriteLine("Знаменник дорівнює 0, розрахунок неможливий.");
            }
            else
            {
                double result = (a2 * Math.Pow(x0, 2) + A1 * x0 + A0) / denominator;
                Console.WriteLine($"Значення дробової функції при x0 = {x0}: {result}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Дробово-лінійна функція ===");
            Function linearFunction = new Function();
            linearFunction.ShowCoefficients();
            linearFunction.FindValue();

            Console.WriteLine("\n=== Дробова функція ===");
            FractionFunction quadraticFunction = new FractionFunction();
            quadraticFunction.ShowCoefficients();
            quadraticFunction.FindValue();
        }
    }
}
