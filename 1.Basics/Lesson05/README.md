# Estructuras lineales en `C#` con entradas e impresión de resultados de salida

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Imprimir la suma de dos valores enteros mediante estructuras lineales en `C#`

Ejemplo 1: Cree una aplicación que imprima la suma de dos valores enteros que el usuario ingresa en la ventana de la consola.

Creemos una nueva aplicación de consola y asígnele un nombre `SumGenerator`. Luego, escriba este código dentro del método `Main`:

```csharp
namespace SumGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the first integer:");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the second integer:");
            int second = Convert.ToInt32(Console.ReadLine());

            int result = first + second;
            Console.WriteLine($"The result is {result}");

            Console.ReadKey();
        }
    }
}
```

Con la declaración `Console.WriteLine()`, mostramos el mensaje en la ventana de la consola y pasamos a la siguiente línea. La declaración `Console.ReadLine()` leerá nuestra entrada, pero es de tipo cadena y lo que necesitamos es un tipo int. Entonces, necesitamos convertirlo con la declaración `Convert.ToInt32()`. Finalmente, calculamos la suma y la imprimimos. La declaración `Console.ReadKey()` está aquí solo para mantener abierta la ventana de nuestra consola.

Presionemos F5 para iniciar nuestra aplicación e ingresemos dos números enteros:

```bash
Write the first integer:
5
Write the second integer:
The result is 33
```

## Uso de entradas (nombre y apellido) e impresión del nombre completo con estructuras lineales en `C#`

Ejemplo 2: Escriba una aplicación que para dos entradas proporcionadas (nombre y apellido), imprima el nombre completo en un formato: nombre <espacio> apellido.

Creemos una nueva aplicación de consola y escribamos el código:

```csharp
namespace FullNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your first name:");
            string name = Console.ReadLine();

            Console.WriteLine("What is your last name:");
            string lastName = Console.ReadLine();

            string fullName = name + " " + lastName;
            Console.WriteLine($"Your full name is: {fullName}");

            Console.ReadKey();
        }
    }
}
```

Eso es. Si ejecutamos nuestro proyecto presionando F5, veremos el resultado con el nombre y apellido, separados por espacios.

## Conclusión

Ahora sabemos cómo manipular las entradas en nuestras aplicaciones y cómo mostrar el resultado en la ventana de la consola. Además, hemos utilizado la conversión de datos de `string` a `int` para poder sumar las entradas de un usuario.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com