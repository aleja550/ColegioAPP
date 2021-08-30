using Domain.AggregatesModel;

namespace Application.Interfaces.UseCases
{
    public interface IEstudianteCursoCommand
    {
        void Create(EstudianteCurso estudiante);
        void Delete(int id);
    }
}
