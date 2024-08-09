Console.WriteLine($"Digite a nota:");
float nota = float.Parse(Console.ReadLine());

if(nota >= 0 && nota <= 10)
{
    if(nota > 7){
        Console.WriteLine($"aprovado");
    }else{
        Console.WriteLine($"reprovado");
    }
}
else
{
    Console.WriteLine($"nota inválida");
}
