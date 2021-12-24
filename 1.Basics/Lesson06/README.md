# Trabajar con cadenas en `C#`: métodos de cadena

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Métodos de cadena Substring, IndexOf, LastIndexOf en `C#`

Substring (int startIndex) es el método que devuelve parte de la cadena desde `startIndex` el final de la cadena.

Substring (int startIndex, int length) es el método que devuelve parte de la cadena con una longitud definida de `startIndex`.

Veamos esto en la práctica:

```csharp
class Program
{
    static void Main(string[] args)
    {
        string testString = "this is some string to use it for our example.";

        string partWithoutLength = testString.Substring(10);
        string partWithLength = testString.Substring(5, 10);

        Console.WriteLine(partWithoutLength);
        Console.WriteLine(partWithLength);

        Console.ReadKey();
    }
}
```

IndexOf () es el método que devuelve la posición del valor entero de la primera aparición del carácter, o una cadena en la cadena seleccionada. Si ese valor no existe, el método devolverá -1.

Hay diferentes sobrecargas de este método: `IndexOf(char value)`, `IndexOf(string value)`, `IndexOf(char value, int startIndex)`, `IndexOf(string value, int startIndex)` etc. Si utilizamos este método con el startIndexparámetro, no vamos a buscar desde el principio de la cadena, pero desde esa posición hasta el final:

```csharp
int charPosition = testString.IndexOf('i');
int stringPosition = testString.IndexOf("some");
int charPosWithStartIndex = testString.IndexOf('s', 10);
int stringPosWithStartIndex = testString.IndexOf("some", 10);
```

`LastIndexOf()` es el método que devuelve la posición de la última aparición de un carácter o un valor de cadena. Este método tiene las mismas sobrecargas que el `IndexOf` método:

```csharp
int lastPosition = testString.LastIndexOf('o');
int stringLastPosition = testString.LastIndexOf("is");
```

## Contiene, comienza con, termina con

Contiene (valor de cadena) es el método que devuelve verdadero si una cadena contiene el valor; de lo contrario, devolverá falso:

StartsWith (valor de cadena) es el método que devuelve verdadero si una cadena comienza con el valor; de lo contrario, devuelve falso. A diferencia de este método, el método EndsWith (valor de cadena) devuelve verdadero si una cadena termina con el valor; de lo contrario, devuelve falso:

## Quitar, insertar

El método `Remove(int startIndex)` elimina los caracteres de la cadena desde la `startIndex` posición hasta el final de la cadena y devuelve esa nueva cadena. Hay un método sobrecargado `Remove(int startIndex, int count) que elimina un número específico de caracteres de la cadena desde la posición del índice inicial. Con el parámetro de conteo decidimos cuántos caracteres queremos eliminar:

```csharp
string loweredString = testString.Remove(10);
string loweredStringWithCount = testString.Remove(10, 9);
```

`Insert(int startIndex, string value)` es el método que inserta el valor en la cadena desde la `startIndex` posición y devuelve una cadena modificada:

```csharp
string stringWithInsert = testString.Insert(13, "UPDATED ");
```

## ToLower, ToUpper

`ToLower()` devuelve una nueva cadena con todas las letras minúsculas:

```csharp
string upperCaseString = testString.ToUpper();
```

## Ejemplos de uso de métodos de cadena en `C#`

Ejemplo 1: Cree una aplicación que acepte el nombre y el apellido, separados por espacios, como entrada, y luego imprima el nombre en una fila y el apellido en otra fila:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your full name, blank space separated");
        string fullName = Console.ReadLine();

        int blankPosition = fullName.IndexOf(' ');
        string name = fullName.Substring(0, blankPosition);
        string lastName = fullName.Substring(blankPosition + 1);

        Console.WriteLine(name);
        Console.WriteLine(lastName);

        Console.ReadKey();
    }
}
```

Ejemplo 2: Cree una aplicación que acepte como entrada una oración y elimine la primera y la última palabra de esa oración:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your sentence: ");

        string sentence = Console.ReadLine();

        int firstBlankPosition = sentence.IndexOf(' ');
            
        string withoutFirstWord = sentence.Remove(0, firstBlankPosition + 1);

        int lastBlankPosition = withoutFirstWord.LastIndexOf(' ');

        string withoutFirstAndLast = withoutFirstWord.Remove(lastBlankPosition);

        Console.WriteLine(withoutFirstAndLast);

        Console.ReadKey();
    }
}
```

Este es el resultado:

```bash
Enter your sentence:
This is a new sentence with several words.
is a new sentence with several
```

## Conclusión

Hemos dominado el uso de los métodos de cadena más utilizados en C #. Con la combinación de estos métodos, podemos crear soluciones poderosas para nuestras aplicaciones.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com