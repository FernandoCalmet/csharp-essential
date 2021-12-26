# Cola, pila, tabla hash

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Colección de cola

La colección `queue` representa una colección de objetos primero en entrar, primero en salir. Esto significa que podemos colocar nuestros objetos en una colección de cola en un orden determinado y eliminar esos objetos en el mismo orden. Entonces, el primer objeto que entra es el primer objeto que sale.

Para crear una instancia de objeto de una colección `queue`, podemos usar dos declaraciones diferentes.

Usando el espacio de nombres `System.Collection.Generic`:

```csharp
Queue<int> intCollection = new Queue<int>();
```

Y al usar el espacio de nombres `System.Collection`:

```csharp
Queue queueCollection = new Queue();
```

Si declaramos un objeto proporcionando un tipo (en nuestro ejemplo, un int), podemos almacenar solo números enteros en su interior. Por otro lado, si usamos el segundo ejemplo podemos almacenar diferentes tipos de datos en una colección porque almacena objetos.

## Los métodos y propiedades más comunes

El Enqueuemétodo agrega un elemento dentro de una colección:

```csharp
Queue queueCollection = new Queue();
queueCollection.Enqueue(54);
queueCollection.Enqueue("John");
queueCollection.Enqueue(54.10);

foreach (var item in queueCollection)
{
      Console.WriteLine(item);
}
```

Cuando queremos eliminar un elemento al principio de la colección y devolverlo, vamos a utilizar el método `Dequeue`:

```csharp
Queue queueCollection1 = new Queue();
queueCollection1.Enqueue(54);
queueCollection1.Enqueue("John");
queueCollection1.Enqueue(54.10);

int number = Convert.ToInt32(queueCollection1.Dequeue());
Console.WriteLine($"Removed element is: {number}");
Console.WriteLine();

foreach (var item in queueCollection1)
{
    Console.WriteLine(item);
}
```

El método `Peek` devuelve el elemento al principio de la colección pero no lo elimina:

```csharp
Queue queueCollection2 = new Queue();
queueCollection2.Enqueue(54);
queueCollection2.Enqueue("John");
queueCollection2.Enqueue(54.10);
            
int peekNumber = Convert.ToInt32(queueCollection2.Peek());
Console.WriteLine($"Returned element is: {number}");
Console.WriteLine();

foreach (var item in queueCollection2)
{
    Console.WriteLine(item);
}
```

El método `Clear` elimina todos los elementos de una colección.

Si queremos comprobar cuántos elementos tenemos dentro de una colección, podemos usar la propiedad `Count`:

```csharp
queueCollection2.Clear();
Console.WriteLine(queueCollection2.Count);
```

## Colección Stack

Una colección `stack`representa una colección simple de último en entrar, primero en salir. Significa que un elemento que entre primero en una colección saldrá en último lugar.

Al igual que con una colección `Queue`, podemos usar los espacios de nombres `System.Collection` y `System.Collection.Generic`:

```csharp
Stack stack = new Stack();
Stack<int> stackInt = new Stack<int>();
```

## Propiedades y métodos relacionados

El método `Push` inserta un objeto en la parte superior de la colección:

```csharp
Stack stack1 = new Stack();
stack1.Push(328);
stack1.Push("Fifty Five");
stack1.Push(124.87);

foreach (var item in stackCollection1)
{
    Console.WriteLine(item);
}
```

`Pop` elimina el elemento que se incluyó en último lugar en una colección y lo devuelve:

```csharp
Stack stackCollection2 = new Stack();
stackCollection2.Push(328);
stackCollection2.Push("Fifty Five");
stackCollection2.Push(124.87);

double number = Convert.ToDouble(stackCollection2.Pop());
Console.WriteLine($"Element removed from a collection is: {number}");

foreach (var item in stackCollection2)
{
    Console.WriteLine(item);
}
```

`Peek` devuelve un objeto listo para salir de la colección, pero no lo elimina:

```csharp
Stack stackCollection3 = new Stack();
stackCollection3.Push(328);
stackCollection3.Push("Fifty Five");
stackCollection3.Push(124.87);

double number1 = Convert.ToDouble(stackCollection3.Peek());
Console.WriteLine($"Element returned from a collection is: {number}");

foreach (var item in stackCollection3)
{
    Console.WriteLine(item);
}
```

Para eliminar todos los objetos de una colección, usamos el método `Clear`.

Si queremos contar el número de elementos, usamos la propiedad `Count`:

```csharp
stackCollection3.Clear();
Console.WriteLine(stackCollection3.Count);
```

## Hash Table

Hashtable representa una colección de un par clave-valor que se organiza en función del código hash de la clave. De manera diferente, de las colecciones de cola y pila, podemos instanciar un objeto de tabla hash usando el único sespacio de nombres `System.Collection` :

```csharp
Hashtable hashTable = new Hashtable();
```

El constructor de Hashtable tiene quince constructores sobrecargados.

## Métodos comunes en la colección Hashtable

El método `Add` agrega un elemento con la clave y el valor especificados a la colección:

```csharp
Hashtable hashTable = new Hashtable();
hashTable.Add(Element.First, 174);
hashTable.Add(Element.Second, "Sixty");
hashTable.Add(Element.Third, 124.24);
foreach (var key in hashTable.Keys)
{
    Console.WriteLine($"Key: {key}, value: {hashTable[key]}");
}
```

El método `Remove` elimina el elemento con la clave especificada de una colección:

```csharp
Hashtable hashTable1 = new Hashtable();
hashTable1.Add(Element.First, 174);
hashTable1.Add(Element.Second, "Sixty");
hashTable1.Add(Element.Third, 124.24);

hashTable1.Remove(Element.Second);

foreach (var key in hashTable1.Keys)
{
    Console.WriteLine($"Key: {key}, value: {hashTable[key]}");
}
```

`ContainsKey` determina si una colección contiene una clave específica:

```csharp
if (hashTable.ContainsKey(Element.Second))
{
      Console.WriteLine($"Collection contains key: {Element.Second} and its value is {hashTable[Element.Second]}");
}
```

El método `ContainsValue` determina si una colección contiene un valor específico.

`Clear` elimina todos los elementos de una colección:

```csharp
hashTable.Clear();
```

## Propiedades comunes en la colección Hashtable

La propiedad `Count` cuenta el número de elementos dentro de una colección:

```csharp
Console.WriteLine(hashTable.Count);
```

La propiedad `Keys` devuelve todas las claves de una colección y la propiedad `Value` devuelve todos los valores de una colección:

```csharp
Hashtable hashTable2 = new Hashtable();
hashTable2.Add(Element.First, 174);
hashTable2.Add(Element.Second, "Sixty");
hashTable2.Add(Element.Third, 124.24);

var keys = hashTable2.Keys;
foreach (var key in keys)
{
     Console.WriteLine(key);
}
Console.WriteLine();

var values = hashTable2.Values;
foreach (var value in values)
{
     Console.WriteLine(value);
}
```

## Conclusión

En este artículo, hemos aprendido:

- Para usar la colección Queue con sus métodos
- Para usar la colección Stack con sus métodos
- Cómo utilizar la colección Hashtable con sus métodos

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com