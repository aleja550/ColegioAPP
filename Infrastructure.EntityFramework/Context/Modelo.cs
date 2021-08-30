using Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework
{
    public class Modelo
    {
        internal static void Generate(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstudianteConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CursoConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstudianteCurso).Assembly);
        }

        public class EstudianteCursoConfig : IEntityTypeConfiguration<EstudianteCurso>
        {
            public void Configure(EntityTypeBuilder<EstudianteCurso> estudianteCursoConfig)
            {
                estudianteCursoConfig.ToTable("EstudianteCurso")
                    .HasKey(e => e.Id)
                    .HasName("Id");

                estudianteCursoConfig.Property(e => e.IdEstudiante)
                    .HasColumnName("IdEstudiante")
                    .IsRequired(true);
                estudianteCursoConfig.Property(e => e.IdCurso)
                    .HasColumnName("IdCurso")
                    .IsRequired(true);
                estudianteCursoConfig.Property(e => e.NotaFinal)
                    .HasColumnName("NotaFinal")
                    .HasColumnType("numeric(3,2)")
                    .IsRequired(false);
            }
        }

        public class CursoConfig : IEntityTypeConfiguration<Curso>
        {
            public void Configure(EntityTypeBuilder<Curso> cursoConfig)
            {
                cursoConfig.ToTable("Curso")
                    .HasKey(e => e.Id)
                    .HasName("Id");

                cursoConfig.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(60)
                    .IsRequired(true);
                cursoConfig.Property(e => e.NumeroCreditos)
                    .HasColumnName("NumeroCreditos")
                    .IsRequired(true);
            }
        }

        public class EstudianteConfig : IEntityTypeConfiguration<Estudiante>
        {
            public void Configure(EntityTypeBuilder<Estudiante> estudianteConfig)
            {
                estudianteConfig.ToTable("Estudiante")
                    .HasKey(e => e.Id)
                    .HasName("Id");

                estudianteConfig.Property(e => e.TipoIdentificacion)
                    .HasColumnName("TipoIdentificacion")
                    .HasMaxLength(2)
                    .IsRequired(true);
                estudianteConfig.Property(e => e.Identificacion)
                    .HasColumnName("Identificacion")
                    .HasMaxLength(15)
                    .IsRequired(true);
                estudianteConfig.Property(e => e.Nombre1)
                    .HasColumnName("Nombre1")
                    .HasMaxLength(20)
                    .IsRequired(true);
                estudianteConfig.Property(e => e.Nombre2)
                    .HasColumnName("Nombre2")
                    .HasMaxLength(20)
                    .IsRequired(false);
                estudianteConfig.Property(e => e.Apellido1)
                    .HasColumnName("Apellido1")
                    .HasMaxLength(20)
                    .IsRequired(true);
                estudianteConfig.Property(e => e.Apellido2)
                    .HasColumnName("Apellido2")
                    .HasMaxLength(20)
                    .IsRequired(false);
                estudianteConfig.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(50)
                    .IsRequired(false);
                estudianteConfig.Property(e => e.Celular)
                    .HasColumnName("Celular")
                    .HasMaxLength(20)
                    .IsRequired(false);
                estudianteConfig.Property(e => e.Direccion)
                    .HasColumnName("Direccion")
                    .HasMaxLength(50)
                    .IsRequired(false);
                estudianteConfig.Property(e => e.Ciudad)
                    .HasColumnName("Ciudad")
                    .HasMaxLength(50)
                    .IsRequired(true);                
            }
        }
    }
}
