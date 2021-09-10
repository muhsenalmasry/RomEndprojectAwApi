using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RomEndprojectAwApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RomEndprojectAwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly romdatabaseawContext _dbContext;
        private readonly IConfiguration _configuration;
        static string secret;
        public DeviceController(romdatabaseawContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = context;
            secret = _configuration.GetSection("Secret").GetSection("HashSalt").Value;
        }

        // GET: api/<DeviceController>
        [HttpGet]
        public IActionResult Get(string DeviceID, string Password)
        {
            var passHash = Hash(Password);
            var deviceExists = _dbContext.Devices.Where(d => d.DeviceId == DeviceID && d.Password == passHash).FirstOrDefault();
            if (deviceExists != null)
            {
                return new OkObjectResult("true");
            }
            return new OkObjectResult("false");
        }

        //// GET api/<DeviceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DeviceController>
        [HttpPost]
        public IActionResult Post([FromBody] Device value)
        {
            try
            {
                value.Password = Hash(value.Password);
                _dbContext.Devices.Add(value);
                _dbContext.SaveChanges();
                return new OkObjectResult("true");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("false");
            }
        }

        // PUT api/<DeviceController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DeviceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, string password)
        {
            try
            {
                var passHash = Hash(password);
                var device = _dbContext.Devices.Where(d => d.DeviceId == id && d.Password == passHash).FirstOrDefault();
                _dbContext.Devices.Remove(device);
                _dbContext.SaveChanges();
                return new OkObjectResult("true");
            }
            catch(Exception e)
            {
                return new OkObjectResult("false");
            }
        }


        public static string Hash(string value)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(secret),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public static bool Validate(string value, string hash)
            => Hash(value) == hash;
    }
}
