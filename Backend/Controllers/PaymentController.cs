using AutoMapper;
using CinephileProject.DTOs.PaymentDTOs;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public PaymentController(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region Basic CRUD
        [HttpGet]
        public List<ReadPaymentDTO> GetAll()
        {
            List<Payment> payments = unitOfWork.paymentRepo.GetAll();
            return mapper.Map<List<ReadPaymentDTO>>(payments);
            //return unitOfWork.paymentRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Post(AddPaymentDTO paymentDTO)
        {

            if (paymentDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Payment payment = mapper.Map<Payment>(paymentDTO);
                unitOfWork.paymentRepo.Add(payment);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = payment.Id }, payment);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddPaymentDTO paymentDTO)
        {
            var paymentExist = unitOfWork.paymentRepo.GetById(id);
            if (paymentExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(paymentDTO, paymentExist);
                //unitOfWork.paymentRepo.Update(payment);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = mapper.Map<ReadPaymentDTO>(await unitOfWork.paymentRepo.FindAsync(id));
            if(payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Payment payment = unitOfWork.paymentRepo.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            unitOfWork.paymentRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(payment);
        }
        #endregion
    }
}
