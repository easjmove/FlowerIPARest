using Microsoft.AspNetCore.Cors;
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
        private readonly FlowersManager _manager = new FlowersManager();

        // GET: api/<FlowersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Flower>> GetAll(
            [FromQuery] string? speciesFilter, 
            [FromQuery] string? colorFilter, 
            [FromHeader] string? amount)
        {
            if (amount == null) {
                return BadRequest("Amount must be set");
            }

            int parsedAmount;
            if (!int.TryParse(amount, out parsedAmount ))
            {
                return BadRequest("Amount must be a number!");
            }
            if (parsedAmount <= 0) {
                return BadRequest("Amount must be a positive number");
            }

            IEnumerable<Flower> flowerList = _manager.GetAll(speciesFilter, colorFilter, parsedAmount);
            if (flowerList.Count() == 0)
            {
                return NoContent();
            }
            return Ok(flowerList);
        }

        // GET api/<FlowersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Flower> Get(int id)
        {
            Flower? result = _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Flower> Put(int id, [FromBody] Flower updates)
        {
            try
            {
                Flower? result = _manager.Update(id, updates);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
          when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FlowersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Flower> Delete(int id)
        {
            Flower? result = _manager.Delete(id);
            if (result != null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
