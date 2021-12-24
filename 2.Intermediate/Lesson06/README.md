# Enumeraciones

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Trabajar con enumeraciones en C #

Supongamos que necesitamos representar los días de una semana en nuestro proyecto de C #. Podemos usar un número entero para representar todos los días de una semana (de 0 a 6), y aunque eso funcionaría bien, no es legible en absoluto. Aquí es donde sobresalen las enumeraciones.

Para declarar enumeración podemos usar la siguiente sintaxis:

```csharp
public enum DaysInWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
```

Después de haber declarado nuestra enumeración, podemos usarla exactamente de la misma manera que cualquier otro tipo:

```csharp
static void Main(string[] args)
{
    DaysInWeek monday = DaysInWeek.Monday;

    Console.WriteLine(monday); // It is going to print out Monday
    Console.ReadKey();
}
```

Como podemos ver, debemos escribir `DaysInWeek.Mondayy` no solo el lunes porque todos los nombres literales de enumeración están dentro del alcance de su tipo de enumeración.

## Elegir valores literales de enumeración

Internamente, un tipo de enumeración asigna el valor entero a cada elemento dentro de esa enumeración. Esos números comienzan en 0 y aumentan en 1 por cada otro elemento. En nuestro ejemplo anterior, imprimimos el valor que coincide con el elemento exacto de una enumeración. Pero también podemos imprimir el valor entero al convertirlo en su tipo subyacente:

```csharp
static void Main(string[] args)
{
     DaysInWeek monday = DaysInWeek.Monday;

     Console.WriteLine((int)monday); //prints out the 0

     Console.ReadKey();
}
```

Si lo preferimos, podemos asignar una constante entera específica a los elementos de enumeración:

```csharp
public enum DaysInWeek
{
    Monday=1,
    Tuesday,
    Wednesday,
    Thursday, Friday,
    Saturday,
    Sunday
}
```

Si lo hacemos así, `Monday` tendrá el valor 1 y todos los demás se incrementarán en uno (martes = 2, miércoles = 3…). Pero podemos asignar un valor aleatorio a cada uno de los elementos:

```csharp
public enum DaysInWeek
{
    Monday=10,
    Tuesday=20,
    Wednesday=35,
    Thursday=48,
    Friday=74,
    Saturday=12,
    Sunday=154
}
```

Por supuesto, siempre es mejor asignar valores enteros con la misma progresión (1, 2, 3… o 10, 20, 30…).

## Elegir un tipo subyacente de enumeraciones

Cuando declaramos una enumeración, el compilador asigna valores enteros a todos los elementos. Pero podemos cambiar eso. Podemos proporcionar un tipo diferente justo después del nombre de una enumeración:

```csharp
public enum DaysInWeek: short
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
```

Al hacer esto, guardamos nuestra memoria porque el tipo int está ocupando más memoria que el corto, y no necesitamos para nuestro ejemplo, una mayor capacidad del tipo de datos corto.

## Conclusión

En este artículo, hemos aprendido:

- ¿Qué es la enumeración y cómo crear una?
- Cómo trabajar con valores literales en enumeraciones

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com