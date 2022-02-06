using System.Drawing;

do
{
    Random rnd = new Random();
    Point A = new Point(rnd.Next(50), rnd.Next(50));
    Point B = new Point(rnd.Next(50), rnd.Next(50));
    Point C = new Point(rnd.Next(50), rnd.Next(50));
    string classLados, classAngulos;

    Console.WriteLine($"Os pontos A({A}), B({B}) e C({C})");

    var AB = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    var BC = Math.Sqrt(Math.Pow(C.X - B.X, 2) + Math.Pow(C.Y - B.Y, 2));
    var CA = Math.Sqrt(Math.Pow(A.X - C.X, 2) + Math.Pow(A.Y - C.Y, 2));
    if (AB + BC > CA && BC + CA > AB && CA + AB > BC)
    {
        // Classificação quanto aos lados
        if (AB == BC && BC == CA)
        {
            classLados = "equilátero";
        }
        else if (AB == BC || BC == CA || CA == AB)
        {
            classLados = "isósceles";
        }
        else
        {
            classLados = "escaleno";
        }

        // Classificação quanto aos angulos
        if (Math.Abs(AB - BC + CA) == 0 || Math.Abs(BC - AB + CA) == 0 || Math.Abs(CA - AB + BC) == 0)
        {
            classAngulos = "degenerado";
        }
        else if (Math.Pow(AB, 2) - Math.Pow(BC, 2) + Math.Pow(CA, 2) == 0 ||
                Math.Pow(BC, 2) - Math.Pow(CA, 2) + Math.Pow(AB, 2) == 0 ||
                Math.Pow(CA, 2) - Math.Pow(AB, 2) + Math.Pow(BC, 2) == 0)
        {
            classAngulos = "retângulo";
        }
        else if (Math.Pow(AB, 2) > Math.Pow(BC, 2) + Math.Pow(CA, 2) ||
                Math.Pow(BC, 2) > Math.Pow(CA, 2) + Math.Pow(AB, 2) ||
                Math.Pow(CA, 2) > Math.Pow(AB, 2) + Math.Pow(BC, 2))
        {
            classAngulos = "obtusângulo";
        }
        else
        {
            classAngulos = "acutângulo";
        }
        Console.WriteLine($"formam um triângulo {classLados} e {classAngulos}.");
    }
    else
    {
        Console.WriteLine("não formam um triângulo.");
    }
    await Task.Delay(2000);
} while (true);