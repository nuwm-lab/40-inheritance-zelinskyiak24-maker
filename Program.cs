using System;

class Sphere
{
    public double x;
    public double y;
    public double z;
    public double r;

    public void Input()
    {
        Console.Write("Введіть x: ");
        x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть y: ");
        y = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть z: ");
        z = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть радіус R: ");
        r = Convert.ToDouble(Console.ReadLine());
    }

    public void Show()
    {
        Console.WriteLine("Куля");
        Console.WriteLine("Центр: (" + x + ", " + y + ", " + z + ")");
        Console.WriteLine("Радіус = " + r);
    }

    public double Volume()
    {
        return 4.0 / 3.0 * Math.PI * r * r * r;
    }
}

class Ellipsoid : Sphere
{
    public double a;
    public double b;
    public double c;

    public void InputEllipsoid()
    {
        Console.Write("Введіть x: ");
        x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть y: ");
        y = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть z: ");
        z = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть a: ");
        a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть b: ");
        b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть c: ");
        c = Convert.ToDouble(Console.ReadLine());
    }

    public void ShowEllipsoid()
    {
        Console.WriteLine("Еліпсоїд");
        Console.WriteLine("Центр: (" + x + ", " + y + ", " + z + ")");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("c = " + c);
    }

    public double VolumeEllipsoid()
    {
        return 4.0 / 3.0 * Math.PI * a * b * c;
    }
}

class Program
{
    static void Main()
    {
        Sphere sphere = new Sphere();
        Console.WriteLine("Введення даних для кулі");
        sphere.Input();
        sphere.Show();
        Console.WriteLine("Обʼєм кулі = " + sphere.Volume());
        Console.WriteLine();

        Ellipsoid ellipsoid = new Ellipsoid();
        Console.WriteLine("Введення даних для еліпсоїда");
        ellipsoid.InputEllipsoid();
        ellipsoid.ShowEllipsoid();
        Console.WriteLine("Обʼєм еліпсоїда = " + ellipsoid.VolumeEllipsoid());
    }
}
