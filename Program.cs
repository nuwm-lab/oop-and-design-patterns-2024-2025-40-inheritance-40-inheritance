using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Program
    {
        static void Main(string[] args)
        {
            Geometry.Ellipse curve;

            Console.WriteLine("Choose the type of curve (1 for Ellipse, 2 for Second Order Curve):");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                curve = new Geometry.Ellipse();
                Console.WriteLine("Enter the coefficients for the ellipse (a, b):");
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                curve.SetCoefficients(a, b);
            }
            else
            {
                curve = new Geometry.SecondOrderCurve();
                Console.WriteLine("Enter the coefficients for the second order curve (a11, a12, a22, b1, b2, c):");
                double a11 = double.Parse(Console.ReadLine());
                double a12 = double.Parse(Console.ReadLine());
                double a22 = double.Parse(Console.ReadLine());
                double b1 = double.Parse(Console.ReadLine());
                double b2 = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());
                ((Geometry.SecondOrderCurve)curve).SetCoefficients(a11, a12, a22, b1, b2, c);
            }

            curve.PrintCoefficients();

            Console.WriteLine("Enter the point (x, y) to check if it lies on the curve:");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (curve.IsPointOnCurve(x, y))
            {
                Console.WriteLine("The point lies on the curve.");
            }
            else
            {
                Console.WriteLine("The point does not lie on the curve.");
            }
        }
    }
}

namespace Geometry
{
    class Ellipse
    {
        protected double a;
        protected double b;
        protected double a11;
        protected double a12;
        protected double a22;
        protected double b1;
        protected double b2;
        protected double c;

        // Оригінальний метод для Ellipse
        public virtual void SetCoefficients(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Ellipse coefficients: a = {a}, b = {b}");
        }

        public virtual bool IsPointOnCurve(double x, double y)
        {
            return (x * x) / (a * a) + (y * y) / (b * b) == 1;
        }
    }

    class SecondOrderCurve : Ellipse
    {
        public override void SetCoefficients(double a, double b)
        {
            base.SetCoefficients(a, b);
        }

        public void SetCoefficients(double a11, double a12, double a22, double b1, double b2, double c)
        {
            this.a11 = a11;
            this.a12 = a12;
            this.a22 = a22;
            this.b1 = b1;
            this.b2 = b2;
            this.c = c;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Second order curve coefficients: a11 = {a11}, a12 = {a12}, a22 = {a22}, b1 = {b1}, b2 = {b2}, c = {c}");
        }

        public override bool IsPointOnCurve(double x, double y)
        {
            return a11 * x * x + 2 * a12 * x * y + a22 * y * y + b1 * x + b2 * y + c == 0;
        }
    }
}