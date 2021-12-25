# Génericos

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Tipo genérico T

Para crear una clase genérica, necesitamos proporcionar un tipo entre paréntesis angulares:

```csharp
public class CollectionInitializer<T>
{
    ...
}
```

`T` en este ejemplo, actúa como un marcador de posición para un tipo con el que queremos trabajar. Necesitamos proporcionar ese tipo una vez que creemos una instancia de esta clase genérica. Veamos esto con un ejemplo simple:

```csharp
public class CollectionInitializer<T>
{
    private T[] collection;

    public CollectionInitializer(int collectionLength)
    {
        collection = new T[collectionLength];
    }

    public void AddElementsToCollection(params T[]elements)
    {
        for(int i=0; i<elements.Length; i++)
        {
            collection[i] = elements[i];
        }
    }

    public T[] RetrieveAllElements()
    {
        return collection;
    }

    public T RetreiveElementOnIndex(int index)
    {
        return collection[index];
    }
}
```

Y para usar esta clase genérica:

```csharp
class Program
{
    static void Main(string[] args)
    {
        CollectionInitializer<int> initializer = new CollectionInitializer<int>(5);

        initializer.AddElementsToCollection(5, 8, 12, 74, 13);
        int[] collection = initializer.RetrieveAllElements();
        int number = initializer.RetreiveElementOnIndex(3);

        foreach (int element in collection)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine();
        Console.WriteLine($"Element on the selected index is: {number}");

        Console.ReadKey();
    }
}
```

Como podemos ver en nuestra clase `CollectionInitializer`, debemos proporcionar el tipo con el que queremos trabajar. Entonces, podemos simplemente llamar a los métodos implementados dentro de nuestra clase genérica. Por supuesto, no implementamos controles de seguridad (si enviamos más elementos que la longitud de la matriz, etc.) solo por simplicidad. Ahora podemos ver el resultado:

```bash
5
8
12
74
13

Element on the selected index is: 74
```

Una clase genérica puede tener más de un parámetro de tipo:

```csharp
public class CollectionKeyValueInitializer<TKey, TValue>
```

## Restricciones con genéricos

A veces, queremos asegurarnos de que solo se puedan invocar ciertos tipos con nuestra clase genérica. Suele ser útil al trabajar con clases o interfaces. Podemos hacer eso usando la palabra clave where:

```csharp
public class CollectionInitializer<T> where T: Student
```

o podemos limitar nuestra clase genérica para trabajar solo con clases:

```csharp
public class CollectionInitializer<T> where T: class
```

Existen diferentes variaciones para estas restricciones, dependen de la situación en la que estemos trabajando. Es importante saber que si restringimos nuestra clase genérica para trabajar solo con clases, obtendremos un error si proporcionamos el tipo de valor. Si queremos trabajar solo con tipos de valor, podemos restringir nuestra clase genérica de esta manera:

```csharp
public class CollectionInitializer<T> where T: struct
```

## Métodos genéricos

De la misma forma que podemos crear una clase genérica, podemos crear un método genérico. Solo necesitamos establecer un parámetro de tipo entre paréntesis angulares justo detrás del nombre de un método:

```csharp
public void ExampleMethod<T>(T param1, T param2)
{
    //Methods body
}
```

Debemos prestar atención al identificador del parámetro de tipo si nuestro método genérico existe dentro de una clase genérica. Si esa clase tiene un tipo T, entonces nuestro método debe tener un tipo diferente (U, Y, R…). De lo contrario, el tipo T de un método ocultará el tipo T de una clase.

## Conclusión

En este artículo, hemos aprendido:

- Cómo usar genéricos en C #
- Cómo implementar restricciones en nuestras clases genéricas
- La forma de crear métodos genéricos

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com