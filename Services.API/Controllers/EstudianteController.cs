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
    public class EstudianteController : ControllerBase
    {
        private readonly IGetEstudiante _getEstudiante;
        private readonly IEstudianteCommand _estudianteCommand;
        private readonly ILogger<EstudianteController> _logger;

        public EstudianteController(IGetEstudiante getEstudiante, IEstudianteCommand estudianteCommand, ILogger<EstudianteController> logger)
        {
            _getEstudiante = getEstudiante;
            _estudianteCommand = estudianteCommand;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Estudiante>> Get()
        {
            try
            {
                List<Estudiante> estudiantes = _getEstudiante.GetAll().ToList();

                return Ok(estudiantes);
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
        public ActionResult<Estudiante> GetById(int id)
        {
            if (id == 0)
            {
                throw new HandlerException(400, "El id es necesario para la peticion");
            }

            try
            {
                Estudiante estudiante = _getEstudiante.GetById(id);

                return Ok(estudiante);
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
        public ActionResult<Estudiante> Create(Estudiante estudiante)
        {
            if (estudiante == null)
            {
                throw new HandlerException(400, "Es necesario tener el cuerpo del estudianteCurso");
            }
            try
            {
                _estudianteCommand.Create(estudiante);

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

        [HttpPut]
        public ActionResult<Estudiante> Update(Estudiante estudiante)
        {
            if (estudiante == null)
            {
                throw new HandlerException(400, "Es necesario tener el cuerpo del estudianteCurso");
            }
            try
            {
                _estudianteCommand.Update(estudiante);

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
