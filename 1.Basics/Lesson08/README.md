# Bucles while, for y Do-While en `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Bucle While

Mientras que el bucle es un bucle con una condición previa. Esto significa que primero estamos verificando una condición y luego, si una condición devuelve verdadera, ejecutamos nuestra expresión:

```csharp
while(condition)
{
   < expression > ;
}
```

Ejemplo 1: Cree una aplicación que calcule la suma de todos los números desde n hasta m (entradas de un usuario):

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the integer n number:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the integer m number");
        int m = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        while(n <= m)
        {
            sum += n;
            n++;
        }

        Console.WriteLine($"Sum from n to m is {sum}");
        Console.ReadKey();
    }
}
```

El resultado:

```bash
Enter the integer n number:
5
Enter the integer m number
25
Sum from n to m is 315
```

Entonces, expliquemos el código de arriba.

Debido a que calculamos la suma de todos los números desde “n” hasta “m”, necesitamos tener una variable para almacenar ese valor. Debe inicializarse con un cero al principio. Sin eso, nuestra aplicación no podrá compilarse debido a que la variable de suma no está asignada.

En un bucle while, vamos a través de todos los números de `n` a `m` y la adición de cada número de la variable suma. Estamos usando esta expresión: `sum += n`;que es más corta para `sum = sum + n`;

Finalmente, necesitamos incrementar la nvariable en 1. Sin eso, tendríamos un ciclo infinito porque el valor de la nvariable siempre sería menor que el valor de la `m` variable.

Deberíamos usar bucles while cuando el número de iteraciones es incierto. Esto significa que podríamos repetir la iteración hasta que se cumpla alguna condición, pero no estamos seguros de cuántas iteraciones necesitaríamos para alcanzar el cumplimiento de la condición.

## Bucle For

For loop es otro ciclo con una condición previa. Usamos la siguiente sintaxis para escribirlo en C #:

```csharp
for (initialization; condition; progression;)
{
    <loop body > ;
}
```

Usamos la inicialización al comienzo del ciclo y sirve para inicializar la variable con un valor. La condición se utiliza para determinar cuándo se completa el ciclo. La progresión es una parte en la que incrementamos o disminuimos nuestra variable inicializada en la parte de inicialización. El cuerpo consta de todas las expresiones que necesitamos ejecutar siempre que la condición sea verdadera.

Es importante saber que el orden de ejecución es: Inicialización, Condición, Cuerpo del bucle, Progresión.

Ejemplo 1: Cree una aplicación que calcule la suma de todos los números desde n hasta m (entradas de un usuario):

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the integer n number:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the integer m number");
        int m = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        for(int i = n; i <= m; i++)
        {
            sum += i;
        }

        Console.WriteLine($"Sum from n to m is {sum}");

        Console.ReadKey();

    }
}
```

El resultado:

```bash
Enter the integer n number:
98
Enter the integer m number:
327
Sum from n to m is 48875
```

Ejemplo 2: Cree una aplicación que imprima todos los números enteros de n a 1:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number n that is greater than 1: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = n; i >= 1; i--)
        {
            Console.WriteLine(i);
        }

        Console.ReadKey();
    }
}
```

Resultado:

```bash
Enter number n that is greater than 1:
10
10
9
8
7
6
5
4
3
2
1
```

Deberíamos usar bucles for cuando sepamos cuántas iteraciones vamos a tener. Esto significa que si iteramos a través de todos los elementos dentro de una colección o tenemos un punto final para las iteraciones.

## Bucle Do While

El ciclo do-while es un ciclo con poscondición. Lo que esto significa es que el cuerpo del bucle se ejecuta primero y la condición se verifica después. Eso es totalmente opuesto a los ejemplos de bucle anteriores.

Inspeccionemos la implementación de este ciclo:

```csharp
do
{
    < expression > ;
} while (condition);
```

Ahora practiquemos un poco.

Ejemplo 1: Cree una aplicación que calcule la suma de todos los números desde n hasta m (entradas de un usuario):

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the integer n number:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the integer m number");
        int m = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        do
        {
            sum += n;
            n++;
        } while (n <= m);

        Console.WriteLine($"The sum from n to m is {sum}");
        Console.ReadKey();
    }
}
```

```bash
Enter the integer n number:
24
Enter the integer m number:
38
The sum from n to m is 465
```

Ejemplo 2: Cree una aplicación que imprima la suma de todos los números pares an:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the upper border number n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = 2;
        int startingNumber = 4;

        do
        {
            sum += startingNumber;
            startingNumber += 2;
        }while (startingNumber <= n);

        Console.WriteLine($"Sum of all the even numbers to n is {sum}");
        Console.ReadKey();
    }
}
```

```bash
Enter the upper border number n:
10
Sum of all the even numbers to n is 30
```

## Conclusión

Ahora podemos implementar iteraciones en combinación con todo lo que hemos aprendido de los artículos anteriores, haciendo así nuestra aplicación más poderosa.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com