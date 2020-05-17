using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<SerieModel> Get()
        {
            List<SerieModel> model = series.LeerTodos();
            return Ok(model);
        }

        // GET: api/Series/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<SerieModel> Get(int id)
        {
            if(id<0)
                return BadRequest();

            var v= series.LeerPorID(id);
            if(v == null)
                return NotFound();
            
            return Ok(v);
        }

        // POST: api/Series
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
