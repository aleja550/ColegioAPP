using Application.Interfaces.UseCases;
using Domain.AggregatesModel;
using Domain.SeedWork;

namespace Application.UseCases
{
    public class EstudianteCommand : IEstudianteCommand
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteCommand(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public Estudiante Create(Estudiante estudiante)
        {
            bool existsEstudiante = _estudianteRepository.CheckEstudiante(estudiante.Identificacion);

            if (existsEstudiante)
            {
                throw new HandlerException(409,$"El estudiante con la identificacion {estudiante.Identificacion} ya ha sido creado.");
            }

            Estudiante estudianteCreated = _estudianteRepository.Create(estudiante);

            return estudianteCreated;
        }
        public void Delete(int id) => _estudianteRepository.Delete(id);
        public void Update(Estudiante estudiante) => _estudianteRepository.Update(estudiante);
    }
}
