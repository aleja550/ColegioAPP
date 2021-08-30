namespace Domain.AggregatesModel
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumeroCreditos { get; set; }

        public Curso() { }

        public Curso(int id, string nombre, int numeroCreditos)
        {
            Id = id;
            Nombre = nombre;
            NumeroCreditos = numeroCreditos;
        }
    }
}
