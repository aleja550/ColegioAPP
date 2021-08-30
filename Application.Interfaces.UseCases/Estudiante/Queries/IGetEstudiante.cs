using Domain.AggregatesModel;
using System.Collections.Generic;

namespace Application.Interfaces.UseCases
{
    public interface IGetEstudiante
    {
        IEnumerable<Estudiante> GetAll();
        Estudiante GetById(int id);
    }
}
