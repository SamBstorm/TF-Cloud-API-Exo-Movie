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
    public class MovieController : ControllerBase
    {
        private IMovieRepository<BLL.Movie> _movieRepository;

        public MovieController(IMovieRepository<BLL.Movie> movieRepository, IPersonRepository<BLL.Person> personRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/<MovieController>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessContentArrayModel<IEnumerable<Movie>, Movie>), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Produces("text/json","text/xml")]
        public IActionResult Get()
        {
            try
            {
                return Ok(
                    new SuccessContentArrayModel<IEnumerable<Movie>, Movie>() { 
                        Result = _movieRepository.Get().Select(e => e.ToModel()) 
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        [ProducesResponseType<SuccessContentModel<Movie>>(200)]
        [ProducesResponseType<ErrorModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get(int id)
        {
            try
            {
                
                return Ok(
                    new SuccessContentModel<Movie>()
                    {
                        Result = _movieRepository.Get(id).ToModel()
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }
        [HttpGet("detailed/{id}")]
        [ProducesResponseType<SuccessContentModel<Movie>>(200)]
        [ProducesResponseType<ErrorModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult GetDetailed(int id)
        {
            try
            {

                return Ok(
                    new SuccessContentModel<Movie>()
                    {
                        Result = _movieRepository.Get(id).ToDetailedModel()
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // POST api/<MovieController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType<ErrorModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Post(MoviePost value)
        {
            try
            {
                int id = _movieRepository.Create(value.ToBLL());
                return CreatedAtAction(nameof(Get), new { id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType<ErrorModel>(400)]
        [Produces("text/json","text/xml")]
        public IActionResult Put(int id, MoviePost value)
        {
            try
            {
                _movieRepository.Update(id, value.ToBLL());
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType<ErrorModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Delete(int id)
        {
            try
            {
                _movieRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }
    }
}
