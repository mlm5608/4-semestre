int tentativas = 0;
Random numAleatorio = new Random();
int numAdivinhado = numAleatorio.Next(0, 100);
int numDigitado;
do
{
    Console.WriteLine($"Digite um numero aleatório de 1 a 100");
    numDigitado = int.Parse(Console.ReadLine());
    tentativas++;
    
} while (numAdivinhado != numDigitado);

if (numDigitado == numAdivinhado)
{
    Console.WriteLine($"Parabéns vc acertou!! seu numero de tentativas foi {tentativas}");
};