using Application.Interfaces.UseCases;
using Domain.AggregatesModel;

namespace Application.UseCases
{
    public class EstudianteCursoCommand : IEstudianteCursoCommand
    {
        private readonly IEstudianteCursoRepository _estudianteCursoRepository;

        public EstudianteCursoCommand(IEstudianteCursoRepository estudianteCursoRepository)
        {
            _estudianteCursoRepository = estudianteCursoRepository;
        }

        public void Create(EstudianteCurso estudianteCurso) => _estudianteCursoRepository.Create(estudianteCurso);
        public void Delete(int id) => _estudianteCursoRepository.Delete(id);
    }
}
