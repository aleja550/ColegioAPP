using Domain.AggregatesModel;
using System.Collections.Generic;

namespace Infrastructure.EntityFramework
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IGenericRepository<Curso> _cursoRepository;

        public CursoRepository(IGenericRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public IEnumerable<Curso> GetAll() => _cursoRepository.Get();
        public Curso GetById(int id) => _cursoRepository.GetById(id);
    }
}
