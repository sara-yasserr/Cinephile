using AutoMapper;
using CinephileProject.DTOs.GenreDTOs;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IMapper mapper;
        unitOfWork unitOfWork;
        public GenreController(IMapper mapper, unitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        #region Basic CRUD
        [HttpGet]
        public List<ReadGenreDTO> GetAll()
        {
            List<Genre> genres = unitOfWork.genreRepo.GetAll();
            return mapper.Map<List<ReadGenreDTO>>(genres);
        }

        [HttpPost]
        public IActionResult Post(AddGenreDTO genreDTO)
        {

            if (genreDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Genre genre = mapper.Map<Genre>(genreDTO);
                unitOfWork.genreRepo.Add(genre);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = genre.Id }, genre);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddGenreDTO genreDTO)
        {
            var genreExist = unitOfWork.genreRepo.GetById(id);
            if (genreExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(genreDTO,genreExist);
                //unitOfWork.genreRepo.Update(genreExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var genre = unitOfWork.genreRepo.GetById(id);
            if(genre == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadGenreDTO>(genre));
        }
        [HttpDelete("{id}:int")]
        public IActionResult Delete(int id)
        {
            var genre = unitOfWork.genreRepo.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            unitOfWork.genreRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(genre);
        }
        #endregion
    }
}
