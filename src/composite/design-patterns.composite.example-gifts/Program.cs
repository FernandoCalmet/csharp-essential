using design_patterns.composite.example_gifts;

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