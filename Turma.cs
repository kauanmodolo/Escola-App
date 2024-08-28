namespace Escola
{
    public class Turma
    {
        public required string Nome { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Materia> Materias { get; set; } = new List<Materia>();

        public void AtribuirProfessor(Professor professor)
        {
            Professores.Add(professor);
        }

        public void AtribuirAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void AdicionarMateria(Materia materia)
        {
            Materias.Add(materia);
        }

        public void ListarProfessores()
        {
            Console.WriteLine("Professores da Turma:");
            foreach (var professor in Professores)
            {
                Console.WriteLine($"{professor.PrimeiroNome} {professor.Sobrenome}");
            }
        }

        public void ListarAlunos()
        {
            Console.WriteLine("Alunos da Turma:");
            foreach (var aluno in Alunos)
            {
                Console.WriteLine($"{aluno.PrimeiroNome} {aluno.Sobrenome}");
            }
        }

        public void ListarMaterias()
        {
            Console.WriteLine("Matérias da Turma:");
            foreach (var materia in Materias)
            {
                Console.WriteLine($"{materia.Nome}");
            }
        }

        public Materia EscolherMateria(string nome)
        {
            var materia = Materias.Find(m => m.Nome == nome);
            if (materia == null)
            {
                throw new InvalidOperationException($"Matéria '{nome}' não encontrada!");
            }
            return materia;
        }
    }
}
