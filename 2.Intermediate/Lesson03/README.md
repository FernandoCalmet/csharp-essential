# Miembros estáticos, constantes y métodos de extensión

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Acerca de los métodos estáticos

Cuando definimos un método en una clase, pertenece a esa clase y todas las instancias de esa clase podrán acceder a él. Una clase puede tener muchos de estos métodos. Pero hay algunos métodos que son independientes de la instancia de clase específica. Ese tipo de métodos se denominan "métodos estáticos". Entonces, los métodos estáticos son los métodos que no pertenecen a una instancia de una clase, pueden interactuar solo con otros elementos estáticos y tienen la palabra clave estática en la descripción del método.

Tomemos el método `Sqrt()`, por ejemplo. Este método calcula la raíz cuadrada de un número, y no tenemos que instanciar la clase `Math` (a la que pertenece el Sqrt) porque este método es un método estático:

```csharp
int number = 4;
Console.WriteLine(Math.Sqrt(number));
```

Entonces, ¿por qué el método `Sqrt` es un método estático y no no-estático?

Bueno, `Sqrt` acepta solo un argumento y es suficiente para hacer su trabajo. Proporcionamos un número de argumento y el método devuelve una raíz cuadrada de ese número. No mencionamos la clase `Math` en absoluto. Eso es porque no tenemos que hacerlo. La clase `Math` no proporciona ningún apoyo al método `Sqrt` para que haga su trabajo. Solo proporciona un espacio para que resida el método `Sqrt`.

Cuando tenemos un caso como este, suele ser una buena solución crear un método como uno estático.

## Trabajar con un método estático

Para llamar a un método estático, como dijimos, no necesitamos una instancia de una clase. Podemos llamarlo con la siguiente sintaxis: `ClassName.MethodName(arguments…);`

Entonces, cuando queremos usar el método `Sqrt` o cualquier otro método de la clase `Math`, podemos llamarlo así: `Math.Sqrt(16);`

## Creación de un campo mediante la palabra clave constante

Si prefijamos nuestro campo con la palabra clave const, podemos declarar dicho campo donde su valor nunca puede cambiar. La palabra clave `const` es la abreviatura de constante. Un miembro constante se define en tiempo de compilación y no se puede modificar en tiempo de ejecución.

Podemos crear una variable constante de la siguiente manera: `AccessModifier const Type Name = Value;`

![img01](/img/01.png)

## Clase estática

En C #, junto a los métodos estáticos, también podemos declarar clases estáticas. La clase estática puede contener solo los miembros estáticos. Su propósito es actuar como titular de los métodos y campos de utilidad. No tiene sentido crear instancias de este tipo de clases utilizando la palabra clave `new`. Además, no podemos hacer eso en absoluto. Pero podemos crear un constructor predeterminado siempre que sea estático. Cualquier otro tipo de constructor es ilegal:

```csharp
public static class TestClass
{
    private static int number;

    static TestClass()
    {
        number = 54;
    }
 }
```

## Acerca de los métodos de extensión y cómo usarlos

Supongamos que queremos agregar una nueva característica al tipo `string`, por ejemplo, la funcionalidad `FirstLetterUpperCase` que siempre hace que la primera letra de una cadena esté en mayúsculas. Podemos escribir un método normal para ese propósito:

```csharp
public static string FirstLetterUpperCase(string word)
{
     char letter = Char.ToUpper(word[0]);
     string remaining = word.Substring(1);

     return letter + remaining;
}

static void Main(string[] args)
{
     string word = "football";
     string newWord = FirstLetterUpperCase(word);
}
```

Pero, como podemos ver, necesitamos enviar una palabra como parámetro cada vez y aceptar el valor devuelto cada vez también. Este no es el enfoque equivocado, pero podemos hacerlo aún mejor. Ahí es donde entran los métodos de extensión.

Un método de extensión nos permite extender un tipo existente con métodos estáticos adicionales. Debemos crear ese tipo de métodos dentro de una clase estática y tienen el primer parámetro prefijado con la palabra clave `this`.

Pero, ¿por qué tenemos que colocar un prefijo delante del primer parámetro?

Porque ese parámetro es un indicador que le dice al compilador qué tipo extendemos.

Así que aquí está el ejemplo anterior pero con el método de extensión:

```csharp
public static class StringExtensions
{
    public static string FirstLetterUpperCase(this string word)
    {
        char letter = Char.ToUpper(word[0]);
        string remaining = word.Substring(1);

        return letter + remaining;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string word = "football"
                      .FirstLetterUpperCase();

        Console.WriteLine(word);
        Console.ReadKey();
    }
}
```

## Conclusión

Hemos terminado con los miembros estáticos y ahora tenemos una gran herramienta en nuestra caja de herramientas que podemos usar mientras desarrollamos nuestras aplicaciones C #.

En este artículo, hemos aprendido:

- Cómo usar clases estáticas
- La forma de usar métodos estáticos.
- Cómo crear métodos de extensión
- Acerca de las palabras clave const y la creación de constantes

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com