# Patrón de diseño: Fluent Builder Interface con génericos recursivos 

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## El problema con la herencia de Fluent Builder

Imaginemos que queremos construir un objeto `Employee`. Entonces, obviamente, lo primero que debe hacer es crear nuestra clase modelo:

```csharp
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
    }
}
```

Para continuar, vamos a crear una clase de constructor para construir la Nameparte de nuestro objeto:

```csharp
public class EmployeeInfoBuilder
{
    protected Employee employee = new Employee();

    public EmployeeInfoBuilder SetName(string name)
    {
        employee.Name = name;
        return this;
    }
}
```

Ahora, podemos crear otra clase de constructor para construir la pieza `Position`, y esa clase heredará de la clase `EmployeeInfoBuilder` porque queremos reutilizar nuestro objeto de empleado:

```csharp
public class EmployeePositionBuilder: EmployeeInfoBuilder
{
    public EmployeePositionBuilder AtPosition(string position)
    {
        employee.Position = position;
        return this;
    }
}
```

Finalmente, podemos comenzar a hacer llamadas hacia las clases de este constructor:

![img01](/img/01.png)

Pero, como podemos ver, no podemos crear un objeto requerido. Esto se debe a que el método `SetName` devolverá una instancia de tipo `EmployeeInfoBuilder`que actualmente no implementa o hereda el método `AtPosition`. Esto está bastante bien ya que la clase `EmployeeInfoBuilder` es una clase de orden superior y la clase `EmployeePositionBuilder` hereda de ella, y no al revés.

Entonces, necesitamos encontrar una solución para propagar información de la clase derivada a la clase base. Y la solución está en un enfoque genérico recursivo.

## Implementación de genéricos recursivos con Fluent Builder

Entonces, comencemos con la clase `EmployeeBuilder` abstracta, que será responsable de crear instancias y proporcionar nuestro objeto de empleado:

```csharp
public abstract class EmployeeBuilder
{
    protected Employee employee;

    public EmployeeBuilder()
    {
        employee = new Employee();
    }

    public Employee Build() => employee;
}
```

Una vez que hayamos terminado, podemos continuar con la modificación `EmployeeInfoBuilder`. Hemos visto que SetNameno puede devolver el tipo `EmployeeInfoBuilder`, necesita devolver un tipo genérico. Teniendo esto en cuenta, modifiquemos nuestra clase:

```csharp
public class EmployeeInfoBuilder<T>: EmployeeBuilder where T: EmployeeInfoBuilder<T>
{
    public T SetName(string name)
    {
        employee.Name = name;
        return (T)this;
    }
}
```

¿¿¿OK qué???

Bueno, no es tan complicado como puede parecer a primera vista.

Hemos dicho que el método `SetName` debe devolver un tipo genérico, por lo tanto, nuestra clase también es genérica. Necesita heredar de la clase `EmployeeBuilder` porque necesitamos ese objeto de empleado. Finalmente, debemos asegurarnos de obtener el tipo correcto para el tipo T en nuestra clase. Podemos lograr esto restringiendo nuestro tipo T al tipo `EmployeeInfoBuilder`.

Ahora podemos continuar con la modificación `EmployeePositionBuilder`:

```csharp
public class EmployeePositionBuilder<T>: EmployeeInfoBuilder<EmployeePositionBuilder<T>> where T: EmployeePositionBuilder<T>
{
    public T AtPosition(string position)
    {
        employee.Position = position;
        return (T)this;
    }
}
```

Al hacer esto, habilitamos la herencia en ambas clases. Admiten el enfoque de interfaz de constructor fluido y ahora pueden devolver el tipo requerido.

Esto es muy útil en nuestro caso porque nuestro empleado necesita su salario. Podemos agregar fácilmente el salario ahora usando el método `WithSalary` de la clase `EmployeeSalaryBuilder`:

```csharp
public class EmployeeSalaryBuilder<T>: EmployeePositionBuilder<EmployeeSalaryBuilder<T>> where T: EmployeeSalaryBuilder<T>
{
    public T WithSalary(double salary)
    {
        employee.Salary = salary;
        return (T)this;
    }
}
```

En este momento, sabemos cómo crear clases Builder con genéricos recursivos.

Pero todavía no podemos empezar a construir nuestro objeto.

Eso es porque no está del todo claro qué tipo deberíamos al crear una instancia de la clase `EmployeeInfoBuilder`.

Por tanto, vamos a crear una API para permitir la construcción de nuestro objeto:

```csharp
public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
{
     public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector()
}
```

Ahora podemos empezar a construir nuestro objeto de forma fluida:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var emp = EmployeeBuilderDirector
            .NewEmployee
            .SetName("Maks")
            .AtPosition("Software Developer")
            .WithSalary(3500)
            .Build();

        Console.WriteLine(emp);
    }
}
```

Impresionante.

Ahora sabemos cómo habilitar la herencia fluida de la interfaz mediante el uso de un enfoque genérico recursivo.

## Conclusión

En el próximo artículo, que se relacionará nuevamente con el patrón Builder, hablaremos sobre Faceted Builder y le mostraremos cómo usar una fachada para crear un objeto que requiere más de una clase de constructor.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com