using System;

namespace LabWork
{
    // Клас "одновимірний вектор розмірності 4"
    class Vector4
    {
        protected int[] elements = new int[4];

        // Завдання елементів вектора
        public virtual void SetElements(int[] values)
        {
            if (values.Length != 4)
            {
                throw new ArgumentException("Вектор повинен мати 4 елементи");
            }
            
            for (int i = 0; i < 4; i++)
            {
                elements[i] = values[i];
            }
        }

        // Виведення вектора на екран
        public virtual void Print()
        {
            Console.Write("Вектор: [");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(elements[i]);
                if (i < 3) Console.Write(", ");
            }
            Console.WriteLine("]");
        }

        // Знаходження максимального елемента вектора
        public virtual int MaxElement()
        {
            int max = elements[0];
            for (int i = 1; i < 4; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }
    }

    // Похідний клас "матриця" розмірності 4х4
    class Matrix4x4 : Vector4
    {
        protected int[,] matrix = new int[4, 4];

        // Перевантажений метод завдання елементів матриці
        public override void SetElements(int[] values)
        {
            if (values.Length != 16)
            {
                throw new ArgumentException("Матриця 4х4 повинна мати 16 елементів");
            }
            
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = values[index++];
                }
            }
        }

        // Перевантажений метод виведення матриці на екран
        public override void Print()
        {
            Console.WriteLine("Матриця 4х4:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        // Перевантажений метод знаходження максимального елемента матриці
        public override int MaxElement()
        {
            int max = matrix[0, 0];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єкта класу "одновимірний вектор"
            Vector4 vector = new Vector4();
            vector.SetElements(new int[] { 5, 8, 3, 10 });
            vector.Print();
            Console.WriteLine($"Максимальний елемент вектора: {vector.MaxElement()}");
            
            Console.WriteLine();
            
            // Створення об'єкта класу "матриця"
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetElements(new int[] { 
                1, 5, 9, 13,
                2, 20, 10, 14,
                3, 7, 11, 15,
                4, 8, 12, 16
            });
            matrix.Print();
            Console.WriteLine($"Максимальний елемент матриці: {matrix.MaxElement()}");
        }
    }
}
