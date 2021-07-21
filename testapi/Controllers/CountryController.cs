using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testapi.Models;
using testapi.Data;

namespace testapi.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly MinCtx _ctx;

        public CountryController(MinCtx context)
        {
            _ctx = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _ctx.Countries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(short id)
        {
            return await _ctx.Countries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Country entity)
        {
            if (entity == null)
            {
                return BadRequest("Modelo es nulo");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ctx.Countries.Add(entity);
            await _ctx.SaveChangesAsync();

            return entity.IdCountry;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(short id, [FromBody] Country entity)
        {
            if (entity == null)
            {
                return BadRequest("Modelo es nulo");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Country upd = await _ctx.Countries.FirstOrDefaultAsync(e => e.IdCountry == id);
            if (upd == null)
            {
                return NotFound();
            }
            upd.Language = entity.Language;
            upd.Name = entity.Name;
            upd.Acronym = entity.Acronym;
            _ctx.Countries.Update(upd);
            await _ctx.SaveChangesAsync();

            return upd.IdCountry;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            Country upd = await _ctx.Countries.FirstOrDefaultAsync(e => e.IdCountry == id);
            if (upd == null)
            {
                return NotFound();
            }
            _ctx.Countries.Remove(upd);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
