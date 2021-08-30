using System.Collections.Generic;

namespace Domain.AggregatesModel
{
    public interface ICursoRepository
    {
        IEnumerable<Curso> GetAll();
        Curso GetById(int id);
    }
}
