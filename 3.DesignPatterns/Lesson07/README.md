# Patrón de diseño: Composite

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Estructura de patrón de diseño Composite

El patrón de diseño compuesto consta de las siguientes partes:

- Componente
- Hoja
- Compuesto

Un componente es una interfaz que describe operaciones que son comunes a elementos simples o complejos del árbol.

Una hoja es un objeto único, que no tiene subelementos. Nuestra estructura de árbol consta de más objetos hoja.

Compuesto es un objeto que tiene subelementos (hojas u otros objetos compuestos). Lo interesante es que el objeto compuesto no está familiarizado con las clases concretas de sus hijos. Se comunica con sus hijos a través de la interfaz del componente.

Finalmente, tenemos un cliente, que trabaja con todos los elementos a través de la interfaz Component.

Pero basta de teoría, comencemos con el ejemplo concreto.

## Implementación de patrones de diseño compuesto

Imaginemos que necesitamos calcular el precio total de un regalo que estamos vendiendo en nuestra tienda. El regalo puede ser un solo elemento (juguete) o puede ser un regalo complejo que consiste en una caja con dos juguetes y otra caja con quizás un juguete y la caja con un solo juguete adentro. Como podemos ver, tenemos una estructura de árbol que representa nuestro regalo complejo, por lo que implementar el patrón de diseño compuesto será la solución adecuada para nosotros.

Entonces, comencemos con la parte `Component`:

```csharp
public abstract class GiftBase
{
    protected string name;
    protected int price;

    public GiftBase(string name, int price)
    {
        this.name = name;
        this.price = price;
   }

    public abstract int CalculateTotalPrice();
}
```

Podemos ver que nuestro componente consta de dos campos protegidos y un método abstracto. Estos campos y método se utilizarán como interfaz entre la hoja y la parte compuesta de nuestro patrón.

Ahora, en muchos ejemplos, podemos ver operaciones adicionales como agregar y eliminar dentro de la clase abstracta, pero no las vamos a agregar en esta clase, porque nuestra clase Leaf no las necesita. Lo que vamos a crear en cambio es una nueva interfaz - `IGiftOperations`:

```csharp
public interface IGiftOperations
{
    void Add(GiftBase gift);
    void Remove(GiftBase gift);
}
```

Solo nuestro objeto compuesto implementará esta interfaz, pero el objeto hoja no lo hará. Esto es mucho mejor porque nuestro objeto hoja no necesita implementar los métodos que no usará.

## La implementación de la clase compuesta

Entonces, continuemos con la clase `Composite`:

```csharp
public class CompositeGift : GiftBase, IGiftOperations
{
    private List<GiftBase> _gifts;

    public CompositeGift(string name, int price)
        :base(name, price)
    {
        _gifts = new List<GiftBase>();
    }

    public void Add(GiftBase gift)
    {
        _gifts.Add(gift);
    }

    public void Remove(GiftBase gift)
    {
        _gifts.Remove(gift);
    }

    public override int CalculateTotalPrice()
    {
        int total = 0;

        Console.WriteLine($"{name} contains the following products with prices:");

        foreach (var gift in _gifts)
        {
            total += gift.CalculateTotalPrice();
        }

        return total;
    }
}
```

La implementación de la clase es bastante sencilla. Primero, tenemos la lista `GiftBase` de tipos en la que almacenamos nuestra hoja u otros objetos compuestos. Podemos agregar o eliminar esos objetos de nuestra lista implementando métodos `Add` y `Remove` desde nuestra interfaz `IGiftOperations`. Finalmente, estamos calculando el precio total de nuestro objeto `Gift` con todos los sub-regalos dentro de él.

## Implementación de la clase Leaf

Continuemos con la parte de la hoja:

```csharp
public class SingleGift : GiftBase
{
    public SingleGift(string name, int price)
        :base(name, price)
    {
    }

    public override int CalculateTotalPrice()
    {
        Console.WriteLine($"{name} with the price {price}");

        return price;
    }
}
```

Y eso es todo lo que necesitamos para la implementación `Leaf` porque no tiene subniveles, por lo que no requiere agregar o eliminar funciones en absoluto.

Finalmente, podemos implementar nuestra parte de cliente:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var phone = new SingleGift("Phone", 256);
        phone.CalculateTotalPrice();
        Console.WriteLine();

        //composite gift
        var rootBox = new CompositeGift("RootBox", 0);
        var truckToy = new SingleGift("TruckToy", 289);
        var plainToy = new SingleGift("PlainToy", 587);
        rootBox.Add(truckToy);
        rootBox.Add(plainToy);
        var childBox = new CompositeGift("ChildBox", 0);
        var soldierToy = new SingleGift("SoldierToy", 200);
        childBox.Add(soldierToy);
        rootBox.Add(childBox);

        Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
    }
}
```

Podemos ver que estamos creando un regalo con un solo elemento dentro y un regalo complejo con los juguetes y una caja adicional con un solo juguete dentro.

Entonces, tan pronto como ejecutemos nuestra aplicación, obtendremos este resultado:

![img01](/img/01.png)

Excelente. Eso lo envuelve para el patrón de diseño compuesto.

## Conclusión

Aunque este patrón puede parecer un poco complejo, es muy beneficioso usarlo cuando tenemos estructuras de árbol complejas en nuestro código.

Además, al tener una única interfaz compartida por todos los elementos del patrón compuesto, el cliente no tiene que preocuparse por la clase concreta con la que trabaja.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com