# Métodos de `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Firmas de métodos

Podemos declarar nuestros métodos especificando la firma del método que consiste en el modificador de acceso (público, privado…), el  nombre de un método y los parámetros del método . Si queremos que nuestro método tenga una implementación, debe tener dos llaves para especificar el cuerpo del método. Colocamos nuestro código entre esas llaves. Además, tenemos que incluir un valor de retorno (void, int, double…) para que nuestro método sea válido. El tipo de retorno no se aplica como parte de la firma del método, pero no podemos crear un método sin él. Por lo tanto, se inyecta a sí mismo en una firma (o especificación).

Un método que devuelve un valor debe satisfacer dos condiciones. Primero, debe especificar un `return type` antes del nombre del método. El segundo, debe tener una returndeclaración dentro de su cuerpo (dentro de llaves). Por otro lado, si el método no devuelve nada, void se usa la palabra clave en lugar de la palabra clave return. Si ese es el caso, un método no necesita tener una declaración de retorno dentro de su cuerpo:

![img01](/img/01.png)

En nuestro proyecto, podemos tener dos métodos diferentes con el mismo nombre, pero no podemos tener dos métodos diferentes con la misma firma del método. Al menos una parte de la firma del método debe ser diferente. Cuando tenemos dos o más métodos con el mismo nombre pero diferentes firmas, eso se llama Sobrecarga de métodos.

## Parámetros y argumentos

En el ejemplo anterior, hemos visto que nuestros métodos aceptan solo un parámetro. Pero podemos crear un método que acepte tantos parámetros como necesitemos:

```csharp
public void WriteAllNumbers(int a, int b, int c)
{
     Console.WriteLine($"{a} {b} {c}");
}
```

Es importante que cada parámetro tenga su propio tipo, nombre y que estén separados por comas.

Cuando creamos un método en la firma, creamos parámetros (imagínelos como marcadores de posición para el valor del mismo tipo). Pero, cuando llamamos a ese método, estamos pasando valores reales (argumentos) para esos parámetros:

```csharp
WriteAllNumbers(15, 16, 67);
```

Ejemplo 1: Cree una aplicación que imprima la suma, resta y multiplicación de dos entradas:

```csharp
class Program
{
    public static void Sum(int first, int second) //method needs to be static because we are calling it in a static Main method.
    {
        int result = first + second;
        Console.WriteLine($"Sum result: {result}");
    }

    public static void Subtract(int first, int second)
    {
        int result = first - second;
        Console.WriteLine($"Substraction result: {result}");
    }

    public static void Multiplication(int first, int second)
    {
        int result = first * second;
        Console.WriteLine($"Multiplication result: {result}");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number: ");
        int firstArgument = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second number: ");
        int secondArgument = Convert.ToInt32(Console.ReadLine());

        Sum(firstArgument, secondArgument);
        Subtract(firstArgument, secondArgument);
        Multiplication(firstArgument, secondArgument);

        Console.ReadKey();
    }
}
```

Una vez que ejecutemos nuestra aplicación, veremos el resultado:

```bash
Enter the first number:
12
Enter the second number:
10
Sum result: 22
Substraction result: 2
Multiplication result: 120
```

## Parámetros opcionales

Un parámetro opcional tiene un valor predeterminado. El método que tiene parámetros opcionales podría llamarse sin esos argumentos. Pero también podemos proporcionárselos. Si proporcionamos los valores como argumentos para parámetros opcionales, los valores predeterminados se anularán:

```csharp
public static void MethodWithOptParams(int first, int second = 10)
{
    Console.WriteLine(first + second);
}

MethodWithOptParams(20); //result is 30
MethodWithOptParams(20, 35); //result is 55
```

## Conclusión

El uso de métodos es muy útil, no solo en C # sino en la programación en general. Entonces, tener este conocimiento es una gran ventaja. No tenga miedo de usarlos mientras codifica, harán que su código sea más limpio, fácil de mantener, legible y, sobre todo, reutilizable.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com