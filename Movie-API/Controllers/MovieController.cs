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

        public MovieController(IMovieRepository<BLL.Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_movieRepository.Get().Select(e => e.ToModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_movieRepository.Get(id).ToModel());
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel() { Message = ex.Message });
            }
        }

        // POST api/<MovieController>
        [HttpPost]
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
