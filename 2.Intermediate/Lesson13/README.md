# Delegados

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Sintaxis de delegado

Una sintaxis básica para crear un objeto delegado es:

```csharp
delegate Result_Type identifier([parameters]);
```

Hay tres pasos para definir y usar delegados:

- Declaración de nuestro delegado
- Creación de instancias, creación del objeto del delegado
- Invocación, donde llamamos a un método referenciado

```csharp
//Declaration
public delegate void WriterDelegate(string text);
class Program
{
    public static void Write(string text)
    {
        Console.WriteLine(text);
    }

    static void Main(string[] args)
    {
        //Instantiation
        WriterDelegate writerDelegate = new WriterDelegate(Write);

        //Invocation
        writerDelegate("Some example text.");
    }
}
```

Es importante comprender que el tipo de retorno de un método y el número de parámetros deben coincidir con el tipo de retorno del delegado y el número de parámetros. De lo contrario, obtendremos un error del compilador. Podemos ver en nuestro ejemplo que nuestro método `Write` tiene un vacío como tipo de retorno y solo un parámetro de cadena, así como nuestro delegado.

Los delegados son muy útiles para encapsular nuestros métodos.

C # tiene los dos delegados integrados: `Func<T>` y `Action<T>`, son ampliamente utilizados, así que hablemos más sobre ellos.

## Delegado Func <T>

Este delegado encapsula un método que tiene hasta dieciséis parámetros y devuelve un valor del tipo especificado. Entonces, en otras palabras, usamos el delegado `Func` solo con un método que tiene un tipo de retorno distinto de void.

Podemos instanciar el delegado `Func` con esta sintaxis:

```csharp
Func<Type1, Type2..., ReturnType> DelegateName = new Func<Type1, Type2..., ReturnType>(MethodName);
```

Podemos ver que el último parámetro entre corchetes es un tipo de retorno. Por supuesto, no tenemos que inicializar un objeto delegado como este, podemos hacerlo de otra manera:

```csharp
Func< Type1, Type2..., ReturnType> name = MethodName;
```

Veamos cómo usar delegate `Func` con un ejemplo:

```csharp
class Program
{
    public static int Sum(int a, int b)
    {
        return a + b;
    }

    static void Main(string[] args)
    {
        Func<int, int, int> sumDelegate = Sum;
        Console.WriteLine(sumDelegate(10, 20));
    }
}
```

## Delegado Acción <T> 

Este delegado encapsula un método que tiene hasta dieciséis parámetros y no devuelve ningún resultado. Entonces podemos asignar a este delegado solo métodos con el tipo de retorno void.

Podemos instanciar el objeto `Action` con esta sintaxis:

```csharp
Action<Type1, Type2...> DelegateName = new Action<Type1, Type2...>(MethodName);
```

O podemos usar otra forma:

```csharp
Action < Type1, Type2...> DelegateName = MethodName;
```

Veamos cómo usar delegate `Action` con un ejemplo:

```csharp
public static void Write(string text)
{
    Console.WriteLine(text);
}

static void Main(string[] args)
{
    Action<string> writeDelegate = Write;
    writeDelegate("String parameter to write.");
}
```

## Ejemplo practico

En este ejemplo, vamos a crear una aplicación que ejecuta uno de tres métodos (Sumar, Restar, Multiplicar) basado en un solo parámetro proporcionado. Básicamente, si enviamos `Sum` como parámetro, se ejecutará el método `Sum`, y así sucesivamente. Primero, escribiremos este ejemplo sin delegados y luego refactorizaremos ese código introduciendo delegados.

Así que comencemos con la primera parte:

```csharp
public enum Operation
{
    Sum,
    Subtract,
    Multiply
}

public class OperationManager
{
    private int _first;
    private int _second;
    public OperationManager(int first, int second)
    {
        _first = first;
        _second = second;
    }

    private int Sum()
    {
        return _first + _second;
    }

    private int Subtract()
    {
        return _first - _second;
    }

    private int Multiply()
    {
        return _first * _second;
    }

    public int Execute(Operation operation)
    {
        switch (operation)
        {
            case Operation.Sum:
                return Sum();
            case Operation.Subtract:
                return Subtract();
            case Operation.Multiply:
                return Multiply();
            default:
                return -1; //just to simulate
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var opManager = new OperationManager(20, 10);
        var result = opManager.Execute(Operation.Sum);
        Console.WriteLine($"The result of the operation is {result}");

        Console.ReadKey();
    }
}
```

Si iniciamos esta aplicación, obtendremos la respuesta correcta para cualquier operación que enviemos al método `Execute`. Pero este código podría ser mucho mejor y más fácil de leer sin expresión `switch-case`. Si vamos a tener más de diez operaciones (por ejemplo), este bloque `switch` también sería muy feo de leer y mantener.

Entonces, cambiemos nuestro código para que sea legible, mantenible y más orientado a objetos. Presentamos una nueva clase `ExecutionManager`:

```csharp
public class ExecutionManager
{
    public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
    private Func<int> _sum;
    private Func<int> _subtract;
    private Func<int> _multiply;

    public ExecutionManager()
    {
        FuncExecute = new Dictionary<Operation, Func<int>>(3);
    }

    public void PopulateFunctions(Func<int> Sum, Func<int> Subtract, Func<int> Multiply)
    {
        _sum = Sum;
        _subtract = Subtract;
        _multiply = Multiply;
    }

    public void PrepareExecution()
    {
        FuncExecute.Add(Operation.Sum, _sum);
        FuncExecute.Add(Operation.Subtract, _subtract);
        FuncExecute.Add(Operation.Multiply, _multiply);
    }
}
```

Aquí, creamos un diccionario que contendrá todas las operaciones y todas las referencias hacia nuestros métodos (delegados Func). Ahora podemos inyectar esta clase en la clase `OperationManager` y cambiar el método `Execute`:

```csharp
public class OperationManager
{
    private int _first;
    private int _second;
    private readonly ExecutionManager _executionManager;

    public OperationManager(int first, int second, ExecutionManager executionManager)
    {
        _first = first;
        _second = second;
        _executionManager = executionManager;
        _executionManager.PopulateFunctions(Sum, Subtract, Multiply);
        _executionManager.PrepareExecution();
    }

    private int Sum()
    {
        return _first + _second;
    }

    private int Subtract()
    {
        return _first - _second;
    }

    private int Multiply()
    {
        return _first * _second;
    }

    public int Execute(Operation operation)
    {
        return _executionManager.FuncExecute.ContainsKey(operation) ?
            _executionManager.FuncExecute[operation]() :
            -1;
    }
}
```

Ahora, estamos configurando todo en el constructor de la clase `OperationManager` y ejecutando nuestra acción en el método `Execute` si contiene la operación requerida. A primera vista, podemos ver cuánto mejor es este código.

Finalmente, necesitamos cambiar la clase `Program`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var executionManager = new ExecutionManager();
        var opManager = new OperationManager(20, 10, executionManager);
        var result = opManager.Execute(Operation.Sum);
        Console.WriteLine($"The result of the operation is {result}");

        Console.ReadKey();
    }
}
```

## Conclusión

En este artículo, hemos aprendido:

- Cómo crear una instancia de un delegado
- La forma de utilizar los delegados de Func y Action
- Cómo escribir un código mejor usando delegados

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com