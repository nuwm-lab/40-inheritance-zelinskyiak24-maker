using System;
using System.Globalization;

class Rectangle
{
    protected double b1, a1, b2, a2;

    public Rectangle()
    {
        b1 = 0;
        a1 = 0;
        b2 = 0;
        a2 = 0;
    }

    public Rectangle(double b1, double a1, double b2, double a2)
    {
        SetCoefficients(b1, a1, b2, a2);
    }

    public virtual void SetCoefficients(double b1, double a1, double b2, double a2)
    {
        if (b1 > a1) (b1, a1) = (a1, b1);
        if (b2 > a2) (b2, a2) = (a2, b2);

        this.b1 = b1;
        this.a1 = a1;
        this.b2 = b2;
        this.a2 = a2;
    }

    public virtual void Print()
    {
        Console.WriteLine("Прямокутник:");
        Console.WriteLine($"b1 <= x1 <= a1 : {b1} <= x <= {a1}");
        Console.WriteLine($"b2 <= x2 <= a2 : {b2} <= y <= {a2}");
    }

    public virtual bool ContainsPoint(double x, double y)
    {
        return x >= b1 && x <= a1 && y >= b2 && y <= a2;
    }
}

class Parallelepiped : Rectangle
{
    protected double b3, a3;

    public Parallelepiped() : base()
    {
        b3 = 0;
        a3 = 0;
    }

    public Parallelepiped(double b1, double a1, double b2, double a2, double b3, double a3)
        : base(b1, a1, b2, a2)
    {
        SetCoefficients(b1, a1, b2, a2, b3, a3);
    }

    public void SetCoefficients(double b1, double a1, double b2, double a2, double b3, double a3)
    {
        base.SetCoefficients(b1, a1, b2, a2);

        if (b3 > a3) (b3, a3) = (a3, b3);
        this.b3 = b3;
        this.a3 = a3;
    }

    public override void Print()
    {
        Console.WriteLine("Паралелепіпед:");
        Console.WriteLine($"b1 <= x1 <= a1 : {b1} <= x <= {a1}");
        Console.WriteLine($"b2 <= x2 <= a2 : {b2} <= y <= {a2}");
        Console.WriteLine($"b3 <= x3 <= a3 : {b3} <= z <= {a3}");
    }

    public bool ContainsPoint(double x, double y, double z)
    {
        return x >= b1 && x <= a1 && y >= b2 && y <= a2 && z >= b3 && z <= a3;
    }
}

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Лабораторна: Наслідування (Прямокутник, Паралелепіпед)");
        Console.WriteLine("Вводь числа через крапку або кому.\n");

        Rectangle rect = CreateRectangleFromInput();
        Console.WriteLine();
        rect.Print();

        Console.WriteLine();
        Console.WriteLine("Введи точку для перевірки прямокутника (x y):");
        double x = ReadDouble("x = ");
        double y = ReadDouble("y = ");

        bool insideRect = rect.ContainsPoint(x, y);
        Console.WriteLine(insideRect ? "Точка належить прямокутнику." : "Точка НЕ належить прямокутнику.");

        Console.WriteLine("\n-----------------------------\n");

        Parallelepiped par = CreateParallelepipedFromInput();
        Console.WriteLine();
        par.Print();

        Console.WriteLine();
        Console.WriteLine("Введи точку для перевірки паралелепіпеда (x y z):");
        double x3 = ReadDouble("x = ");
        double y3 = ReadDouble("y = ");
        double z3 = ReadDouble("z = ");

        bool insidePar = par.ContainsPoint(x3, y3, z3);
        Console.WriteLine(insidePar ? "Точка належить паралелепіпеду." : "Точка НЕ належить паралелепіпеду.");

        Console.WriteLine("\nНатисни Enter для виходу...");
        Console.ReadLine();
    }

    static Rectangle CreateRectangleFromInput()
    {
        Console.WriteLine("Створення прямокутника b1<=x<=a1, b2<=y<=a2");
        double b1 = ReadDouble("b1 = ");
        double a1 = ReadDouble("a1 = ");
        double b2 = ReadDouble("b2 = ");
        double a2 = ReadDouble("a2 = ");

        return new Rectangle(b1, a1, b2, a2);
    }

    static Parallelepiped CreateParallelepipedFromInput()
    {
        Console.WriteLine("Створення паралелепіпеда b1<=x<=a1, b2<=y<=a2, b3<=z<=a3");
        double b1 = ReadDouble("b1 = ");
        double a1 = ReadDouble("a1 = ");
        double b2 = ReadDouble("b2 = ");
        double a2 = ReadDouble("a2 = ");
        double b3 = ReadDouble("b3 = ");
        double a3 = ReadDouble("a3 = ");

        return new Parallelepiped(b1, a1, b2, a2, b3, a3);
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();

            if (s == null) s = "";
            s = s.Trim().Replace(',', '.');

            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                return value;

            Console.WriteLine("Помилка вводу. Спробуй ще раз.");
        }
    }
}
