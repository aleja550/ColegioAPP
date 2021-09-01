using Domain.AggregatesModel;

namespace Application.Interfaces.UseCases
{
    public interface IEstudianteCommand
    {
        Estudiante Create(Estudiante estudiante);
        void Update(Estudiante estudiante);
        void Delete(int id);
    }
}
