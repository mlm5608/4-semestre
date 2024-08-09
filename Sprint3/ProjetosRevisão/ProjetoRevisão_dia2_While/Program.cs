int somaPares = 0;
int contador = 0;
while (contador <= 100)
{
    somaPares = somaPares + contador;
    if (contador == 100)
    {
        Console.WriteLine(somaPares);
    };
    contador = contador + 2;
};