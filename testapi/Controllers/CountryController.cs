using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testapi.DTOs;
using testapi.Data;
using testapi.Services;

namespace testapi.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _ctx;

        public CountryController(MinCtx context)
        {
            _ctx = new CountryService(context);
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> Get()
        {
            return await _ctx.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> Get(short id)
        {
            return await _ctx.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CountryDTO entity)
        {
            if (entity == null)
            {
                return BadRequest("Modelo es nulo");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _ctx.Create(entity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(short id, [FromBody] CountryDTO entity)
        {
            if (entity == null)
            {
                return BadRequest("Modelo es nulo");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _ctx.Update(id, entity);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _ctx.Delete(id);
        }
    }
}
