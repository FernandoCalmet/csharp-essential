# Patrón de diseño: Factory Method

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Implementación del Factory Method

Para implementar un patrón de método de fábrica, vamos a crear una aplicación de aire acondicionado simple. Nuestra aplicación recibirá una entrada de un usuario y, en base a esa entrada, activará una acción requerida (enfriar o calentar la habitación). Así que comencemos con una interfaz:

```csharp
public interface IAirConditioner
{
    void Operate();
}
```

Ahora, necesitamos clases concretas para implementar esta interfaz:

```csharp
public class CoolingManager : IAirConditioner
{
    private readonly double _temperature;

    public CoolingManager(double temperature)
    {
        _temperature = temperature;
    }

    public void Operate()
    {
        Console.WriteLine($"Cooling the room to the required temperature of {_temperature} degrees");
    }
}
```

```csharp
public class WarmingManager : IAirConditioner
{
    private readonly double _temperature;

    public WarmingManager(double temperature)
    {
        _temperature = temperature;
    }

    public void Operate()
    {
        Console.WriteLine($"Warming the room to the required temperature of {_temperature} degrees.");
    }
}
```

Estupendo. Hemos preparado nuestra funcionalidad base. Ahora creemos un creador de fábrica para estos objetos.

## Clase Factory

Vamos a empezar con la clase abstracta `AirConditionerFactory` :

```csharp
public abstract class AirConditionerFactory
{
    public abstract IAirConditioner Create(double temperature);
}
```

Esta clase abstracta proporciona una interfaz para la creación de objetos en clases derivadas. Dicho esto, implementemos nuestras clases de creadores concretas:

```csharp
public class CoolingFactory : AirConditionerFactory
{
    public override IAirConditioner Create(double temperature) => new CoolingManager(temperature);
}
```

```csharp
public class WarmingFactory : AirConditionerFactory
{
    public override IAirConditioner Create(double temperature) => new WarmingManager(temperature);
}
```

Excelente. Ahora estamos listos para comenzar a usar nuestros métodos de fábrica. En muchos ejemplos, podemos ver la declaración de cambio que cambia a través de la entrada del usuario y selecciona la clase de fábrica requerida.

Eso funciona bien.

Pero imagínese si tenemos muchas clases de fábrica, lo cual es bastante común en proyectos grandes. Eso conduciría a una declaración de caso de cambio bastante grande que es bastante ilegible. Por lo tanto, usaremos otro enfoque.

## Ejecución de Factory

Comencemos con una enumeración simple para definir las acciones del aire acondicionado:

```csharp
public enum Actions
{
    Cooling,
    Warming
}
```

Para continuar, vamos a crear la clase `AirConditioner` donde el usuario puede especificar el tipo de acción y ejecutar la fábrica correspondiente. Nuestras fábricas de hormigón heredan de la clase abstracta y vamos a utilizar esa estructura en nuestra implementación posterior:

```csharp
public class AirConditioner
{
    private readonly Dictionary<Actions, AirConditionerFactory> _factories;

    public AirConditioner()
    {
        _factories = new Dictionary<Actions, AirConditionerFactory>
        {
            { Actions.Cooling, new CoolingFactory() },
            { Actions.Warming, new WarmingFactory() }
        };
    }
}
```

Esta es una mejor manera de implementar nuestra ejecución de fábrica que usar una declaración de caso de cambio. Pero podemos hacerlo de otra manera más dinámica, donde no tengamos que agregar manualmente la acción y el creador de fábrica para cada acción. Introduzcamos la reflexión en nuestro proyecto:

```csharp
public class AirConditioner
{
    private readonly Dictionary<Actions, AirConditionerFactory> _factories;

    public AirConditioner()
    {
        _factories = new Dictionary<Actions, AirConditionerFactory>();

        foreach (Actions action in Enum.GetValues(typeof(Actions)))
        {
            var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
            _factories.Add(action, factory);
        }
    }
}
```

Ya sea que elijamos el primer o el segundo ejemplo, el resultado debería ser el mismo:

![img01](/img/01.png)

Hay una cosa más que debemos agregar a esta clase. Y ese es el método que va a ejecutar la creación apropiada:

```csharp
public class AirConditioner
{
    //previous constructor code

    public IAirConditioner ExecuteCreation(Actions action, double temperature) =>_factories[action].Create(temperature);
}
```

Ahora, solo tenemos que hacer una llamada de un cliente. En un proyecto del mundo real, seguramente verificaríamos primero la temperatura actual y luego solo tendríamos una fábrica para decidir si deberíamos reducirla o aumentarla. Pero en aras de la simplicidad, solo vamos a hacer una simple llamada a nuestra clase de `AirConditioner`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var factory = new AirConditioner().ExecuteCreation(Actions.Cooling, 22.5);
        factory.Operate();
    }
}
```

Nuestro resultado debería ser el esperado:

![img02](/img/02.png)

## Uso de la técnica de refactorización del factory method

Podemos usar el método Factory para reemplazar nuestro constructor mientras creamos un objeto. Si nuestro constructor consta de mucho código, deberíamos reemplazarlo con el método de fábrica. Además, podemos tener múltiples métodos de fábrica con nombres significativos y nombres de parámetros que reemplazan a un solo constructor.

Esto mejora mucho la legibilidad del código.

Finalmente, nos ayuda a implementar una sintaxis de encadenamiento.

Entonces modifiquemos la clase `AirConditioner` con el método de fábrica:

```csharp
public class AirConditioner
{
    private readonly Dictionary<Actions, AirConditionerFactory> _factories;

    private AirConditioner()
    {
        _factories = new Dictionary<Actions, AirConditionerFactory>();

        foreach (Actions action in Enum.GetValues(typeof(Actions)))
        {
            var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
                _factories.Add(action, factory);
        }
    }

    public static AirConditioner InitializeFactories() => new AirConditioner();

    public IAirConditioner ExecuteCreation(Actions action, double temperature) =>_factories[action].Create(temperature);
}
```

Nuestra llamada de cliente también debe modificarse:

```csharp
class Program
{
    static void Main(string[] args)
    {
        AirConditioner
            .InitializeFactories()
            .ExecuteCreation(Actions.Cooling, 22.5)
            .Operate();
    }
}
```

Excelente. El resultado debería ser el mismo, pero ahora estamos usando la técnica de refactorización del factory method.

## Conclusión

Al leer este artículo, hemos aprendido:

- Cómo implementar el patrón de diseño del método de fábrica en la aplicación
- Varias formas de reemplazar declaraciones de cambio de mayúsculas y minúsculas mediante el uso de un diccionario o una reflexión
- Cómo refactorizar su código utilizando la técnica de refactorización del factory method

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com