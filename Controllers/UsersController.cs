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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ApplicationContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UsersController(ApplicationContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration config
           )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public async Task<List<User>> GetUser()
        {
            return await _userManager.Users.ToListAsync();
            //return _context.User;
        }
        /*
      [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User userAuth)
        {
         
            var userToAdd = userAuth;new User { UserName = "adminsecondaire", Email = "admin@gmail.com" };
            string pass = "Admin123-@4";
            var resultuserToAdd = await _userManager.CreateAsync(userAuth, userAuth.Password);

           
         
            var result = await _signInManager.PasswordSignInAsync(userAuth.UserName, userAuth.Password, true, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                //trouver le nom de personne qui est connecter(et pour ne pas génerer un nv id dans le claim)
                User user = await _userManager.FindByNameAsync(userAuth.UserName);
               

                var claim = new Claim[]
                                {
                                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                                    new Claim(ClaimTypes.NameIdentifier, "owner|" + user.Id.ToString())
                                };
                var tokenString = GenerateJSONWebToken(claim);
                
                return Ok(new
                {
                    user = user,
                    Token = tokenString
                });
            }

            throw new Exception("user est null");
        } 
        */
    
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






    






        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var user = await _context.User.FindAsync(id);
            var user = "";
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUser([FromRoute] string id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = ""; // await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            //_context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(string id)
        {
            return false; // _context.User.Any(e => e.Id == id);
        }
    }
}