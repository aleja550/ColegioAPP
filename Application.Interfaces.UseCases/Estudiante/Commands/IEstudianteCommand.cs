using Domain.AggregatesModel;

namespace Application.Interfaces.UseCases
{
    public interface IEstudianteCommand
    {
        void Create(Estudiante estudiante);
        void Update(Estudiante estudiante);
        void Delete(int id);
    }
}
