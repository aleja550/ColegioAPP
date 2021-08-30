using Application.Interfaces.UseCases;
using Domain.AggregatesModel;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IGetCurso _getCurso;
        private readonly ILogger<CursoController> _logger;

        public CursoController(IGetCurso getCurso, ILogger<CursoController> logger)
        {
            _getCurso = getCurso;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Curso>> Get()
        {
            try
            {
                List<Curso> cursos = _getCurso.GetAll().ToList();
                return Ok(cursos);
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
        public ActionResult<Curso> GetById(int id)
        {
            if (id == 0)
            {
                throw new HandlerException(400, "The id is necessary for the request.");
            }

            try
            {
                Curso curso = _getCurso.GetById(id);

                return Ok(curso);
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
