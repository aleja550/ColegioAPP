using Application.Interfaces.UseCases;
using Domain.AggregatesModel;
using Domain.SeedWork;
using System.Collections.Generic;

namespace Application.UseCases
{
    public class GetEstudianteCurso : IGetEstudianteCurso
    {
        private readonly IEstudianteCursoRepository _estudianteCursoRepository;

        public GetEstudianteCurso(IEstudianteCursoRepository estudianteCursoRepository)
        {
            _estudianteCursoRepository = estudianteCursoRepository;
        }
        public IEnumerable<EstudianteCurso> GetAll()
        {
            IEnumerable<EstudianteCurso> estudiantes = _estudianteCursoRepository.GetAll();

            if (estudiantes == null)
            {
                throw new HandlerException(204, $"No hay estudiantes creados.");
            }

            return estudiantes;
        }

        public EstudianteCurso GetById(int id)
        {
            EstudianteCurso estudianteCurso = _estudianteCursoRepository.GetById(id);

            if (estudianteCurso == null)
            {
                throw new HandlerException(204, $"No hay relacion de un estudiante y curso con este id {id}");
            }

            return estudianteCurso;
        }
    }
}
