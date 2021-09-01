using System.Collections.Generic;

namespace Domain.AggregatesModel
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetAll();
        Estudiante GetById(int id);
        Estudiante Create(Estudiante estudiante);
        void Update(Estudiante estudiante);
        void Delete(int id);
        bool CheckEstudiante(string documentNumber);
    }
}
