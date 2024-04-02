using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyFlix.Data;
using SkyFlix.Dto;
using SkyFlix.Models;


namespace SkyFlix.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<MovieDto> GetMovies()
        {
            var movieDtos = _context.Movies.Include(c => c.Genre)
                                     .ToList()
                                     .Select(_mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public ActionResult<MovieDto> CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            var uri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}{HttpContext.Request.Path}{movieDto.Id}";

            return Created(new Uri(uri), movieDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}