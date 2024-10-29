using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{

    public class SimpleList<T>
    {
        private Node<T> head;

        public SimpleList()
        {
            head = null;
        }

        // Метод для добавления элемента в начало списка
        public void Add(T element)
        {
            head = new Node<T>(element, head);
        }

        // Метод для удаления элемента из начала списка
        public T Remove()
        {
            if (head == null)
            {
                throw new Exception("Список пуст");
            }

            T element = head.Data;
            head = head.Next;
            return element;
        }

        // Метод для вывода списка
        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Внутренний класс узла списка
        private class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public Node(T data, Node<T> next)
            {
                Data = data;
                Next = next;
            }
        }
    }

    // Класс стека, наследующийся от односвязного списка
    public class SimpleStack<T> : SimpleList<T>
    {
        // Метод для добавления элемента в стек (Push)
        public void Push(T element)
        {
            Add(element); // Используем метод Add базового класса
        }

        // Метод для удаления элемента из стека (Pop)
        public T Pop()
        {
            return Remove(); // Используем метод Remove базового класса
        }
    }
    public abstract class Figure : IComparable
    {
        protected string name;
        protected double area; 

        public void SetName(string name_)
        {
            name = name_;
        }

        public virtual void CalculateArea()
        {
            // Вычисление площади в производных классах
        }

        public virtual void Print()
        {
            Console.WriteLine(ToString());
        }

        // Реализация IComparable для сортировки по площади
        public int CompareTo(object obj)
        {
            if (obj == null) return 1; // Текущий объект больше, если другой null

            Figure otherFigure = obj as Figure;
            if (otherFigure != null)
            {
                // Сравниваем площади
                return area.CompareTo(otherFigure.area);
            }
            else
            {
                throw new ArgumentException("Object is not a Figure");
            }
        }

        public override string ToString()
        {
            return $"{name}: Площадь = {area}";
        }
    }

    // Класс "Прямоугольник"
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            name = "Прямоугольник";
            CalculateArea();
        }

        public override void CalculateArea()
        {
            area = width * height;
        }
    }

    // Класс "Квадрат"
    class Square : Figure
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
            name = "Квадрат";
            CalculateArea();
        }

        public override void CalculateArea()
        {
            area = side * side;
        }
    }

    // Класс "Круг"
    class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
            name = "Круг";
            CalculateArea();
        }

        public override void CalculateArea()
        {
            area = Math.PI * radius * radius;
        }
    }


    public class SparseMatrix3D
    {
        private Dictionary<Tuple<int, int, int>, Figure> elements;

        public SparseMatrix3D()
        {
            elements = new Dictionary<Tuple<int, int, int>, Figure>();
        }

        public Figure this[int x, int y, int z]
        {
            get
            {
                Tuple<int, int, int> key = Tuple.Create(x, y, z);
                if (elements.ContainsKey(key))
                {
                    return elements[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Tuple<int, int, int> key = Tuple.Create(x, y, z);
                if (value != null)
                {
                    elements[key] = value;
                }
                else
                {
                    elements.Remove(key);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SparseMatrix3D:");
            foreach (var kvp in elements)
            {
                sb.AppendLine($"({kvp.Key.Item1}, {kvp.Key.Item2}, {kvp.Key.Item3}): {kvp.Value}");
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем список фигур
            List<Figure> figures = new List<Figure>()
            {
                new Rectangle(5, 10),
                new Square(7),
                new Circle(3)
            };

            // Сортировка списка по площади
            figures.Sort();

            // Вывод отсортированных фигур
            Console.WriteLine("Отсортированные фигуры по площади:");
            foreach (Figure figure in figures)
            {
                figure.Print();
            }

            

            SparseMatrix3D matrix = new SparseMatrix3D();

            // Добавляем фигуры в матрицу
            matrix[1, 2, 3] = new Square(5);
            matrix[0, 0, 0] = new Circle(3);

            // Выводим матрицу
            Console.WriteLine(matrix);

            // Доступ к фигуре в определенной точке
            Figure figure1 = matrix[1, 2, 3];
            if (figure1 != null)
            {
                Console.WriteLine($"В точке (1, 2, 3) находится: {figure1}");
            }

            SimpleStack<Figure> stack = new SimpleStack<Figure>();

            // Добавляем элементы в стек
            stack.Push(new Rectangle(5,10));
            stack.Push(new Square(7));
            stack.Push(new Circle(3));

            // Выводим стек
            Console.WriteLine("Стек:");
            stack.Print(); // Вывод: 3 2 1

            // Извлекаем элементы из стека
            Console.WriteLine("Извлеченные элементы:");
            Console.WriteLine(stack.Pop()); // Вывод: 3
            Console.WriteLine(stack.Pop()); // Вывод: 2
            Console.WriteLine(stack.Pop()); // Вывод: 1

            Console.ReadKey();
        }
    }
}