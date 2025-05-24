using AutoMapper;
using CinephileProject.DTOs.ReadScreenDTOs;
using CinephileProject.DTOs.ScreenDTOs;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinephileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        unitOfWork unitOfWork;
        IMapper mapper;
        public ScreenController(unitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #region Basic CRUD
        [HttpGet]
        public List<ReadScreenDTO> GetAll()
        {
            List<Screen> screens = unitOfWork.screenRepo.GetAll();
            return mapper.Map<List<ReadScreenDTO>>(screens);
        }

        [HttpPost]
        public IActionResult Post(AddScreenDTO screenDTO)
        {

            if (screenDTO == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var screen = mapper.Map<Screen>(screenDTO);
                unitOfWork.screenRepo.Add(screen);
                unitOfWork.SaveChanges();
                return CreatedAtAction("getById", new { id = screen.Id }, screen);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AddScreenDTO screenDTO)
        {
            var screenExist = unitOfWork.screenRepo.GetById(id);
            if (screenExist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(screenDTO,screenExist);
                //unitOfWork.screenRepo.Update(screenExist);
                unitOfWork.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var screen =await unitOfWork.screenRepo.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ReadScreenDTO>(screen));
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Screen screen = unitOfWork.screenRepo.GetById(id);
            if (screen == null)
            {
                return NotFound();
            }
            unitOfWork.screenRepo.Delete(id);
            unitOfWork.SaveChanges();
            return Ok(screen);
        }
        #endregion
    }
}
