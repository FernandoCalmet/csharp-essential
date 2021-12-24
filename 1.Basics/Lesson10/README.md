# Modificadores de acceso de `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Tipos de modificadores de acceso

C # proporciona cuatro tipos de modificadores de acceso: privado, público, protegido, interno y dos combinaciones: protegido-interno y privado-protegido.

### Modificador de acceso privado

Los objetos que implementan modificadores de acceso privados son accesibles solo dentro de una clase o estructura. Como resultado, no podemos acceder a ellos fuera de la clase en la que fueron creados:

```csharp
class NumberClass
{
    private int number = 10;
}

class Program
{
    static void Main(string[] args)
    {
        NumberClass num = new NumberClass();
        Console.WriteLine(num.number); // Error. We can't access the number variable because 
        // it has the private access modifier and its only accessible in the NumberClass class
    }
}
```

### Modificador de acceso público

Los objetos que implementan modificadores de acceso público son accesibles desde cualquier lugar de nuestro proyecto. Por tanto, no existen restricciones de accesibilidad:

```csharp
class NumberClass
{
    public int number = 10;
}

class Program
{
    static void Main(string[] args)
    {
        NumberClass num = new NumberClass();
        Console.WriteLine(num.number); // This is OK. The number variable has the public access modifier.
    }
}
```

### Modificador de acceso protegido

La palabra clave protegida implica que el objeto es accesible dentro de la clase y en todas las clases que derivan de esa clase. Hablaremos con más detalle sobre la herencia en el módulo 2 sobre programación orientada a objetos. Pero por ahora, veremos este ejemplo para comprender el comportamiento de los miembros protegidos:

```csharp
class NumberClass
{
    protected int number = 10; //we can access this variable inside this class
}

class DerivedClass: NumberClass //this is inheritance. DerivedClass derives from the NumberClass class
{
    void Print()
    {
        Console.WriteLine(number); //we can access it in this class as well because it derives from the NumberClass class
    }
}

class Program
{
    void Print()
    {
        NumberClass num = new NumberClass();
        Console.WriteLine(num.number); // Error. The number variable is inaccessible due to its protection level. 
                               // The Program class doesn't derive from the NumberClass
    }
}
```

### Modificador de acceso interno

La palabra clave interna especifica que el objeto es accesible solo dentro de su propio ensamblado, pero no en otros ensamblajes:

```csharp
//First Project (ASSEMBLY)
public class NumberClassInFirstProject
{
    internal int number = 10; //we can access this variable inside this class
}

class ProgramInFirstProject
{
    void Print()
    {
        NumberClassInFirstProject num = new NumberClassInFirstProject();
        Console.WriteLine(num.number); // This is OK. Anywhere in this project (assembly) 
                                           // we can access the number variable.
    }
}

//Second project (ASSEMBLY)
class Program
{
    void Print()
    {
        NumberClassInFirstProject num = new NumberClassInFirstProject();
        Console.WriteLine(num.number); // Error. The number variable is inaccessible due to its protection level. 
                               //The Program class in second project can't access the internal members from another project
    }
}
```

### Modificador de acceso interno protegido

El modificador de acceso interno protegido es una combinación de protegido e interno. Como resultado, podemos acceder al miembro interno protegido solo en el mismo ensamblado o en una clase derivada en otros ensamblados (proyectos):

```csharp
//First Project (ASSEMBLY)
public class NumberClassInFirstProject
{
    protected internal int number = 10; //we can access this variable inside this class
}

class ProgramInFirstProject
{
    void Print()
    {
        NumberClassInFirstProject num = new NumberClassInFirstProject();
        Console.WriteLine(num.number); // This is OK. Anywhere in this project (assembly) we can access the number variable.
    }
}

//Second project (ASSEMBLY)
class Program: NumberClassInFirstProject //Inheritance
{
    void Print()
    {
        Console.WriteLine(number); //This is OK as well. The class Program derives from the NumberClassInFirstProject clas.
    }
}
```

### Modificador de acceso protegido privado

El modificador de acceso protegido privado es una combinación de palabras clave privadas y protegidas. Podemos acceder a los miembros dentro de la clase contenedora o en una clase que deriva de una clase contenedora, pero solo en el mismo ensamblado (proyecto). Por tanto, si intentamos acceder a él desde otro ensamblado, obtendremos un error.

## Conclusión

Entonces, eso es todo sobre modificadores de acceso. Como resultado, hemos aprendido qué tipos de modificadores de acceso podemos usar en C # y cuáles son sus limitaciones.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com