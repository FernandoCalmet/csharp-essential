# Patrón de diseño: Facade

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## ¿Qué es un patrón de fachada?

Como sugiere el nombre, representa una "fachada" para que el usuario final simplifique el uso de los subsistemas que están mal diseñados y / o son demasiado complicados al ocultar sus detalles de implementación. También resulta útil cuando se trabaja con bibliotecas y API complejas.

Un patrón de fachada está representado por una interfaz de clase única que es simple, fácil de leer y usar, sin el problema de cambiar los propios subsistemas. Sin embargo, debemos tener cuidado ya que limitar el uso de las funcionalidades del subsistema puede no ser suficiente para los usuarios avanzados.

## Ejemplo de patrón de fachada

Como ejemplo para explicar mejor el patrón de fachada, describiremos el flujo de trabajo de pedir comida en línea.

Digamos que tenemos una lista de restaurantes. Abrimos la página del restaurante, buscamos el plato que nos gusta y lo añadimos al carrito. Lo hacemos tantas veces como queramos y completamos el pedido. Cuando enviamos el pedido, recibimos una confirmación del pedido junto con el precio del pedido.

Primero, creemos una clase llamada Orderque representará el orden proveniente del Usuario:

```csharp
public class Order
{
    public string DishName { get; set; }
    public double DishPrice { get; set; }
    public string User { get; set; }
    public string ShippingAddress { get; set; }
    public double ShippingPrice { get; set; }

    public override string ToString()
    {
        return string.Format("User {0} ordered {1}. The full price is {2} dollars.",
            User, DishName, DishPrice + ShippingPrice);
    }
}
```

Además, tenemos que crear dos clases más: un restaurante en línea y un servicio de envío. La clase `OnlineRestaurant` proporciona métodos para agregar pedidos al carrito:

```csharp
public class OnlineRestaurant
{
    private readonly List<Order> _cart;

    public OnlineRestaurant()
    {
        _cart = new List<Order>();
    }

    public void AddOrderToCart(Order order)
    {
        _cart.Add(order);
    }

    public void CompleteOrders()
    {
        Console.WriteLine("Orders completed. Dispatch in progress...");
    }
}
```

Por otro lado, la clase `ShippingService` acepta el pedido y lo envía a la dirección almacenada en la propiedad `ShippingAddress` dentro de la clase `Order`. El `ShippingService` también calcula los gastos de envío y se los muestra al usuario:

```csharp
public class ShippingService
{
    private Order _order;

    public void AcceptOrder(Order order)
    {
        _order = order;
    }

    public void CalculateShippingExpenses()
    {
        _order.ShippingPrice = 15.5;
    }

    public void ShipOrder()
    {
        Console.WriteLine(_order.ToString());
        Console.WriteLine("Order is being shipped to {0}...", _order.ShippingAddress);
    }
}
```

Al final, estamos incorporando toda la lógica en la clase `Main` para representar el flujo de trabajo de pedir comida en línea:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var restaurant = new OnlineRestaurant();
        var shippingService = new ShippingService();

        var chickenOrder = new Order() { DishName = "Chicken with rice", DishPrice = 20.0, User = "User1", ShippingAddress = "Random street 123" };
        var sushiOrder = new Order() { DishName = "Sushi", DishPrice = 52.0, User = "User2", ShippingAddress = "More random street 321" };

        restaurant.AddOrderToCart(chickenOrder);
        restaurant.AddOrderToCart(sushiOrder);
        restaurant.CompleteOrders();

        shippingService.AcceptOrder(chickenOrder);
        shippingService.CalculateShippingExpenses();
        shippingService.ShipOrder();

        shippingService.AcceptOrder(sushiOrder);
        shippingService.CalculateShippingExpenses();
        shippingService.ShipOrder();

        Console.ReadLine();
    }
}
```

El resultado de la implementación actual de la `Main` clase es:

![img01](/img/01.png)

Nota: Asumimos que los pedidos vienen del exterior y por eso los creamos dentro de la Mainclase. Esto es opcional, por supuesto, para sistemas más complicados, esto también sería parte de algún servicio.

Ahora, para aquellos de ustedes que se preguntan:

"¿Por qué está mal esto?"

Sigue leyendo.

Al observar la clase `Main` y todos los pasos que hemos implementado, podemos ver una gran cantidad de código en una sola clase. Dado que tendemos a hacer las cosas más fáciles de leer y menos complicadas, tenemos que hacer algunos ajustes.

Y ahí es donde interviene el patrón de fachada.

## Implementación del patrón de fachada

Uno de los objetivos del Patrón de fachada es ocultar los detalles de implementación, lo que indica que tener todo en la Mainclase no funciona. Es demasiada información innecesaria, por lo tanto, nos gustaría más en otro lugar.

Dicho esto, vamos a crear otra clase llamada `Facade`. La clase `Facade` actuará como un "middleware" entre el Usuario y la complejidad del sistema sin cambiar la lógica empresarial:

```csharp
public class Facade
{
    private readonly OnlineRestaurant _restaurant;
    private readonly ShippingService _shippingService;

    public Facade(OnlineRestaurant restaurant, ShippingService shippingService)
    {
        _restaurant = restaurant;
        _shippingService = shippingService;
    }

    public void OrderFood(List<Order> orders)
    {
        foreach (var order in orders)
        {
            _restaurant.AddOrderToCart(order);
        }

        _restaurant.CompleteOrders();

        foreach (var order in orders)
        {
            _shippingService.AcceptOrder(order);
            _shippingService.CalculateShippingExpenses();
            _shippingService.ShipOrder();
        }
    }
}
```

Como hemos movido la lógica de implementación a la clase `Facade`, podemos simplificar la clase `Main`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var restaurant = new OnlineRestaurant();
        var shippingService = new ShippingService();

        var facade = new Facade(restaurant, shippingService);

        var chickenOrder = new Order() { DishName = "Chicken with rice", DishPrice = 20.0, User = "User1", ShippingAddress = "Random street 123" };
        var sushiOrder = new Order() { DishName = "Sushi", DishPrice = 52.0, User = "User2", ShippingAddress = "More random street 321" };

        facade.OrderFood(new List<Order>() { chickenOrder, sushiOrder });

        Console.ReadLine();
    }
}
```

Cuando ejecutamos el código, podemos ver el resultado exacto:

![img02](/img/02.png)

Esto significa que hemos liberado con éxito al usuario de la presión innecesaria de conocer todos los pasos necesarios para que llegue la comida.

Nota: en este ejemplo, pasamos el `OnlineRestaurant` y el `ShippingService` al Facade, asumiendo que ya están creados. Sin embargo, también se pueden crear instancias dentro de `Facade` en sí mismo.

## Conclusión

Entonces, hemos visto cómo el patrón de fachada puede ayudarnos a facilitar la vida del cliente. Ahora, estamos listos para adoptar las complejas implementaciones tal como están. Y por último, pero no menos importante, en determinadas situaciones, el uso de este patrón requiere precaución. Puede limitar las capacidades del usuario para hacer uso de todo el potencial de la aplicación o biblioteca que estamos tratando de simplificar.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com