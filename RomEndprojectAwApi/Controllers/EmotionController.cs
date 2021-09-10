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
    public class EmotionController : ControllerBase
    {

        private readonly romdatabaseawContext _dbContext;

        public EmotionController(romdatabaseawContext context)
        {
            _dbContext = context;
        }
        // GET: api/<EmotionController>
        [HttpGet]
        public List<Emotion> Get()
        {
            //LopputyöContext db = new LopputyöContext();
            return _dbContext.Emotions.ToList();
        }

        // GET api/<EmotionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmotionController>
        [HttpPost]
        public void Post([FromBody] Emotion emotion)
        {
            //LopputyöContext db = new LopputyöContext();
            _dbContext.Emotions.Add(emotion);
            _dbContext.SaveChanges();
        }

        // PUT api/<EmotionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmotionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
