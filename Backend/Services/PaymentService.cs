using AutoMapper;
using CinephileProject.DTOs.PaymentDTOs;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;

namespace CinephileProject.Services
{
    //mock payment
    public class PaymentService
    {
        private readonly unitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly Random random = new Random();

        public PaymentService(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Payment> ProcessPaymentAsync(AddPaymentDTO paymentDTO)
        {
            await Task.Delay(random.Next(500, 2000)); 

            bool isSuccess = random.Next(0, 10) > 2;

            var payment = mapper.Map<Payment>(paymentDTO);

            unitOfWork.paymentRepo.Add(payment);
            await unitOfWork.SaveChangesAsync();

            return payment;
        }
    }
}
