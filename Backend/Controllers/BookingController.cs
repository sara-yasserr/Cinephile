using AutoMapper;
using CinephileProject.DTOs.BookingDTOs;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public BookingController(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region Basic CRUD
        [HttpGet]
        public List<ReadBookingDTO> GetAll()
        {
            List<Booking> Bookings = unitOfWork.bookingRepo.GetAll();
            return mapper.Map<List<ReadBookingDTO>>(Bookings);
            //return unitOfWork.BookingRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Post(AddBookingDTO BookingDTO)
        {

            if (BookingDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Booking Booking = mapper.Map<Booking>(BookingDTO);
                unitOfWork.bookingRepo.Add(Booking);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = Booking.Id }, Booking);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddBookingDTO BookingDTO)
        {
            var BookingExist = unitOfWork.bookingRepo.GetById(id);
            if (BookingExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(BookingDTO,BookingExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await unitOfWork.bookingRepo.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadBookingDTO>(booking));
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Booking Booking = unitOfWork.bookingRepo.GetById(id);
            if (Booking == null)
            {
                return NotFound();
            }
            unitOfWork.bookingRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(Booking);
        }
        #endregion
    }
}
