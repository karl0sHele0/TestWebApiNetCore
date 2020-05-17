//Ochoa Medrano Carlos Heleodoro
//Ingeniería Web
//17-05-2020
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Examen.Models;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISerieTVRepository series;
        public SeriesController()
        {
            series = new SqliteSeriesRepository();
        }

        // GET: api/Series
        [HttpGet]
        public ActionResult<List<SerieModel>> Get()
        {
            var listaSereies = series.LeerTodos();
            return Ok(listaSereies);
        }

        // GET: api/Series/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<SerieModel> Get(int id)
        {
            if(id<0)
                return BadRequest();

            var serie = series.LeerPorID(id);
            if(serie == null)
                return NotFound();
            
            return Ok(serie);
        }

        // POST: api/Series
        [HttpPost]
        public ActionResult Post([FromBody] SerieModel model)
        {
            series.Crear(model);
            return Ok();
        }

        // PUT: api/Series/5
        //[HttpPut("{id}")]
        public ActionResult Put([FromBody] SerieModel model)
        {
            if(model.ID < 0)
                return BadRequest();

            var serie = series.LeerPorID(model.ID);
            if(serie == null)
                return NotFound();

            series.Actualizar(model);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
             if(id<0)
                return BadRequest();

            var serie = series.LeerPorID(id);
            if(serie == null)
                return NotFound();

            series.Borrar(id);
            return Ok();
        }
    }
}
