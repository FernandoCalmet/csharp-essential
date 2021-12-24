# Métodos recursivos y recursivos en `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## ¿Qué es la recursividad?

La recursividad es un concepto en el que el método se llama a sí mismo. Cada método recursivo debe terminarse, por lo tanto, debemos escribir una condición en la que verifiquemos si se cumple la condición de terminación. Si no hacemos eso, un método recursivo terminará llamándose a sí mismo sin cesar.

Ejemplo 1: Cree una aplicación que calcule la suma de todos los números desde n hasta m de forma recursiva:

```csharp
class Program
{
    public static int CalculateSumRecursively(int n, int m)
    {
        int sum = n;

        if(n < m)
        {
            n++;
            return sum += CalculateSumRecursively(n, m);
        }

        return sum;
   }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter number n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number m: ");
        int m = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSumRecursively(n, m);

        Console.WriteLine(sum);

        Console.ReadKey();
    }
}
```

## Explicación del código

El método `CalculateSumRecursively` es nuestro método recursivo que calcula la suma de los números desde `n` hasta `m`. Lo primero que hacemos es establecer nuestro `sum` en el valor de `n`. Luego, verificamos si el valor de `n` es menor que el valor de `m`. Si es así, aumentamos el valor de `n` en 1 y sumamos a nuestro `sum` resultado a del mismo método pero con el aumento `n`. Si no es así, simplemente devolvemos el valor de la `sum` variable.

C # reservará almacenamiento de memoria para cada método recursivo para que los valores del método anterior no se anulen.

Entonces, veamos nuestro ejemplo a través del diagrama:

![img01](/img/01.png)

## Ejemplo adicional

Practiquemos un poco más con el Example2: Cree una aplicación que imprima cuántas veces el número se puede dividir por 2 de manera uniforme:

```csharp
class Program
{
    public static int CountDivisions(double number)
    {
        int count = 0;

        if(number > 0 && number % 2 == 0)
        {
            count++;
            number /= 2;

            return count += CountDivisions(number);
        }

        return count;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter your number: ");
        double number = Convert.ToDouble(Console.ReadLine());

        int count = CountDivisions(number);
        Console.WriteLine($"Total number of divisions: {count}");

        Console.ReadKey();
    }
}
```

## Conclusión

Ahora tenemos un buen conocimiento de la recursividad y los métodos recursivos.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com