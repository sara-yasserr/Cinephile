using AutoMapper;
using CinephileProject.DTOs.TicketDTOs;
using CinephileProject.Models;
using CinephileProject.Services;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public TicketController(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        #region Basic CRUD
        [HttpGet]
        public List<ReadTicketDTO> GetAll()
        {
            List<Ticket> Tickets = unitOfWork.ticketRepo.GetAll();
            return mapper.Map<List<ReadTicketDTO>>(Tickets);
            //return unitOfWork.ticketRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Post(AddTicketDTO TicketDTO)
        {

            if (TicketDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Ticket ticket = mapper.Map<Ticket>(TicketDTO);
                unitOfWork.ticketRepo.Add(ticket);
                //ticket.Price = calcPriceService.CalculatePrice(ticket.Seat.Screen.Type, ticket.Seat.Type, ticket.Showtime.StartTime);

                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = ticket.Id }, ticket);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddTicketDTO TicketDTO)
        {
            var TicketExist = unitOfWork.ticketRepo.GetById(id);
            if (TicketExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(TicketDTO, TicketExist);
                //unitOfWork.ticketRepo.Update(TicketExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = mapper.Map<ReadTicketDTO>(await unitOfWork.ticketRepo.FindAsync(id));
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Ticket Ticket = unitOfWork.ticketRepo.GetById(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            unitOfWork.ticketRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(Ticket);
        }
        #endregion
    }
}
