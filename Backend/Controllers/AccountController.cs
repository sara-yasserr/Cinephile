using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LetterboxdProject.AccountDTOs;
using LetterboxdProject.Models;
using LetterboxdProject.UnitsOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Generators;

namespace LetterboxdProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly IAuthService _authService;
        //private readonly IMapper mapper;
        AppDbContext db ;
        unitOfWork unitOfWork;

        public AccountController( AppDbContext db, unitOfWork unitOfWork)
        {
            this.db = db;
            this.unitOfWork = unitOfWork;
        }

        #region Login
        [HttpPost("login")]
        public  async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user =await db.Users
              .FirstOrDefaultAsync(u => u.Username == loginDTO.username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.password, user.PasswordHash))
                return Unauthorized("Inavlid username or password");
            
                var userData = new List<Claim>();
                userData.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                userData.Add(new Claim(ClaimTypes.Name, user.Username));
                userData.Add(new Claim(ClaimTypes.Role, user.Role));
               user.LastLogin = DateTime.UtcNow;
               db.Users.Update(user);
               await db.SaveChangesAsync();

            var key = "hellloooooooooooooooooooooooooooo";
                var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                var signingCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);

                var tokenObj = new JwtSecurityToken(
                    claims: userData,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signingCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenObj);

              return Content(tokenString, "text/plain");
        }
        #endregion
        #region Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await db.Users.AnyAsync(u => u.Username == registerDTO.Username))
            {
                return BadRequest("Username is already taken.");
            }

            var user = new User
            {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                Role = "User",
                JoinDate = DateTime.UtcNow
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return Ok();
        }
        #endregion
        [HttpGet]
        public List<User> GetAll()
        {
           return unitOfWork.userRepo.GetAll();
        }
    }

}
