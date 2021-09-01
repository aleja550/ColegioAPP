namespace Domain.AggregatesModel
{
    public class EstudianteCurso
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }    
        public int IdCurso { get; set; }       
        public double? NotaFinal { get; set; }

        public EstudianteCurso() { }

        public EstudianteCurso(int id, int idEstudiante, int idCurso, double? notaFinal)
        {
            Id = id;
            IdEstudiante = idEstudiante;
            IdCurso = idCurso;
            NotaFinal = notaFinal;
        }
    }
}
