using Domain.AggregatesModel;
using System.Collections.Generic;

namespace Application.Interfaces.UseCases
{
    public interface IGetCurso
    {
        IEnumerable<Curso> GetAll();
        Curso GetById(int id);
    }
}
