using Application.Interfaces.UseCases;
using Application.UseCases;
using Autofac;
using Domain.AggregatesModel;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.API.Configuration
{
    internal class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CursoRepository>()
                .As<ICursoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EstudianteRepository>()
                .As<IEstudianteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EstudianteCursoRepository>()
                .As<IEstudianteCursoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetCurso>()
                .As<IGetCurso>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetEstudiante>()
                .As<IGetEstudiante>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetEstudianteCurso>()
                .As<IGetEstudianteCurso>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EstudianteCommand>()
                .As<IEstudianteCommand>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EstudianteCursoCommand>()
                .As<IEstudianteCursoCommand>()
                .InstancePerLifetimeScope();          
        }
    }
}
