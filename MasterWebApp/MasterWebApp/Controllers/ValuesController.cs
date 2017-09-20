using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.Service;
using Template.Repository;
using Microsoft.Extensions.Configuration;
using Template.DTO;

namespace MasterWebApp.Controllers
{
    //[Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/values/v{ver:apiVersion}")]
    public class ValuesController : Controller
    {
        private ISampleService _sampleService;
        public IConfigurationRoot Configuration { get; }
        private readonly DataBaseContext _ctx;

        public ValuesController(DataBaseContext dbContext)
        {
            _ctx = dbContext;
        }
        
        [HttpGet]
        public SampleDTO Get()
        {
            IUnitOfWork _unitofWork = new UnitOfWork(_ctx);
            ISampleRepository _sampleRepository = new SampleRepository(_ctx);
            _sampleService = new SampleService(_unitofWork, _sampleRepository);
            return _sampleService.GetById(1);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
