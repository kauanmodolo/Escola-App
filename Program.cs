using Escola;

namespace EscolaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuração inicial das matérias e professor.
            Materia matematica = new Materia { Nome = "matematica" };
            Materia poo2 = new Materia { Nome = "poo2" };
            
            // Instanciando e atribuindo materias à esse professor
            Professor professor1 = new Professor { PrimeiroNome = "Gabriela", Sobrenome = "Martins" };
            professor1.AtribuirMateria(matematica);
            professor1.AtribuirMateria(poo2);

            Turma turma1 = new Turma { Nome = "1º Ano" };
            turma1.AtribuirProfessor(professor1);

            // Instanciando e alocando um aluno na turma "1º Ano"
            Aluno aluno1 = new Aluno { PrimeiroNome = "Kauan", Sobrenome = "Modolo" };
            turma1.AtribuirAluno(aluno1);
            // Alocando as materias na turma
            turma1.AdicionarMateria(matematica);
            turma1.AdicionarMateria(poo2);

            // Menu do professor
            while (true)
            {
                Console.WriteLine("\nMenu do Professor:");
                Console.WriteLine("1. Criar Prova para uma Matéria");
                Console.WriteLine("2. Atribuir Nota para um Aluno");
                Console.WriteLine("3. Editar Nota de uma Prova");
                Console.WriteLine("4. Listar Alunos da Turma");
                Console.WriteLine("5. Listar Provas de uma Matéria");
                Console.WriteLine("6. Listar Matérias que Ensina");
                Console.WriteLine("7. Adicionar Aluno à Turma");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    try
                    {
                        switch (opcao)
                        {
                            case 1:
                                Console.WriteLine("Escolha uma Matéria:");
                                turma1.ListarMaterias();  

                                Console.Write("Digite o nome da matéria: ");
                                string nomeMateria = Console.ReadLine();

                                Materia materiaEscolhida = turma1.EscolherMateria(nomeMateria);

                                if (materiaEscolhida != null)
                                {
                                    Console.Write("Digite a data da prova (yyyy-mm-dd): ");
                                    DateTime dataProva = DateTime.Parse(Console.ReadLine());

                                    Console.Write("Digite o tipo de prova: ");
                                    string tipoProva = Console.ReadLine();

                                    Console.Write("Digite a nota máxima da prova: ");
                                    float notaMaxima = float.Parse(Console.ReadLine());

                                    professor1.CriarProvaParaMateria(materiaEscolhida, dataProva, tipoProva, notaMaxima);
                                    Console.WriteLine("Prova criada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Matéria não encontrada!");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Escolha um Aluno:");
                                turma1.ListarAlunos(); 

                                Console.Write("Digite o nome do aluno: ");
                                string nomeAluno = Console.ReadLine();

                                Aluno alunoEscolhido = turma1.Alunos.Find(a => $"{a.PrimeiroNome} {a.Sobrenome}" == nomeAluno);

                                if (alunoEscolhido != null)
                                {
                                    Console.Write("Digite o tipo de prova: ");
                                    string tipoProvaAluno = Console.ReadLine();

                                    Console.Write("Digite a nota do aluno: ");
                                    float notaAluno = float.Parse(Console.ReadLine());

                                    Prova prova = new Prova(DateTime.Now, tipoProvaAluno, notaAluno);
                                    alunoEscolhido.FazerProva(prova, notaAluno);
                                    Console.WriteLine("Nota atribuída com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não encontrado!");
                                }
                                break;

                            case 3: // Editar Nota de uma Prova
                                Console.WriteLine("Escolha um Aluno:");
                                turma1.ListarAlunos();  // Lista os alunos disponíveis

                                Console.Write("Digite o nome do aluno: ");
                                nomeAluno = Console.ReadLine();

                                alunoEscolhido = turma1.Alunos.Find(a => $"{a.PrimeiroNome} {a.Sobrenome}" == nomeAluno);

                                if (alunoEscolhido != null)
                                {
                                    // Listar todas as notas do aluno
                                    alunoEscolhido.ListarNotas();

                                    Console.WriteLine("Escolha uma Matéria:");
                                    turma1.ListarMaterias();  // Lista as matérias disponíveis

                                    Console.Write("Digite o nome da matéria: ");
                                    nomeMateria = Console.ReadLine();

                                    materiaEscolhida = turma1.EscolherMateria(nomeMateria);

                                    if (materiaEscolhida != null)
                                    {
                                        materiaEscolhida.ListarProvas();

                                        Console.Write("Digite o tipo de prova que deseja editar a nota: ");
                                        string tipoProva = Console.ReadLine();

                                        
                                        Console.Write("Digite a nova nota: ");
                                        float novaNota = float.Parse(Console.ReadLine());
                                        alunoEscolhido.EditarNota(tipoProva, novaNota);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Matéria não encontrada!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não encontrado!");
                                }
                                break;



                            case 4:
                                turma1.ListarAlunos();
                                break;

                            case 5:
                                Console.WriteLine("Escolha uma Matéria:");
                                turma1.ListarMaterias(); 

                                Console.Write("Digite o nome da matéria: ");
                                nomeMateria = Console.ReadLine();

                                materiaEscolhida = turma1.EscolherMateria(nomeMateria);
                                if (materiaEscolhida != null)
                                {
                                    materiaEscolhida.ListarProvas();
                                }
                                else
                                {
                                    Console.WriteLine("Matéria não encontrada!");
                                }
                                break;

                            case 6:
                                professor1.ListarMaterias();
                                break;

                            case 7: 
                                Console.Write("Digite o primeiro nome do aluno: ");
                                string primeiroNomeAluno = Console.ReadLine();
                                Console.Write("Digite o sobrenome do aluno: ");
                                string sobrenomeAluno = Console.ReadLine();

                                Aluno novoAluno = new Aluno { PrimeiroNome = primeiroNomeAluno, Sobrenome = sobrenomeAluno };
                                turma1.AtribuirAluno(novoAluno);
                                Console.WriteLine("Aluno adicionado com sucesso!");
                                break;

                            case 8:
                                return;

                            default:
                                Console.WriteLine("Opção inválida, tente novamente.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                }
            }
        }
    }
}
