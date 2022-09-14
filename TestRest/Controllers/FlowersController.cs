using Microsoft.AspNetCore.Mvc;
using TestRest.Managers;
using TestRest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private FlowersManager _manager = new FlowersManager();

        // GET: api/<FlowersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Flower>> Get()
        {
            IEnumerable<Flower> flowerList = _manager.GetAll();
            if (flowerList.Count() == 0)
            {
                return NoContent();
            }
            return Ok();
        }

        // GET api/<FlowersController>/5
        [HttpGet("{id}")]
        public Flower? Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<FlowersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Flower> Post([FromBody] Flower newFlower)
        {
            try
            {
                Flower createdFlower = _manager.Add(newFlower);
                return Created("api/flowers/" + createdFlower.Id, createdFlower);
            }
            catch (Exception ex)
          when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FlowersController>/5
        [HttpPut("{id}")]
        public Flower? Put(int id, [FromBody] Flower updates)
        {
            return _manager.Update(id, updates);
        }

        // DELETE api/<FlowersController>/5
        [HttpDelete("{id}")]
        public Flower? Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
