namespace Domain.AggregatesModel
{
    public class EstudianteCurso
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }    
        public int IdCurso { get; set; }       
        public double? NotaFinal { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Curso Curso { get; set; }

        public EstudianteCurso() { }

        public EstudianteCurso(int id, int idEstudiante, Estudiante estudiante, int idCurso, Curso curso, double? notaFinal)
        {
            Id = id;
            IdEstudiante = idEstudiante;
            Estudiante = estudiante;
            IdCurso = idCurso;
            Curso = curso;
            NotaFinal = notaFinal;
        }
    }
}
