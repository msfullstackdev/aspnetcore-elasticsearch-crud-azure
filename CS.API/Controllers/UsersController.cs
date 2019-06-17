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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var res = await _service.GetAllAsync();

            return Ok(res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            User user =await _service.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);

        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

           await _service.AddorUpdateAsync(user);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            user.Id = id;

           await _service.AddorUpdateAsync(user);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            User user =await _service.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await _service.DeleteAsync(id);

            return Ok();
        }

    }
}