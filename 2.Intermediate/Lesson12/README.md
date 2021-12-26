# Lista genérica y diccionario

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Lista <T>

Una `List<T>` representa una colección de objetos fuertemente tipados a los que se puede acceder por índice.

Para crear una instancia `List<T>`, necesitamos proporcionar un tipo entre los corchetes angulares:

```csharp
List<int> numberList = new List<int>();
List<Student> students = new List<Student>();
```

Tiene dos constructores más que podemos usar para inicializar un objeto List. Con el primero, podemos configurar la capacidad inicial:

```csharp
List<int> numbers = new List<int>(2);
```

Con el segundo, podemos completar nuestra lista con la colección `IEnumerable`:

```csharp
int[] nums = new int[5] { 1, 2, 3, 4, 5 };
List<int> numbers = new List<int>(nums);
```

Para acceder a cualquier elemento podemos especificar su posición de índice:

```csharp
int number = numbers[1];
```

## Métodos y propiedades

El método `Add` agrega el elemento dentro de una lista:

```csharp
List<int> numbers = new List<int>();
numbers.Add(34);
numbers.Add(58);
numbers.Add(69);

foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

`AddRange` agrega los elementos de la colección especificada al final de una lista:

```csharp
List<int> numbers = new List<int>();
numbers.Add(34);
numbers.Add(58);
numbers.Add(69);

int[] nums = new int[] { 1, 22, 44 };

numbers.AddRange(nums);

foreach (int number in numbers)
{
     Console.WriteLine(number);
}
```

`Contains` determina si un elemento existe en la lista:

```csharp
if(numbers.Contains(34))
{
     Console.WriteLine("The number 34 exists in a list");
}
```

El método `IndexOf` devuelve la posición de un elemento como un número entero. Si no se pudo encontrar un elemento, este método devuelve -1:

```csharp
int index;
if((index = numbers.IndexOf(58)) != -1)
{
    Console.WriteLine($"The number 58 is on the index: {index}");
}
```

`LastIndexOf` es similar a un método anterior, excepto que devuelve una última aparición del elemento.

El método `CopyTo` copia toda la colección en una matriz compatible, comenzando desde el principio de esa matriz:

```csharp
int[] copyArray = new int[6];

numbers.CopyTo(copyArray);

foreach (int copyNumber in copyArray)
{
     Console.WriteLine(copyNumber);
}
```

El método `Remove` elimina la primera aparición de un elemento específico de la lista:

```csharp
numbers.Remove(69);
```

El método `Clear` borra todos los elementos de una lista:

```csharp
numbers.Clear();
```

Podemos verificar cuántos elementos tiene una lista usando la propiedad `Count`:

```csharp
Console.WriteLine(numbers.Count);
```

## Diccionario

`Dictionary` representa una colección de claves y valores. Para instanciar un objeto podemos usar la siguiente sintaxis:

```csharp
Dictionary<KeyType, ValueType> Name = new Dictionary<KeyType, ValueType>();
```

`KeyType` representa un tipo de nuestra clave en una colección. `ValueType` representa el valor asignado a la clave. Entonces, podemos extraer nuestro valor de una colección usando la clave dentro de los corchetes:

```csharp
DictionaryName[key];
```

Dictionary tiene varios constructores que podemos usar para crear instancias de objetos:

```csharp
Dictionary<string, int> dictExample = new Dictionary<string, int>();

Dictionary<string, int> dictExample1 = new Dictionary<string, int>(5); //to set initial size

Dictionary<string, int> dictExample2 = new Dictionary<string, int>(dictExample1); //accepts all the elements from created Key-Value collection
```

## Métodos y propiedades

El método `Add` agrega el par clave-valor dentro de una colección:

```csharp
Dictionary<string, int> dictExample = new Dictionary<string, int>();

dictExample.Add("First", 100);
dictExample.Add("Second", 200);
dictExample.Add("Third", 300);

foreach (var item in dictExample)
{
     Console.WriteLine(dictExample[item.Key]);
}
```

`Remove` elimina el par clave-valor de una colección en función de la clave especificada:

```csharp
dictExample.Remove("Second");
foreach (var item in dictExample)
{
     Console.WriteLine(dictExample[item.Key]);
}
```

`ContainsKey` determina si una colección contiene una clave específica.

`ContainsValue` determina si una colección contiene un valor específico:

```csharp
if(dictExample.ContainsKey("First"))
{
     Console.WriteLine("It contains key");
}

if(dictExample.ContainsValue(300))
{
      Console.WriteLine("It contains value");
}
```

El método `Clear` elimina todos los pares clave-valor de una colección:

```csharp
dictExample.Clear();
```

Si queremos contar todos nuestros elementos dentro de una colección, podemos usar la propiedad `Count`. Si queremos obtener una colección de contener `Keys` o contener `Values` de un diccionario, podemos usar las propiedades `Keys` y `Values`:

```csharp
Console.WriteLine(dictExample.Count);

foreach (var key in dictExample.Keys)
{
     Console.WriteLine(key);
}

foreach (var value in dictExample.Values)
{
     Console.WriteLine(value);
}
```

## Conclusión

En este artículo, hemos aprendido:

- Para usar la colección List <T> con sus métodos
- Para usar un diccionario con sus métodos y propiedades

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com