using AutoMapper;
using CinephileProject.DTOs.SeatDTOs;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public SeatController(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region Basic CRUD 
        [HttpGet]
        public List<ReadSeatDTO> GetAll()
        {
            List<Seat> seats = unitOfWork.seatRepo.GetAll();
            return mapper.Map<List<ReadSeatDTO>>(seats);
        }

        [HttpPost]
        public IActionResult Post(AddSeatDTO seatDTO)
        {

            if (seatDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var seat = mapper.Map<Seat>(seatDTO);
                unitOfWork.seatRepo.Add(seat);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = seat.Id }, seat);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddSeatDTO seatDTO)
        {
            var seatExist = unitOfWork.seatRepo.GetById(id);
            if (seatExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(seatDTO, seatExist);
                //unitOfWork.seatRepo.Update(seatExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seat = await unitOfWork.seatRepo.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadSeatDTO>(seat));
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var seat = unitOfWork.seatRepo.GetById(id);
            if (seat == null)
            {
                return NotFound();
            }
            unitOfWork.seatRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(seat);
        }
        #endregion
    }
}
