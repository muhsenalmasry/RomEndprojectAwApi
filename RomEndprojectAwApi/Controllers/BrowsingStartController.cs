using Microsoft.AspNetCore.Mvc;
using RomEndprojectAwApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RomEndprojectAwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrowsingStartController : ControllerBase
    {
        private readonly romdatabaseawContext _dbContext;

        public BrowsingStartController(romdatabaseawContext context)
        {
            _dbContext = context;
        }
        // GET: api/<BrowserStartController>
        [HttpGet]
        public List<BrowsingStart> Get()
        {
            //LopputyöContext db = new LopputyöContext();
            return _dbContext.BrowsingStarts.ToList();
        }

        // GET api/<BrowserStartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BrowserStartController>
        [HttpPost]
        public IActionResult Post([FromBody] BrowsingStart value)
        {
            try
            {
                //LopputyöContext db = new LopputyöContext();
                _dbContext.BrowsingStarts.Add(value);
                _dbContext.SaveChanges();
                return new OkObjectResult("Added successfully");
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }

        }

        // PUT api/<BrowserStartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrowserStartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
