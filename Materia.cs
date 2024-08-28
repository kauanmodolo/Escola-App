namespace Escola
{
    public class Materia
    {
        public required string Nome { get; set; }
        private List<Prova> Provas { get; set; } = new List<Prova>();

        public void CriarProva(DateTime data, string tipo, float nota)
        {
            var prova = new Prova(data, tipo, nota);
            Provas.Add(prova);
        }

        public void ListarProvas()
        {
            foreach (var prova in Provas)
            {
                Console.WriteLine($"Prova: {prova.Tipo}, Data: {prova.Data}, Nota: {prova.Nota}");
            }
        }

    
        public List<Prova> ObterProvas()
        {
            return Provas;
        }
    }
}

