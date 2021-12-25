# Interfaces

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Definición de una interfaz

Para definir una interfaz, necesitamos usar la palabra clave `interface`. Es bastante similar a definir una clase, solo que usamos otra palabra clave. Dentro de esa interfaz, especificamos nuestros miembros sin modificador de acceso ni implementación. Entonces, solo proporcionamos una declaración para los miembros, una implementación es un trabajo para una clase que implementa esa interfaz:

```csharp
interface InterfaceName
{
    returnType methodName(paramType paramName...);
}
```

## Implementar una interfaz

Para implementar una interfaz, declaramos una clase o estructura que hereda de la interfaz e implementa todos los miembros de ella:

```csharp
class ClassName: InterfaceName
{
    //members implementation
}
```

Veamos todo esto a través del ejemplo:

```csharp
public interface IWriter
{
    void WriteFile();
}

public class XmlWritter: IWriter
{
    public void WriteFile()
    {
        Console.WriteLine("Writing file in the XmlWriter class.");
    }
}

public class JsonWriter: IWriter
{
    public void WriteFile()
    {
        Console.WriteLine("Writing file in the JsonWritter class.");
    }
}
```

Como podemos ver, después de que nuestras clases hereden de una interfaz, deben implementar el miembro `WriteFile()`. De lo contrario, obtendríamos un error del compilador.

Cuando implementamos una interfaz, debemos asegurarnos de proporcionar la implementación del método siguiendo estas reglas:

- Los nombres de los métodos y los tipos de retorno deben coincidir exactamente
- Cualquier parámetro debe coincidir exactamente
- Todos los métodos deben ser públicos durante la implementación. Este no es el caso con la implementación explícita de la interfaz (hablaremos de eso un poco más adelante)

Una clase puede heredar de una clase e implementar una interfaz al mismo tiempo. Pero si este es un caso, primero debemos especificar una clase base y luego una interfaz separada por comas:

```csharp
public interface IWriter
{
    void WriteFile();
}

public class FileBase
{
    public virtual void SetName()
    {
        Console.WriteLine("Setting name in the base Writer class.");
    }
}

public class XmlWritter: FileBase, IWriter
{
    public void WriteFile()
    {
        Console.WriteLine("Writing file in the XmlWriter class.");
    }

    public override void SetName()
    {
        Console.WriteLine("Setting name in the XmlWriter class.");
    }
}

public class JsonWriter: FileBase, IWriter
{
    public void WriteFile()
    {
        Console.WriteLine("Writing file in the JsonWritter class.");
    }

    public override void SetName()
    {
        Console.WriteLine("Setting name in the JsonWriter class.");
    }
}
```

## Hacer referencia a clases a través de interfaces

De la misma manera que podemos hacer referencia a un objeto usando una variable de clase, podemos definir un objeto usando una variable de interfaz:

```csharp
XmlWriter writer = new XmlWriter();
writer.SetName(); //overridden method from a base class
writer.WriteFile(); //method from an interface
```

Como podemos ver, todos los métodos están disponibles a través del objeto `writer`. Pero ahora usemos un objeto de interfaz para hacer referencia a la acción:

```csharp
IWriter writer = new XmlWriter();
writer.WriteFile(); //method from an interface
writer.SetName(); //error the SetName method is not part of the IWriter interface
```

Si usamos una interfaz para crear un objeto, podemos acceder solo a los miembros declarados en esa interfaz.
Como mencionamos anteriormente, la interfaz proporciona un contrato para la clase que hereda de ella. Y esta es una gran ventaja de usar interfaces, siempre podemos estar seguros cuando una clase hereda de nuestra interfaz implementará todos sus miembros.

Pero la implementación de la interfaz tiene aún más ventajas. Uno de ellos es el desacoplamiento de objetos.

## Usar una interfaz para desacoplar clases

Cuando una clase depende de otra clase, esas clases están acopladas. Esto es algo que queremos evitar porque si algo cambia en la clase A y la clase B depende en gran medida de la clase A, existe una gran posibilidad de que tengamos que cambiar también una clase B. O al menos, no estaremos seguros de si la Clase B aún funciona correctamente. En consecuencia, queremos que nuestras clases estén acopladas o "desacopladas" de manera flexible.

Veamos qué pasaría si creamos nuestras clases fuertemente acopladas:

```csharp
public class XmlFileWriter
{
    private XmlWriter _xmlWriter;

    public XmlFileWriter(XmlWriter xmlWriter)
    {
        _xmlWriter = xmlWriter;
    }

    public void Write()
    {
        _xmlWriter.WriteFile();
    }
}
```

