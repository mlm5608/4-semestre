Console.WriteLine("Digite um numero para saber sua taboada");
int n = int.Parse(Console.ReadLine()); 

for (var i = 0; i < 10; i++)
{
    int result = n * (i + 1);

    Console.WriteLine($"{n} X {i+1} = {result}");
};