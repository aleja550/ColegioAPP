using System.Collections.Generic;

namespace Domain.AggregatesModel
{
    public interface IEstudianteCursoRepository
    {
        IEnumerable<EstudianteCurso> GetAll();
        EstudianteCurso GetById(int id);
        void Create(EstudianteCurso estudiante);
        void Delete(int id);
        bool CheckEstudianteEnCurso(int idCurso, int idEstudiante);
    }
}
