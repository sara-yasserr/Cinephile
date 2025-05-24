using AutoMapper;
using CinephileProject.DTOs.MovieDTOs;
using CinephileProject.Models;
using CinephileProject.Services;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        MovieService movieService;
        public MovieController(unitOfWork unitOfWork, IMapper mapper,MovieService movieService )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.movieService = movieService;
        }

        #region Basic CRUD
        [HttpGet]
        public List<ReadMovieDTO> GetAll()
        {
            List<Movie> movies = unitOfWork.movieRepo.GetAll();
            return mapper.Map<List<ReadMovieDTO>>(movies);
            //return unitOfWork.movieRepo.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddMovieDTO movieDTO)
        {

            if (movieDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var movie = movieService.AddMovieWithDetails(movieDTO);
                //movie.BackgroundPath= await movieService.UploadBackground(movieDTO.BackgroundFile);
                //movie.PosterPath = await movieService.UploadPoster(movieDTO.PosterFile);
                
                return CreatedAtAction("getById", new { id = movie.Id }, movie);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddMovieDTO movieDTO)
        {
            var movieExist = unitOfWork.movieRepo.GetById(id);
            if (movieExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(movieDTO,movieExist);
                //unitOfWork.movieRepo.Update(movieExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await unitOfWork.movieRepo.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadMovieDTO>(movie));
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Movie movie = unitOfWork.movieRepo.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            unitOfWork.movieRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(movie);
        }
        #endregion

        #region extra
        [HttpGet("Genres/{id:int}")]
        public List<string> GetGenres(int id)
        {
            var movie = unitOfWork.movieRepo.GetById(id);
            return movie.Genres.Select(m => m.Name).ToList();
        }
        #endregion
    }
}
