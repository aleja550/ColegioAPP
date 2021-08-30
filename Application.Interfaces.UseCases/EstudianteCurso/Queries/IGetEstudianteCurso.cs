using Domain.AggregatesModel;
using System.Collections.Generic;

namespace Application.Interfaces.UseCases
{
    public interface IGetEstudianteCurso
    {
        IEnumerable<EstudianteCurso> GetAll();
        EstudianteCurso GetById(int id);
    }
}