Esta `XmlFileWriter` es una clase que tiene el propósito de escribir en un archivo xml. Ahora podemos crear una instancia de nuestra clase `XmlWriter`, enviar el objeto a través del constructor `XmlFileWriter` y llamar al método `Write`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        XmlWriter xmlWriter = new XmlWriter();
        XmlFileWriter fileWriter = new XmlFileWriter(xmlWriter);
        fileWriter.Write();
    }
}
```

Ok, todo funciona muy bien por ahora.

Pero tenemos un par de problemas aquí. Nuestra clase `XmlFileWriter` está fuertemente acoplada a la clase `XmlWriter`. Si cambiamos el método `WriteFile` dentro de la clase `XmlWriter`, también debemos cambiarlo en la clase `XmlFileWriter`. Entonces, el cambio en una clase conduce a un cambio en otra. No es así como queremos que funcione nuestro código.

Otra cosa. Seguramente queremos tener el mismo comportamiento para nuestra clase `JsonWriter`. No podemos usar esto `XmlFileWriter` (porque acepta solo el XmlWriterobjeto), debemos crear otra clase y repetir todas nuestras acciones. Esto también es bastante malo.

Finalmente, podemos preguntarnos, si realmente necesitamos dos clases para el mismo trabajo. ¿Por qué no podemos usar solo uno? Bueno, ahí es donde entran las interfaces.

Modifiquemos la clase `XmlFileWriter`:

```csharp
public class FileWriter
{
    private readonly IWriter _writer;

    public FileWriter(IWriter writer)
    {
        _writer = writer;
    }

    public void Write()
    {
        _writer.WriteFile();
    }
}
```

Excelente. Esto es mucho mejor.

Ahora nuestro nombre de clase nos dice que esta clase no escribe solo archivos xml. Además, no estamos restringiendo nuestro constructor para que acepte solo la clase `XmlWiter`, sino todas las clases que heredan de la interfaz `IWriter`. Nuestro método `WriteFile` no puede cambiarse de nombre ahora debido a nuestra interfaz `IWritter`, que establece que todas las clases deben implementar un método con un nombre idéntico. Podemos ver ahora que la clase `FileWriter` está desacoplada de `XmlWriter` o de `JsonWriter`, y que podemos enviar objetos de ambas clases a la clase `FileWriter`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        XmlWriter xmlWriter = new XmlWriter();
        JsonWriter jsonWriter = new JsonWriter();

        FileWriter fileWriter = new FileWriter(xmlWriter);
        fileWriter.Write();

        fileWriter = new FileWriter(jsonWriter);
        fileWriter.Write();

        Console.ReadKey();
    }
}
```

Resultado:

```bash
Writing file in the XmlWriter class.
Writing file in the JsonWriter class.
```

¿No es esto mucho mejor?

Ahora tenemos una clase que hace su trabajo para cualquier clase que herede de la interfaz `IWriter`.

Esta función se conoce como inyección de dependencia.

## Trabajar con múltiples interfaces

Una clase puede heredar solo de una clase base, pero puede implementar múltiples interfaces. La clase debe implementar todos los métodos definidos en esas interfaces:

```csharp
public interface IFormatter
{
    void FormatFile();
}

public class XmlWriter: FileBase, IWriter, IFormatter
{
    public void WriteFile()
    {
        Console.WriteLine("Writing file in the XmlWriter class.");
    }

    public override void SetName()
    {
        Console.WriteLine("Setting name in the XmlWriter class.");
    }

    public void FormatFile()
    {
        Console.WriteLine("Formatting file in XmlWriter class.");
    }
}
```

## Implementación de interfaz explícita

Como ya dijimos, una clase puede implementar más de una interfaz. No es inusual que dos de esas interfaces tengan un método con el mismo nombre, pero aún necesitamos implementarlas en nuestra clase. Para hacer eso, no implementamos un método como lo hicimos antes, pero necesitamos indicar el nombre de la interfaz primero y luego el nombre de un método con parámetros:

```csharp
public interface Interface1
{
    void MethodExample();
}

public interface Interface2
{
    void MethodExample();
}

public class ExampleClass: Interface1, Interface2
{
    void Interface1.MethodExample()
    {
        Console.WriteLine("");
    }

    void Interface2.MethodExample()
    {
        Console.WriteLine("");
    }

}
```

Como podemos ver, no estamos usando un modificador de acceso en la implementación del método.

## Conclusión

En este artículo, hemos aprendido:

- Cómo definir e implementar una interfaz
- Cómo hacer referencia a una clase a través de la interfaz
- La forma de desacoplar nuestros objetos con interfaces e inyección de dependencias
- Para implementar explícitamente nuestras interfaces

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com