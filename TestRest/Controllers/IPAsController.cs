using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestRest.Managers;
using TestRest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPAsController : ControllerBase
    {
        private IPAsManager _manager = new IPAsManager();
        // GET: api/IPAs
        [HttpGet]
        public IEnumerable<IPA> GetAll([FromQuery] double? minimumProof, [FromQuery] double? maximumProof)
        {
            return _manager.GetAll(minimumProof, maximumProof);
        }

        // GET api/<IPAsController>/5
        [HttpGet("{id}")]
        public IPA Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<IPAsController>
        [HttpPost]
        public IPA Post([FromBody] IPA value)
        {
            return _manager.Add(value); 
        }

        // PUT api/<IPAsController>/5
        [HttpPut("{id}")]
        public IPA Put(int id, [FromBody] IPA value)
        {
            return _manager.Update(id, value);
        }

        // DELETE api/<IPAsController>/5
        [HttpDelete("{id}")]
        public IPA Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
