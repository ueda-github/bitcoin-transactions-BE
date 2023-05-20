using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crypto_restapi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace crypto_restapi.Controllers
{
   //[Microsoft.AspNetCore.Authorization.Authorize]

    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly cryptocurrency_integrationContext _context;
        public IConfiguration _configuration;

        public UsersController(cryptocurrency_integrationContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

            // PUT: api/Products/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> PutUsers(int id, Users users)
        {

          
            //context.Entry(users).State = EntityState.Modified;
            var userById = await  _context.Users.FindAsync(id);

            if (users.Username == "" || users.Username == null)
            {

                userById.api_key = users.api_key;
            } 
            else 
            {

                if (id != users.UserId)
                {
                    return BadRequest();
                }

                userById.Username = users.Username;
                userById.Email = users.Email;
                userById.DateExpirationToken = userById.DateExpirationToken;
                userById.access_token = userById.access_token;
                userById.PhoneNumber = users.PhoneNumber;
                userById.api_key = users.api_key;

                    if(users.Password=="")
			        {
                        userById.Password = userById.Password;

                    } else
			        {
                        userById.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
                    }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           

            return userById;
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
             if(users.isNewUser == 0)
			{
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(users.Password);

                var myUser = _context.Users
                       .FirstOrDefault(u => u.Username == users.Username);

                bool isPasswordVerified = false;

                if (myUser != null)
				{
                    isPasswordVerified = BCrypt.Net.BCrypt.Verify(users.Password, myUser.Password);
                }

                if (myUser != null && isPasswordVerified == true)    //User was found
                {
                    return myUser;
                }
                else    //User was not found
                {
                    return NotFound();
                }
            } else
			{
                Users lastUser =  _context.Users.OrderByDescending(u => u.UserId).FirstOrDefault();

                if(lastUser != null)
				{
                    string decryptedPassword = users.Password;
                    users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);

                    DateTime expirationDate = DateTime.Now.AddDays(45);
                    users.DateExpirationToken = expirationDate;
              
                    TokenController tokenObj = new TokenController(_configuration, _context);

                    var access_token = tokenObj.Post(users);

                    users.access_token = access_token;
                    
                    _context.Users.Add(users);

                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
                }else
				{
                    return null;
				}
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{userId}")]
        public async Task<ActionResult<Users>> DeleteUsers(int userId)
        {
            var users = await _context.Users.FindAsync(userId);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}