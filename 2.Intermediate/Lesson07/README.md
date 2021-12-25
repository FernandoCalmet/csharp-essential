# Herencia

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Usando herencia

Podemos definir la herencia entre dos clases usando la siguiente sintaxis:

```csharp
class DerivedClass: BaseClass
{
       
}

class DerivedSubClass: DerivedClass
{

}
```

Lo que esto significa es que `DerivedSubClass` hereda de `DerivedClass` y de `BaseClass` también, porque DerivedClasshereda de `BaseClass`. De esa manera, podemos compartir las características de la clase entre varias clases, aunque una clase solo puede heredar de una clase base .

Entonces, creemos una estructura de herencia básica:

```csharp
public class Writer
{
    public void Write()
    {
        Console.WriteLine("Writing to a file");
    }
}
public class XMLWriter: Writer
{
    public void FormatXMLFile()
    {
        Console.WriteLine("Formating XML file");
    }
}
public class JSONWriter: Writer
{
    public void FormatJSONFile()
    {
        Console.WriteLine("Formating JSON file");
    }
}
```

En este ejemplo, las clases `XMLWriter` y `JSONWriter` tienen sus propios métodos, pero ambos comparten el método `Write()` de la clase base `Writer`.

Entonces, si creamos un objeto de tipo `XMLWriter`, podremos acceder a su propio método y al método de la clase base:

```csharp
class Program
{
    static void Main(string[] args)
    {
        XMLWriter xmlWriter = new XMLWriter();
        xmlWriter.FormatXMLFile();
        xmlWriter.Write();
    }
}
```

Lo mismo ocurre con la clase `JSONWriter`.

## Llamar a constructores desde la clase base

Desde las clases derivadas podemos acceder al constructor de una clase base. Esto se usa con bastante frecuencia, debido a la inicialización de algunas propiedades que se comparten entre clases derivadas. Podemos usar la basepalabra clave para ejecutar eso:

```csharp
public class Writer
{
    public string FileName { get; set; }

    public Writer(string fileName)
    {
        FileName = fileName;
    }

    public void Write()
    {
        Console.WriteLine("Writing to a file");
    }
}
public class XMLWriter: Writer
{
    public XMLWriter(string fileName)
        :base(fileName)
    {
    }

    public void FormatXMLFile()
    {
        Console.WriteLine("Formating XML file");
    }
}

public class JSONWriter: Writer
{
    public JSONWriter(string fileName)
        :base(fileName)
    {
    }

    public void FormatJSONFile()
    {
        Console.WriteLine("Formating JSON file");
    }
}
class Program
{
    static void Main(string[] args)
    {
        XMLWriter xmlWriter = new XMLWriter("xmlFileName");
        xmlWriter.FormatXMLFile();
        xmlWriter.Write();
        Console.WriteLine(xmlWriter.FileName);

        JSONWriter jsonWriter = new JSONWriter("jsonFileName");
        jsonWriter.FormatJSONFile();
        jsonWriter.Write();
        Console.WriteLine(jsonWriter.FileName);
    }
}
```

Como podemos ver, pasamos un valor de cadena a los constructores de la clase derivada y al usar la palabra clave `base`, estamos pasando ese valor de cadena al constructor de la clase base. Allí, configuramos el valor de la propiedad `Name`.

## Acceso a clases

La jerarquía de herencia significa que nuestra `XMLWriter` (o `JSONWriter`) clase es un tipo especial de `Writer`, tiene todos los miembros no privados de Writer y características adicionales declaradas dentro de la clase de Writer XML (JSON). Pero existen algunas limitaciones para esta jerarquía.

Veamos el siguiente ejemplo:

```csharp
XMLWriter xml = new XMLWriter("file.xml");
Writer writer = xml;
writer.Write(); //ok Write is part of the Writer class
writer.FormatXML(); //error FormatXML is not part of the Writer class
```

Esto significa que si nos referimos al objeto `XMLWriter` o `JSONWriter` con el objeto `Writer`, podemos acceder a los métodos declarados dentro de la clase Writer.

Hay una limitación más. No podemos asignar un objeto de rango superior a un objeto de rango inferior:

```csharp
Writer writer = new Writer("any name");
XMLWriter xml = writer; //error
```

Pero podemos resolver este problema usando la aspalabra clave " ":

```csharp
XMLWriter xml = new XMLWriter("any name");
Writer writer = xml; //writer points to xml

XMLWriter newWriter = writer as XMLWriter; //this is ok now because writer was xml
newWriter.FormatXMLFile();
```

## Declaración de métodos con la nueva palabra clave

En el proyecto del mundo real, a menudo necesitamos tener tantas funcionalidades diferentes, y eso generalmente conduce a la existencia de muchos métodos, propiedades diferentes, etc. A veces es bastante difícil encontrar un nombre único y significativo para nuestros identificadores, especialmente si tenemos la jerarquía de herencia. Tarde o temprano vamos a intentar reutilizar un nombre que ya está siendo utilizado por una de las clases en el nivel jerárquico superior. Si se trata de eso (tenemos dos métodos con el mismo nombre en la clase derivada y base) vamos a recibir una advertencia:

![img01](/img/01.png)

## Usando la nueva palabra clave

