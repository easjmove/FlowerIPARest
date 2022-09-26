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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<IPA>> GetAll(
            [FromQuery] double? minimumProof,
            [FromQuery] double? maximumProof,
            [FromHeader] string? amount)
        {
            //if (amount == null)
            //{
            //    return BadRequest("Amount must be set");
            //}

            int parsedAmount;
            if (amount != null)
            {
                if (!int.TryParse(amount, out parsedAmount))
                {
                    return BadRequest("Amount must be a number!");
                }
                if (parsedAmount <= 0)
                {
                    return BadRequest("Amount must be a positive number");
                }
            }

            IEnumerable<IPA> result = _manager.GetAll(minimumProof, maximumProof, null);
            if (result.Count() == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // GET api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<IPA> Get(int id)
        {
            IPA? result = _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<IPAsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<IPA> Post([FromBody] IPA newIPA)
        {
            try
            {
                IPA createdIPA = _manager.Add(newIPA);
                return Created("api/ipas/" + createdIPA.Id, createdIPA);
            }
            catch (Exception ex)
          when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<IPA> Put(int id, [FromBody] IPA updates)
        {
            try
            {
                IPA? result = _manager.Update(id, updates);
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

        // DELETE api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<IPA> Delete(int id)
        {
            IPA? result = _manager.Delete(id);
            if (result != null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
