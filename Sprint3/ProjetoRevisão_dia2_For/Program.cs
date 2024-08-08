Console.WriteLine($"Digite um numero para saber sua taboata até 10");
int numero = int.Parse(Console.ReadLine());

Console.WriteLine($"Taboada:");
for (var n = 0; n < 10; n++)
{
    int result = numero * (n+1);
    Console.WriteLine(result);
};