using Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Infrastructure.EntityFramework
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Modelo.Generate(modelBuilder);
        }

        public void Commit()
        {
            try
            {
                Validate();
                SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"DbUpdateException error details - {ex?.InnerException?.InnerException?.Message}");

                foreach (var eve in ex.Entries)
                {
                    sb.AppendLine($"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated");
                }
            }
        }

        public void Validate()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }
        }
    }
}
