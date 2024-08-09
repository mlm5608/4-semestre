string[] listaNomes= new string[5];

for (var i = 0; i <= 4; i++)
{
    Console.WriteLine($"digite o {i+1}° nome");
    listaNomes[i] = Console.ReadLine();
};

Array.Sort(listaNomes);
Console.Clear();

foreach (var n in listaNomes)
{
    Console.WriteLine(n);
};