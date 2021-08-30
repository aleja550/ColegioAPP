using Domain.AggregatesModel;
using System.Collections.Generic;

namespace Infrastructure.EntityFramework
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly IGenericRepository<Estudiante> _estudianteRepository;

        public EstudianteRepository(IGenericRepository<Estudiante> estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }
        public IEnumerable<Estudiante> GetAll() => _estudianteRepository.Get();
        public Estudiante GetById(int id) => _estudianteRepository.GetById(id);

        public void Create(Estudiante estudiante) => _estudianteRepository.Add(estudiante);
        public void Update(Estudiante estudiante) => _estudianteRepository.Update(estudiante);
        public void Delete(int id) => _estudianteRepository.Delete(id);

        public bool CheckEstudiante(string documentNumber) => _estudianteRepository.Any(e => e.Identificacion == documentNumber);
    }
}
