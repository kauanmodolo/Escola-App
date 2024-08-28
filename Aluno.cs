namespace Escola
{
    public class Aluno
    {
        public required string PrimeiroNome { get; set; }
        public required string Sobrenome { get; set; }
        
        private Dictionary<Prova, float> ProvasRealizadas { get; set; } = new Dictionary<Prova, float>();

        public void FazerProva(Prova prova, float nota)
        {
            ProvasRealizadas[prova] = nota;
            Console.WriteLine($"{PrimeiroNome} {Sobrenome} fez a prova '{prova.Tipo}' e recebeu nota: {nota}");
        }

        public void ListarNotas()
        {
            Console.WriteLine($"Notas de {PrimeiroNome} {Sobrenome}:");
            foreach (var prova in ProvasRealizadas)
            {
                Console.WriteLine($"Prova: {prova.Key.Tipo}, Nota: {prova.Value}");
            }
        }

        public void DarFeedbackProfessor(Professor professor, string feedback)
        {
            Console.WriteLine($"{PrimeiroNome} {Sobrenome} deu o seguinte feedback ao professor {professor.PrimeiroNome} {professor.Sobrenome}: {feedback}");
        }

        public void FazerProvaOnline(Prova prova)
        {
            Console.WriteLine($"{PrimeiroNome} {Sobrenome} está fazendo a prova online: {prova.Tipo}");
            // Simulação de fazer prova online
            Console.WriteLine("Prova concluída!");
        }

        public void EditarNota(string tipoProva, float novaNota)
        {
            // Procurar a prova pelo tipo dentro do dicionário
            foreach (var prova in ProvasRealizadas.Keys)
            {
                if (prova.Tipo == tipoProva)
                {
                    ProvasRealizadas[prova] = novaNota;
                    Console.WriteLine($"Nota do aluno {PrimeiroNome} na prova '{prova.Tipo}' editada para: {novaNota}");
                    return;
                }
            }
            Console.WriteLine("Prova não encontrada para este aluno!");
        }
    }
     }