Un método en una clase derivada oculta un método en una clase base con la misma firma. Entonces, como puede ver en la imagen de arriba, nuestro método SetNameexiste en la clase `XMLWriter` y la clase `Writer`. Dado que la clase `XMLWriter` hereda de la clase `Writer`, oculta una implementación del SetNamemétodo de la clase `Writer`.

Aunque nuestro código se compilará y se ejecutará, debemos tomar esta advertencia en serio. Puede suceder que otra clase herede de la clase `XMLWriter` e implemente el SetNamemétodo. El desarrollador puede esperar ejecutar el SetNamemétodo de la clase `Writer` (porque XMLWriterhereda de Writer) pero este no es un caso. El SetNamemétodo de la clase `Writer` está oculto por el SetNamemétodo de la clase `XMLWriter`.

Si nos encontramos en este tipo de situación, la mejor forma es cambiar las firmas del método. Pero si estamos seguros de que queremos un comportamiento como este, podemos usar la palabra clave `new`. La newpalabra clave simplemente le dirá al compilador que estamos cien por ciento seguros de lo que estamos haciendo y que ya no queremos que aparezca un mensaje de advertencia:

```csharp
public class Writer
{
    public string FileName { get; set; }

    public Writer(string fileName)
    {
        FileName = fileName;
    }

    public void Write()
    {
        Console.WriteLine("Writing to a file");
    }

    public void SetName()
    {
        Console.WriteLine("Setting name in the base Writer class");
    }
}
 
public class XMLWriter: Writer
{
    public XMLWriter(string fileName)
        :base(fileName)
    {
    }

    public void FormatXMLFile()
    {
        Console.WriteLine("Formating XML file");
    }

    public new void SetName()
    {
        Console.WriteLine("Setting name in the XMLWriter class");
    }
}
```

Ahora ya no tenemos un mensaje de advertencia.

## Declarar métodos con la palabra clave virtual

A veces, no queremos ocultar una implementación de un método de una clase base con la misma firma que un método de una clase derivada. Lo que queremos es brindar una oportunidad para una implementación diferente de un método con la misma firma en una clase derivada. Entonces, queremos anular nuestro método de una clase base con el método dentro de una clase derivada.

Un método que se pretende anular se denomina método virtual. Cuando hablamos de anular y ocultar, debemos ser claros con esos términos. Ocultar significa que queremos ocultar completamente la implementación de un método de la clase base, pero la anulación significa que queremos una implementación diferente de un método de una clase base.

Para crear un método virtual usamos la `virtual` palabra clave:

```csharp
public class Writer
{
    public string FileName { get; set; }

    public Writer(string fileName)
    {
        FileName = fileName;
    }

    public void Write()
    {
        Console.WriteLine("Writing to a file");
    }

    public void SetName()
    {
        Console.WriteLine("Setting name in the base Writer class");
    }

    public virtual void CalculateFileSize()
    {
        Console.WriteLine("Calculating file size in a Writer class");
    }
}
```

## Declaración de métodos con la palabra clave de anulación

Si declaramos un método como `virtual` en nuestra clase base, podemos crear un método en una clase derivada con la palabra clave `override` para declarar otra implementación de ese método:

```csharp
public class XMLWriter: Writer
{
    public XMLWriter(string fileName)
        :base(fileName)
    {
    }

    public void FormatXMLFile()
    {
        Console.WriteLine("Formating XML file");
    }

    public new void SetName()
    {
        Console.WriteLine("Setting name in the XMLWriter class");
    }

    public override void CalculateFileSize()
    {
        Console.WriteLine("Calculating file size in the XMLWriter class");
    }
}
```

Si queremos, podemos llamar a una implementación original de ese método en una clase derivada usando la `base` palabra clave:

```csharp
public class XMLWriter: Writer
{
    ...

    public override void CalculateFileSize()
    {
        base.CalculateFileSize();
        Console.WriteLine("Calculating file size in the XMLWriter class");
    }
}
```

Todas estas acciones de herencia y diferentes implementaciones de métodos con las palabras clave mencionadas tienen su propio polimorfismo de nombre único.

## Reglas a seguir al trabajar con métodos polimórficos

Hay algunas reglas importantes que debemos seguir al declarar métodos polimórficos mediante el uso de las palabras clave virtual y override:

- No podemos declarar un método virtual como privado. Su propósito es estar expuesto a una clase derivada, por lo que hacerlo privado no tiene sentido. Del mismo modo, los métodos anulados no pueden ser privados porque una clase derivada no puede cambiar el nivel de protección de un método que hereda.
- Las firmas de los métodos virtuales y anulados deben ser idénticas
- Solo podemos anular un método virtual. Si intentamos anular un método que no tiene una palabra clave virtual, obtendremos un error
- Si no usamos la palabra clave override, no estamos reemplazando el método, solo lo estamos ocultando. Si este es el comportamiento que queremos, debemos usar la nueva palabra clave
- Un método anulado también es virtual, por lo que puede anularse en una clase derivada adicional


## Conclusión

En este artículo, hemos aprendido:

- Que es la herencia y como se usa
- Cómo utilizar las palabras clave nuevas, virtuales y anuladas
- Reglas de polimorfismo en el lenguaje C #

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com