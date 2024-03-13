using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PisiTechSchool.Data;
using PisiTechSchool.Models;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;

namespace PisiTechSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly PisiTechSchoolContext _context;
        private IConfiguration _config;
        public ServicesController(PisiTechSchoolContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // POST: api/Services
        [HttpPost("SignUp")]
        public IActionResult PostService(string email, string Phone_number)
        {

            bool enteredemailAddress = ValidateEmail(email);

            if (enteredemailAddress == false) 
            {
                return BadRequest("Invalid email address");
            }

            var signup = _context.Service.FirstOrDefault(u => u.PhoneNumber == Phone_number || u.Email == email);
            
            if (signup != null)
            { 
                return Conflict("Account already exist");
            }

            var ser = new Service()
            {
                CreatedDate = System.DateTime.Today,
                PhoneNumber = Phone_number,
                Email = email,
              };
                       
            _context.Service.Add(ser);
             _context.SaveChanges();
            return Ok("Successfully Signed-up, your Service ID is: " + ser.ServiceId);

        }

        [HttpPost("[action]")]

        public ActionResult Login(int ServiceId, string Phone_number)
        {
            var currentUser = _context.Service.FirstOrDefault(u => u.ServiceId == ServiceId && u.PhoneNumber == Phone_number);
            if (currentUser == null)
            {
                return NotFound();
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, currentUser.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(GetToken(1)), //Get Token Expiry Period from Database
                signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new ObjectResult(new
            {
                access_token = jwt,
                token_type = "bearer",
                user_id = currentUser.ServiceId,
                
            });

        }
        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.ServiceId == id);
        }

        private int GetToken(int id)
        {
            var token = _context.TokenPeriod.FirstOrDefault(u => u.Id == id);
            if (token == null)
            {
                return 0;
            }
            int xx = token.ExpiryPeriod;

            return xx;
        }


        private bool ValidateEmail(string stremail)
        {
            string email = stremail;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            
                if (match.Success)
                {
                    return true;
                }

                else
                {
                    return false;
                }
        }
    


}
}
