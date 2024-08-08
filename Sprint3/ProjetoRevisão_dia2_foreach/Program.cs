// 5) Você vai criar um programa que armazena as notas de vários alunos em diferentes disciplinas. O programa deve calcular a média de cada aluno e determinar quais alunos têm médias acima de 7.0 (aprovados) e quais têm médias abaixo de 7.0 (reprovados). O programa deve usar foreach para iterar sobre as coleções de alunos e suas notas.

// Especificações:

// - Armazene as notas de 3 disciplinas para cada aluno.
// - Calcule a média de cada aluno.
// - Exiba a média e o status (aprovado/reprovado) de cada aluno.
// - Use foreach para iterar sobre os alunos e as disciplinas.


string[] lista = [];
bool resposta;
int numeroAluno = 1;


do
{
    Console.WriteLine($"Digite a nota de Humanas do aluno {numeroAluno}");

    float nota1 = float.Parse(Console.ReadLine());

    Console.WriteLine($"Digite a nota de Exatas do aluno {numeroAluno}");

    float nota2 = float.Parse(Console.ReadLine());

    Console.WriteLine($"Digite a nota de Biológicas do aluno {numeroAluno}");

    float nota3 = float.Parse(Console.ReadLine());

    float media  = nota1+nota2+nota3 / 3;

    string status = media > 7? "aprovado" : "reprovado";    
} while (resposta != true)

foreach (var item in collection)
{
    
}