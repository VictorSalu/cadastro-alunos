using System;

namespace CadastroAluno
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcao = ObterOpcaoUsuario();

            while (opcao != "4")
            {
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var  aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("informe a Nota do Aluno:");
                        
                         if (decimal.TryParse(Console.ReadLine(),out decimal nota))
                         {
                             aluno.Nota = nota; 
                         } 
                         else
                         {
                              throw new ArithmeticException("Valor da nota deve ser decimal");
                         }

                         alunos[indiceAluno] = aluno;
                         indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if  (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        decimal Ntotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i< alunos.Length; i++)
                        {
                            if  (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                Ntotal = Ntotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = Ntotal / nrAlunos;
                        Conceito conceitoGeral;
                        if(mediaGeral < 2 )
                        {
                           conceitoGeral = Conceito.E;                                     
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else  
                        {                        
                            conceitoGeral = Conceito.A;
                            
                        }
                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");


                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                

                opcao = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("4- Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine();
            Console.WriteLine();
            return opcao;
        }
    }
}
