# Manejo de excepciones en `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## ¿Qué es la excepción?

La excepción es un problema que aparece inesperadamente en nuestro código mientras desarrollamos nuestro proyecto. Es por eso que llamamos a estas excepciones excepciones no controladas. Si no se manejan, harán que nuestra aplicación deje de funcionar y lanzará uno de los mensajes de excepción. Eso no es algo que queremos en nuestro código.

## Bloque Try-Catch

C # nos proporciona soporte integrado para manejar estas excepciones mediante el uso de un `try-catch` bloque de código:

```csharp
try
{
    // expressions that could cause an exception
}
catch(Exception ex)
{
    // handle exception
}
```

En el bloque `try`, escribimos nuestro código y el bloque `catch` manejará todas las excepciones que puedan surgir en el bloque `try` . De esta manera, nuestro programa no se detendrá en absoluto y podemos mostrar algún mensaje significativo a un usuario.

Veamos cómo funciona nuestro programa sin y con manejo de excepciones.

Ejemplo 1: Cree una aplicación que imprima la raíz cuadrada del número entero ingresado por el usuario:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(Math.Sqrt(num));
    }
}
```

Este código funcionará bien si un usuario ingresa un número entero, pero mire lo que sucederá si un usuario ingresa una cadena:

![img01](/img/01.png)

Vemos que nuestra aplicación ha dejado de funcionar. Esto es muy malo para la experiencia del usuario. Entonces, implementemos el mismo código pero con el bloque `try-catch`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter your number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Math.Sqrt(num));
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"There is something wrong in our application, please look at this message: {ex.Message}");
            Console.ReadKey();
        }
    }
}
```

Si miramos el resultado ahora:

![img02](/img/02.png)

Como podemos ver, nuestra aplicación no se ha detenido y tenemos un mensaje agradable y legible para nuestro usuario, que proporciona una experiencia de usuario mucho mejor que en el ejemplo anterior.

## Excepciones específicas

C # tiene su propio conjunto de excepciones específicas que podemos usar en nuestra aplicación. Algunos de ellos son: NullReferenceException, ArgumentOutOfRangeException, InvalidCastException, FileNotFoundException, DevideByZeroException, FormatException, InvalidOperationException, etc.

Veamos cómo podemos usarlos en nuestro código:

```csharp
public class Program
{
    public static void Main()
    {
        try
        {
            //Code in here that could cause an exception
        }
        catch (DivideByZeroException ex)
        {
            Console.Write("Cannot divide by zero. Please try again.");
        }
        catch (InvalidOperationException ex)
        {
            Console.Write("Not a valid number. Please try again.");
        }
        catch (FormatException ex)
        {
            Console.Write("Not a valid number. Please try again.");
        }
        catch(Exception ex)
        {
            Console.Write("Any exception that previous catch blocks didn’t handle.");
        }

        Console.ReadKey();

    }
}
```

Es muy importante colocar los `catch` bloques específicos antes del global bloque `catch`, de lo contrario, nuestro compilador se quejará:

![img03](/img/03.png)

## Conclusión

Ahora sabemos cómo escribir un código seguro y cómo manejar errores en nuestra aplicación.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com