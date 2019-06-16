using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.DomainEntity.Contracts.IInfrastructre;
using CS.DomainEntity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _service = null;

        public UsersController(IUserServices userServices)
        {
            _service = userServices;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            User user = _service.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _service.AddorUpdate(user);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _service.AddorUpdate(user);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            User user = _service.GetById(id);

            if (user == null)
                return NotFound();

            _service.Delete(id);

            return Ok();
        }

    }
}