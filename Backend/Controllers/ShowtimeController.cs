using AutoMapper;
using CinephileProject.DTOs.ShowtimeDTO;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimeController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public ShowtimeController(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region Basic CRUD
        [HttpGet]
        public List<ReadShowtimeDTO> GetAll()
        {
            List<Showtime> Showtimes = unitOfWork.showtimeRepo.GetAll();
            return mapper.Map<List<ReadShowtimeDTO>>(Showtimes);
        }

        [HttpPost]
        public IActionResult Post(AddShowtimeDTO showtimeDTO)
        {

            if (showtimeDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var showtime = mapper.Map<Showtime>(showtimeDTO);
                unitOfWork.showtimeRepo.Add(showtime);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = showtime.Id }, showtime);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddShowtimeDTO showtimeDTO)
        {
            var showtimeExist = unitOfWork.showtimeRepo.GetById(id);
            if (showtimeExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(showtimeDTO, showtimeExist);
                //unitOfWork.showtimeRepo.Update(showtimeExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var showtime = await unitOfWork.showtimeRepo.FindAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadShowtimeDTO>(showtime));
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var showtime = unitOfWork.showtimeRepo.GetById(id);
            if (showtime == null)
            {
                return NotFound();
            }
            unitOfWork.showtimeRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(showtime);
        }
        #endregion

        #region extra
        [HttpGet("movie/{id:int}")]
        public List<ReadShowtimeDTO> GetShowtimesByMovie(int id)
        {
            var allShowtimes = unitOfWork.showtimeRepo.GetAll();
            var showtimes = allShowtimes.Where(sh=>sh.MovieId==id) .ToList();
            return mapper.Map<List<ReadShowtimeDTO>>(showtimes);

        }
        #endregion
    }
}
