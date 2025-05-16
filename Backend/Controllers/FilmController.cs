using AutoMapper;
using LetterboxdProject.DTOs.FilmDTOs;
using LetterboxdProject.Models;
using LetterboxdProject.UnitsOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetterboxdProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public FilmController(unitOfWork unitOfWork, IMapper mapper) 
        { 
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<FilmDTO> GetAll()
        {
            List<Film> films = unitOfWork.filmRepo.GetAll();
            return mapper.Map<List<FilmDTO>>(films);
            //return unitOfWork.filmRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Post(FilmDTO filmDTO)
        {

            if (filmDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Film film = mapper.Map<Film>(filmDTO);
                unitOfWork.filmRepo.Add(film);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = film.Id }, film);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("id:int")]
        public IActionResult Put(int id, FilmDTO filmDTO)
        {
            var filmExist = unitOfWork.filmRepo.GetById(id);
            if (filmExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var film = mapper.Map<Film>(filmDTO);
                unitOfWork.filmRepo.Update(film);
                unitOfWork.SaveChanges();
                return NoContent();
             }
                else return BadRequest(ModelState);
        }
        

        [HttpGet("id:int")]
        public async Task<Film> GetById(int id)
        {
           return await unitOfWork.filmRepo.FindAsync(id);
        }
        [HttpDelete("id:int")]
        public IActionResult Delete(int id)
        {
            Film film = unitOfWork.filmRepo.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            unitOfWork.filmRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(film);
        }
    }
}
