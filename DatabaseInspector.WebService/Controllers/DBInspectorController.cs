using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DatabaseInspector;

namespace DatabaseInspector.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBInspectorController : ControllerBase
    {
        protected DBInspector dbService;

        public DBInspectorController()
        {
            dbService = new DBInspector();
        }

        // GET: api/DBInspector
        [HttpGet]
        public IEnumerable<Database> Get()
        {
            dbService.SearchForDBs();
            return dbService.GetAllDBs();
        }

        // GET: api/DBInspector/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/DBInspector
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/DBInspector/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
