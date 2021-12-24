# Archivos, StreamWriter y StreamReader en `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Creación de objetos para StreamWriter y StreamReader

Para crear objetos para las clases `StreamReader` y `StreamWriter`, necesitamos usar la inicialización estándar para los tipos de datos de referencia. Podemos ejecutar esta inicialización de varias formas, pero la más común es solo proporcionando una dirección al archivo:

```csharp
StreamReader readerRelativePath = new StreamReader("test.txt");
StreamReader readerAbsolutePath = new StreamReader("C:\\MyProject\\test.txt");
StreamWriter writerRelativePath = new StreamWriter("test.txt");
StreamWriter writerAbsolutePath = new StreamWriter("C:\\MyProject\\test.txt");
```

Como podemos ver en el código anterior, podemos proporcionar la ruta relativa o absoluta a nuestro archivo. Si proporcionamos una ruta relativa (solo un nombre y una extensión), Visual Studio colocará un archivo dentro de la carpeta projectName / bin / debug.

## Métodos StreamReader

StreamReader contiene muchos métodos diferentes para trabajar con archivos, pero vamos a mencionar algunos de ellos.

El método `Read()` devolverá el siguiente signo como un número entero o -1 si llegamos al final del archivo. Podemos usar conversión explícita (conversión) para convertir ese entero en un tipo `char`:

```csharp
static void Main(string[] args)
{
    StreamReader sr = new StreamReader("test.txt");

    int x;
    char ch;

    x = sr.Read();
            
    while(x != -1)
    {
        ch = (char)x;
        //do stuff here
        x = sr.Read();
    }
}
```

El método `ReadLine()` devolverá una línea completa como una cadena. Si llegamos al final del archivo, devolverá nulo:

```csharp
static void Main(string[] args)
{
    StreamReader sr = new StreamReader("test.txt");

    string line = sr.ReadLine();

    while(line != null)
    {
        //some coding
        line = sr.ReadLine();
    }
}
```

El método `ReadToEnd()` devuelve un archivo completo en una cadena. Si no hay nada más para leer, devolverá una cadena vacía.

El método `Peek()` comprueba el siguiente carácter del archivo o, si no encuentra nada, devolverá -1:

```csharp
static void Main(string[] args)
{
    StreamReader sr = new StreamReader("test.txt");
    string line;

    while(sr.Peek() != -1)
    {
        line = sr.ReadLine();
        //some coding
    }
}
```

## Métodos StreamWriter

Los dos métodos más importantes para la clase StreamWriter son `Write()` y `WriteLine()`. Con el método `Write()` escribimos una línea dentro de un archivo pero sin pasar a otra línea después. Pero con el método `WriteLine()`  escribimos una línea dentro de un archivo y pasamos a otra línea.

Es muy importante llamar al método `Close()`, una vez que hayamos terminado con el uso de objetos de lectura o escritura.

Ejemplo 1: Cree una aplicación que escriba cinco números aleatorios del 1 al 100 en un archivo llamado numbers.txt. Luego leerá todos los números de ese archivo, los imprimirá e imprimirá el número máximo:

```csharp
class Program
{
    public static void WriteToFile(string path)
    {
        StreamWriter sw = new StreamWriter(path);
        Random r = new Random(); //class to generate random numbers
        for(int i = 1; i <= 5; i++)
        {
            sw.WriteLine(r.Next(1,101));
        }

        sw.Close();
    }

    public static void PrintNumbersAndMax(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line = sr.ReadLine();
        Console.WriteLine(line);
        int max = Convert.ToInt32(line);

        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);

            int temp = Convert.ToInt32(line);
            if(temp > max)
            {
                max = temp;
            }
        }
     
        sr.Close();

        Console.WriteLine($"Max number is: {max}");
    }

    static void Main(string[] args)
    {
        WriteToFile("numbers.txt");

        PrintNumbersAndMax("numbers.txt");

        Console.ReadLine();
   }
}
```

Como podemos ver, tenemos que usar el método `Close` para cerrar nuestro lector y escritor. Pero hay una forma aún mejor de hacer esto. Usando el bloque` using`.

## Usando Block

El bloque `using` ayuda a gestionar nuestros recursos. Especifica un alcance en el que usamos nuestro recurso, y una vez que dejamos ese alcance, el recurso será administrado.

Para usar el bloque `using` necesitamos especificar la palabra clave `using`, crear recursos entre paréntesis y declarar el alcance del usingbloque con las llaves:

```csharp
using (Resource creation)
{

}
```

Entonces, podemos reescribir uno de nuestros métodos del ejemplo anterior:

```csharp
public static void PrintNumbersAndMax(string path)
{
    using (StreamReader sr = new StreamReader(path))
    {
        string line = sr.ReadLine();
        Console.WriteLine(line);
        int max = Convert.ToInt32(line);

        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);

            int temp = Convert.ToInt32(line);
            if (temp > max)
            {
                 max = temp;
            }
        }

        Console.WriteLine($"Max number is: {max}");
    }
}
```

En este ejemplo, no estamos usando el método `Close` porque tan pronto como la ejecución abandone el cuerpo de la declaración `using` , el `StreamReaderobjeto` será administrado.

## Conclusión

Aquí vamos. En este momento, tenemos un buen conocimiento para manipular archivos de C #.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com