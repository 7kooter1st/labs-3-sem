using System;
using System.Drawing;
using System.Xml.Linq;

namespace Task
{
    abstract class figure
    {
        protected string name;
        protected double square;

        public void SetName(string name_)
        {
            name = name_;
        }

        public virtual void get_square()
        {
        }

        public virtual void Print()
        {
            Console.WriteLine(ToString());
        }

    }

    internal interface IPrint
    {
        void Print();
    }

    class rectangle : figure, IPrint
    {
        protected double width;
        protected double height;


        public rectangle(double height_)
        {
            height = width = height_;
            name = "прямоугольник";
            get_square();
        }
        public rectangle(double height_, double width_)
        {
            height = height_;
            width = width_;
            name = "прямоугольник";
            get_square();
        }
        public override void get_square()
        {
            square = height * width;
        }
        public override string ToString()
        {
            return name + ":\n Ширина: " + width + "\n Высота: " + height + "\n Площадь: " + square;
        }


    }

    class square : rectangle, IPrint
    {
        public square(double height_) : base(height_)
        {
            height = width = height_;
            name = "квадрат";
            get_square();
        }
        public override string ToString()
        {
            return name + ":\n Сторона: " + height + "\n Площадь: " + square;
        }
    }
    class Circle : figure
    {
        protected double radius;

        public Circle(double radius_)
        {
            radius = radius_;
            name = "окружность";
            get_square();
        }
        public override void get_square()
        {
            square = radius * radius * 3.1415;
        }
        public override string ToString()
        {
            return name + ":\n Радиус: " + radius + "\n Площадь: " + square;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите ширину прямоугольника:");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("введите высоту прямоугольника:");
            double height = double.Parse(Console.ReadLine());
            rectangle rectangle = new rectangle(width, height);
            rectangle.Print();

            Console.WriteLine("введите сторону квадрата:");
            double length = double.Parse(Console.ReadLine());
            square square = new square(length);
            square.Print();

            Console.WriteLine("введите радиус окружности:");
            double radius = double.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);
            circle.Print(); 
        }
    }
}