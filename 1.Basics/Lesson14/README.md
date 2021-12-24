# Matrices en `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Declaración e inicialización de matrices

Para declarar una matriz, indicamos el tipo de esa matriz, luego los corchetes y finalmente el nombre de esa matriz:

```csharp
int[] numbers;
Pen[] pens;
```

Lo importante que debe saber es que no importa si almacenamos el tipo de referencia o los datos del tipo de valor dentro de una matriz, la matriz es siempre un tipo de datos de referencia.
Para inicializar nuestras matrices, necesitamos usar una palabra clave `new`, luego el tipo de datos y finalmente los corchetes con la capacidad de la matriz dentro:

```csharp
numbers = new int[5];
pens = new Pen[5];
```

En un primer ejemplo, almacenamos el tipo `int` (tipo de valor) dentro de la matriz de números, reservando así el espacio en nuestra memoria para cinco enteros. Pero en el segundo ejemplo, estamos reservando el espacio en nuestra memoria para cinco `Pen` tipos (tipos de referencia) por lo que no estamos almacenando sus valores sino sus referencias. Todos los `Pen` valores son nulos por ahora.
Hasta ahora, solo hemos asignado la memoria para nuestros valores, en realidad no agregamos esos valores en absoluto. Entonces, para finalizar el proceso de inicialización, necesitamos agregar valores a nuestras matrices. La forma más común es declarar, asignar e inicializar una matriz en una línea de código:

```csharp
int[] arrayExample = new int[5] { 4, 5, 7, 8, 3};
Pen[] penArrayExample = new Pen[3] { new Pen(Color.Red), new Pen(Color.Green), new Pen(Color.Blue) };
```

También podemos usar los índices para completar una matriz:

```csharp
int[] numbers = new int[2];
numbers[0] = 5; numbers[1] = 7;
```

## Manipulación de matrices

Para manipular con una matriz, podemos usar un bucle `for`. Con un bucle for estamos usando índices para acceder a cada elemento de una matriz:

```csharp
static void Main(string[] args)
{
    int[] numbers = new int[5] { 4, 5, 7, 8, 3};
           
    for(int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine(numbers[i]);
    }
}
```

Podemos hacer lo mismo pero con el bucle `foreach`. La diferencia entre estos dos enfoques se debe a que con el ciclo `for` estamos usando índices para acceder a elementos (variable i), pero con el ciclo `foreach` no estamos usando índices sino los valores reales:

```csharp
static void Main(string[] args)
{
    int[] numbers = new int[5] { 4, 5, 7, 8, 3};

    foreach(int i in numbers)
    {
        Console.WriteLine(i);
    }
}
```

## Ejemplos

Ejemplo 1: Cree una aplicación en la que creamos una matriz de nelementos, completamos esa matriz con números enteros aleatorios y finalmente imprimimos todos esos números y su suma:

```csharp
class Program
{
    //array is a reference type so every action in this method will affect original array
    public static void PopulateArray(int[] numbers)
    {
        Random r = new Random();
        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = r.Next(1, 101);
            Console.WriteLine($"The {i+1}. element is {numbers[i]}");
        }
    }

    public static void CalculateSum(int[] numbers)
    {
        int sum = 0;
        foreach (int i in numbers)
        {
            sum += i;
        }

        Console.WriteLine($"The sum of all the elements is {sum}");
    }

     static void Main(string[] args)
    {
        Console.WriteLine("Enter an array capacity: ");
        int capacity = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[capacity];

        PopulateArray(numbers);
        Console.WriteLine();
        CalculateSum(numbers);

        Console.ReadKey();
    }
}
```

## Matrices de parámetros

Una matriz params nos permite pasar un número variable de argumentos a un método. Para crear una matriz de params debemos especificar la palabra clave `params` cuando especificamos los parámetros para nuestro método:

```csharp
public static void TestMethod(params int[] numbers)
{
    //method body    
}
```

El efecto de la palabra clave `params` es que nos permite enviar cualquier número de argumentos al parámetro del método sin crear una matriz:

```csharp
static void Main(string[] args)
{
   TestMethod(1, 2, 3);
}
```

Aunque una matriz de params es muy útil, todavía tenemos algunas limitaciones al trabajar con ellos:

- No podemos usar la palabra clave params para trabajar con matrices bidimensionales
- La sobrecarga de métodos no es posible únicamente con la palabra clave params
- No podemos especificar palabras clave ref o out con matrices params
- Una matriz de params tiene que ser el último parámetro de nuestro método
- Un método que no es params siempre tiene prioridad sobre los métodos params

Ejemplo 2: Cree una aplicación que imprima el mínimo de todos los números enviados al método PrintMin:

```csharp
class Program
{
    public static void PrintMin(params int[] numbers)
    {
        int min = numbers[0];
        for(int i=1; i < numbers.Length; i++)
        {
            if(min > numbers[i])
            {
                min = numbers[i];
            }
        }

        Console.WriteLine(min);
    }
    static void Main(string[] args)
    {
        PrintMin(49, 58, 12, 98, 47, 13);

        Console.ReadKey();
    }
}
```

## Matriz multidimensional

Sabemos cómo utilizar matrices unidimensionales, pero C # también admite matrices multidimensionales. En esta sección, hablaremos de matrices bidimensionales. ¿Por qué se llaman bidimensionales?

Bueno, porque tienen dos dimensiones, filas y columnas. Para crear una matriz "2d", usamos la siguiente sintaxis:

```csharp
int[,] numbersMultiDim = new int[3, 2] { { 1, 5 }, { 3, 8 }, { 6, 1 } };
```

Con esta sintaxis, creamos una matriz bidimensional con tres filas y dos columnas. Entonces, en una presentación gráfica debería verse así:

![img01](/img/01.png)

Para acceder a cualquier número de esta matriz podemos utilizar la sintaxis con el nombre de la matriz y la posición del número entre corchetes. Proporcionamos posición mediante índices. Entonces, la primera fila tiene el índice 0 y la última tiene el índice (número de filas - 1). Lo mismo ocurre con las columnas:

```csharp
int number = numbersMultiDim[2, 1]; // value 1    => third row on index 2 and second column on index 1
```

Para iterar a través de todos los datos, podemos usar el ciclo for:

```csharp
for(int i = 0; i < numbersMultiDim.GetLength(0); i++)
{
      for(int j = 0; j < numbersMultiDim.GetLength(1); j++)
      {
          Console.WriteLine(numbersMultiDim[i,j]);
      }
}
```

Como puede ver, estamos usando dos bucles para iterar a través de una matriz bidimensional. El primero es iterar a través de todas las filas y el segundo a través de todas las columnas de la fila actual.
Usamos matrices multidimensionales cuando tenemos que presentar nuestros datos en forma multidimensional. Específicamente, utilizamos matrices bidimensionales para trabajar con los datos en forma de tabla con las filas y columnas.

## Conclusión

Gran trabajo. Contamos con todos los conocimientos necesarios para trabajar con arrays y utilizarlos en nuestro proceso de desarrollo.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com