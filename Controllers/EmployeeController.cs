using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectPFE.Interface.IController;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;
using ProjectPFE.Services;

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EmployeeController : ControllerBase, IEmployeeController
        
    {
        private readonly IEmpolyeeServices _ServicesEmployee;
        private IConfiguration _config;
        private readonly ApplicationContext _context;
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;
        #region Constructeur
        public EmployeeController(
            IEmpolyeeServices serviceemployee,
            ApplicationContext context,
            SignInManager<Employee> signInManager,
            UserManager<Employee> userManager,
            IConfiguration config
        )
        {
            _ServicesEmployee = serviceemployee;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }
        #endregion
        //done***********************

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Employee userAuth)
        {
            //add user(mail,password)
            var userToAdd = userAuth;new User { UserName = "admin", Email = "admin@gmail.com" };
             string pass = "Admin123-@";
             var resultuserToAdd = await _userManager.CreateAsync(userAuth, userAuth.Password);

            //User user1 = await _context.User.FindAsync(userAuth.Email, userAuth.PasswordHash);
            //sign in  by(mail,passwd)
            var result = await _signInManager.PasswordSignInAsync(userAuth.UserName, userAuth.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                //trouver le nom de personne qui est connecter(et pour ne pas génerer un nv id dans le claim)
                Employee user = await _userManager.FindByNameAsync(userAuth.UserName);
                // pass the claims to our token
                //I have added a username,psswd as claimed into the token.
                //claim de type tableau

                var claim = new Claim[]
                                {
                                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                                    new Claim(ClaimTypes.NameIdentifier, "owner|" + user.Id.ToString())
                                };
                var tokenString = GenerateJSONWebToken(claim);
                //retourner le token   
                return Ok(new
                {
                    user = user,
                    Token = tokenString
                });
            }

            throw new Exception("user est null");
        }

        //Claim userInfo
        private string GenerateJSONWebToken(IEnumerable<Claim> claims)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //secret key c est le clé definie dans le appset.json
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("SecretKey")));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(9999),
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] string id)
        {
            try
            {
                IQueryable<Employee_Site> employee_Sites = _context.Employees_Sites.Where(u => u.employeeId == id);
                foreach(Employee_Site employee_Site in employee_Sites) {
                    try
                    {
                        _context.Employees_Sites.Remove(employee_Site);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                _context.SaveChanges();
                return Ok(await _ServicesEmployee.DeleteAsync(id));
            }
            catch (Exception ex )
            {
                return NotFound();
            }
        }

        //Done **************************
        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _ServicesEmployee.GetAllAsync();
            
        }
        //done************************
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] string id)
        {
           
            try
            {
               return Ok(await _ServicesEmployee.GetByIdAsync(id));
            }
            catch (Exception )
            {
                return NotFound();
           
            }
        }

        //**********
        [HttpPost]
        public async Task<IActionResult> PostEmployeeAsync([FromBody] Employee employee)
        {
            var employeeToAdd = await _userManager.CreateAsync(employee, employee.Password);
            // var createdEntity = await _ServicesEmployee.AddAsync(employee);
            if (employeeToAdd.Succeeded)
            {
                return CreatedAtAction(nameof(GetEmployeeAsync), new { id = employee.Id }, employee);
            }
            throw new Exception("user est null");
        }

        
        // ********************
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(string id, [FromBody] Employee employee)
        {
            // TODO: Add an null id detection
            try
            {
                await _ServicesEmployee.UpdateAsync(id, employee);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }




    }
}