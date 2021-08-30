using Domain.AggregatesModel;
using System.Collections.Generic;

namespace Infrastructure.EntityFramework
{
    public class EstudianteCursoRepository : IEstudianteCursoRepository
    {
        private readonly IGenericRepository<EstudianteCurso> _estudianteCursoRepository;

        public EstudianteCursoRepository(IGenericRepository<EstudianteCurso> estudianteCursoRepository)
        {
            _estudianteCursoRepository = estudianteCursoRepository;
        }

        public IEnumerable<EstudianteCurso> GetAll() => _estudianteCursoRepository.Get();
        public EstudianteCurso GetById(int id) => _estudianteCursoRepository.GetById(id);

        public void Create(EstudianteCurso estudiante) => _estudianteCursoRepository.Add(estudiante);
        public void Delete(int id) => _estudianteCursoRepository.Delete(id);

        public bool CheckEstudianteEnCurso(int idCurso, int idEstudiante) => _estudianteCursoRepository.Any(ec => ec.IdCurso == idCurso && ec.IdEstudiante == idEstudiante);
    }
}
