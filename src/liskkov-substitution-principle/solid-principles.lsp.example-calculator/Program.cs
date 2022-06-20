using solid_principles.lsp.example_calculator;

var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
Calculator sum = new SumCalculator(numbers);
Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
Console.WriteLine();
Calculator evenSum = new EvenNumbersSumCalculator(numbers);
Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");