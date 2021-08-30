using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.UseCases;
using Domain.AggregatesModel;
using Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Services.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstudianteCursoController : ControllerBase
    {
        private readonly IGetEstudianteCurso _getEstudianteCurso;
        private readonly IEstudianteCursoCommand _estudianteCursoCommand;
        private readonly ILogger<EstudianteCursoController> _logger;

        public EstudianteCursoController(IGetEstudianteCurso getEstudianteCurso, IEstudianteCursoCommand estudianteCursoCommand, ILogger<EstudianteCursoController> logger)
        {
            _getEstudianteCurso = getEstudianteCurso;
            _estudianteCursoCommand = estudianteCursoCommand;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<EstudianteCurso>> Get()
        {
            try
            {
                List<EstudianteCurso> estudianteCursos = _getEstudianteCurso.GetAll().ToList();

                return Ok(estudianteCursos);
            }
            catch (HandlerException ex)
            {
                _logger.LogError($"{DateTime.Now.Ticks} -  {ex.MessageException}", ex, GetType().Name);
                return new ObjectResult(new { Error = $"{ex.MessageException} - {DateTime.Now.Ticks} " }) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.Ticks} - Unhandled exception: ", ex, GetType().Name);
                return new ObjectResult(new { Error = $"{DateTime.Now.Ticks} - Unhandled exception: {ex.StackTrace}, {ex.Message}, {ex.InnerException}" }) { StatusCode = 500 };
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EstudianteCurso> GetById(int id)
        {
            if (id == 0)
            {
                throw new HandlerException(400, "El id es necesario para la peticion");
            }

            try
            {
                EstudianteCurso estudianteCurso = _getEstudianteCurso.GetById(id);

                return Ok(estudianteCurso);
            }
            catch (HandlerException ex)
            {
                _logger.LogError($"{DateTime.Now.Ticks} -  {ex.MessageException}", ex, GetType().Name);
                return new ObjectResult(new { Error = $"{ex.MessageException} - {DateTime.Now.Ticks} " }) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.Ticks} - Unhandled exception: ", ex, GetType().Name);
                return new ObjectResult(new { Error = $"{DateTime.Now.Ticks} - Unhandled exception: {ex.StackTrace}, {ex.Message}, {ex.InnerException}" }) { StatusCode = 500 };
            }
        }

        [HttpPost]
        public ActionResult<EstudianteCurso> Create(EstudianteCurso estudianteCurso)
        {
            if (estudianteCurso == null)
            {
                throw new HandlerException(400, "Es necesario tener el cuerpo del estudianteCurso");
            }
            try
            {
                 _estudianteCursoCommand.Create(estudianteCurso);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (HandlerException ex)
            {
                _logger.LogError($"{DateTime.Now.Ticks} -  {ex.MessageException}", ex, GetType().Name);
                return new ObjectResult(new { Error = $"{ex.MessageException} - {DateTime.Now.Ticks} " }) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now.Ticks} - Unhandled exception: ", ex, GetType().Name);
                return new ObjectResult(new { Error = $"{DateTime.Now.Ticks} - Unhandled exception: {ex.StackTrace}, {ex.Message}, {ex.InnerException}" }) { StatusCode = 500 };
            }
        }      
    }
}
