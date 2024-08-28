namespace Escola
{
    public class Professor
    {
        public required string PrimeiroNome { get; set; }
        public required string Sobrenome { get; set; }
        public List<Materia> Materias { get; set; } = new List<Materia>();

        public void PublicarProvaOnline(Prova prova, Materia materia)
        {
            materia.CriarProva(prova.Data, prova.Tipo, prova.Nota);
        }

        public void AtribuirMateria(Materia materia)
        {
            Materias.Add(materia);
        }

        public void CriarProvaParaMateria(Materia materia, DateTime data, string tipo, float nota)
        {
            materia.CriarProva(data, tipo, nota);
        }

        
        public void EditarNotaProva(Prova prova, float novaNota)
        {
            prova.EditarNota(novaNota);
            Console.WriteLine($"Nota da prova '{prova.Tipo}' editada para: {novaNota}");
        }

       
        public void ListarMaterias()
        {
            Console.WriteLine($"Matérias do professor {PrimeiroNome} {Sobrenome}:");
            foreach (var materia in Materias)
            {
                Console.WriteLine(materia.Nome);
            }
        }
    }
}
