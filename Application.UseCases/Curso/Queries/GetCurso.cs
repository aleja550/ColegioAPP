using Application.Interfaces.UseCases;
using Domain.AggregatesModel;
using Domain.SeedWork;
using System.Collections.Generic;

namespace Application.UseCases
{
    public class GetCurso : IGetCurso
    {
        private readonly ICursoRepository _cursoRepository;

        public GetCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public IEnumerable<Curso> GetAll()
        {
            IEnumerable<Curso> cursos = _cursoRepository.GetAll();

            if (cursos == null)
            {
                throw new HandlerException(204, $"No hay cursos creados");
            }

            return cursos;
        }

        public Curso GetById(int id)
        {
            Curso curso = _cursoRepository.GetById(id);

            if (curso == null)
            {
                throw new HandlerException(204, $"No hay cursos con este id {id}");
            }

            return curso;
        }
    }
}
