using System;

class Triangle
{
    protected double x1, y1, x2, y2, x3, y3;

    // Метод для задання координат вершин трикутника
    public void SetCoordinates(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
    }

    // Метод для виведення координат вершин на екран
    public virtual void PrintCoordinates()
    {
        Console.WriteLine("Трикутник: ");
        Console.WriteLine($"Вершина 1: ({x1}, {y1})");
        Console.WriteLine($"Вершина 2: ({x2}, {y2})");
        Console.WriteLine($"Вершина 3: ({x3}, {y3})");
    }

    // Метод для обчислення площі трикутника
    public virtual double CalculateArea()
    {
        return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
    }
}

class ConvexQuadrilateral : Triangle
{
    private double x4, y4;

    // Метод для задання координат вершин чотирикутника
    public void SetCoordinates(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        base.SetCoordinates(x1, y1, x2, y2, x3, y3);
        this.x4 = x4;
        this.y4 = y4;
    }

    // Перевантажений метод для виведення координат вершин на екран
    public override void PrintCoordinates()
    {
        Console.WriteLine("Опуклий чотирикутник: ");
        Console.WriteLine($"Вершина 1: ({x1}, {y1})");
        Console.WriteLine($"Вершина 2: ({x2}, {y2})");
        Console.WriteLine($"Вершина 3: ({x3}, {y3})");
        Console.WriteLine($"Вершина 4: ({x4}, {y4})");
    }

    // Перевантажений метод для обчислення площі чотирикутника
    public override double CalculateArea()
    {
        double area1 = base.CalculateArea();
        double area2 = Math.Abs((x1 * (y3 - y4) + x3 * (y4 - y1) + x4 * (y1 - y3)) / 2.0);
        return area1 + area2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Введення координат трикутника
        Console.WriteLine("Введіть координати трикутника:");
        Console.Write("Вершина 1 (x y): ");
        var t1 = Console.ReadLine().Split();
        Console.Write("Вершина 2 (x y): ");
        var t2 = Console.ReadLine().Split();
        Console.Write("Вершина 3 (x y): ");
        var t3 = Console.ReadLine().Split();

        Triangle triangle = new Triangle();
        triangle.SetCoordinates(
            double.Parse(t1[0]), double.Parse(t1[1]),
            double.Parse(t2[0]), double.Parse(t2[1]),
            double.Parse(t3[0]), double.Parse(t3[1])
        );
        triangle.PrintCoordinates();
        Console.WriteLine($"Площа трикутника: {triangle.CalculateArea()}");

        // Введення координат чотирикутника
        Console.WriteLine("\nВведіть координати чотирикутника:");
        Console.Write("Вершина 1 (x y): ");
        var q1 = Console.ReadLine().Split();
        Console.Write("Вершина 2 (x y): ");
        var q2 = Console.ReadLine().Split();
        Console.Write("Вершина 3 (x y): ");
        var q3 = Console.ReadLine().Split();
        Console.Write("Вершина 4 (x y): ");
        var q4 = Console.ReadLine().Split();

        ConvexQuadrilateral quadrilateral = new ConvexQuadrilateral();
        quadrilateral.SetCoordinates(
            double.Parse(q1[0]), double.Parse(q1[1]),
            double.Parse(q2[0]), double.Parse(q2[1]),
            double.Parse(q3[0]), double.Parse(q3[1]),
            double.Parse(q4[0]), double.Parse(q4[1])
        );
        quadrilateral.PrintCoordinates();
        Console.WriteLine($"Площа опуклого чотирикутника: {quadrilateral.CalculateArea()}");
    }
} 