namespace Escola
{
    public class Prova
    {
        public DateTime Data { get; }
        public string Tipo { get; }
        public float Nota { get; private set; }

    
        public Prova(DateTime data, string tipo, float nota)
        {
            Data = data;
            Tipo = tipo;
            Nota = nota;
        }

        public void EditarNota(float novaNota)
        {
            Nota = novaNota;
        }

        public void VerNota()
        {
            Console.WriteLine($"Nota: {Nota}");
        }
    }
}
