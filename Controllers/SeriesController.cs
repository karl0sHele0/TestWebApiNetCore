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
        public IEnumerable<SerieModel> Get()
        {
            List<SerieModel> model = series.LeerTodos();
            return model;
        }

        // GET: api/Series/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
