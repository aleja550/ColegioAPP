using Application.Interfaces.UseCases;
using Domain.AggregatesModel;
using Domain.SeedWork;
using System.Collections.Generic;

namespace Application.UseCases
{
    public class GetEstudiante : IGetEstudiante
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public GetEstudiante(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public IEnumerable<Estudiante> GetAll()
        {
            IEnumerable<Estudiante> estudiantes = _estudianteRepository.GetAll();

            if (estudiantes == null)
            {
                throw new HandlerException(204, $"No hay estudiantes creados.");
            }

            return estudiantes;
        }

        public Estudiante GetById(int id)
        {
            Estudiante estudiante = _estudianteRepository.GetById(id);

            if (estudiante == null)
            {
                throw new HandlerException(204, $"No hay estudiantes con este id {id}");
            }

            return estudiante;
        }
    }
}
