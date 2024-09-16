using Microsoft.AspNetCore.Mvc;
using BLL = Movie_BLL.Entities;
using Movie_Common.Repositories;
using Movie_API.Models;
using Movie_API.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository<BLL.Person> _personRepository;

        public PersonController(IPersonRepository<BLL.Person> personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpPost("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public IActionResult SetActor(int id, SetActorPost body)
        {
            try
            {
                _personRepository.SetRole(id, body.MovieId, body.CharacterName);
                return CreatedAtAction("GetDetailed", "Movie", new { id = body.MovieId }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }


        // GET: api/<PersonController>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessContentModel<IEnumerable<Person>>), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get()
        {
            try
            {
                return Ok(
                    new SuccessContentModel<IEnumerable<Person>>()
                    {
                        Result = _personRepository.Get().Select(e => e.ToModel())
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_personRepository.Get(id).ToModel());
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post(PersonPost value)
        {
            try
            {
                int id = _personRepository.Create(value.ToBLL());
                return CreatedAtAction(nameof(Get), new { id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PersonPost value)
        {
            try
            {
                _personRepository.Update(id, value.ToBLL());
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _personRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }
    }
}
