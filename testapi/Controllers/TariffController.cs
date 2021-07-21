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
    public class TariffController : ControllerBase
    {
        private readonly MinCtx _ctx;

        public TariffController(MinCtx context)
        {
            _ctx = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Tariff>> Get()
        {
            return await _ctx.Tariffs.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tariff>> Get(short id)
        {
            return await _ctx.Tariffs.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Tariff entity)
        {
            if (entity == null)
            {
                return BadRequest("Modelo es nulo");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ctx.Tariffs.Add(entity);
            await _ctx.SaveChangesAsync();

            return entity.IdCountry;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(short id, [FromBody] Tariff entity)
        {
            if (entity == null)
            {
                return BadRequest("Modelo es nulo");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Tariff upd = await _ctx.Tariffs.FirstOrDefaultAsync(e => e.IdTariff == id);
            if (upd == null)
            {
                return NotFound();
            }
            upd.IdCountry = entity.IdCountry;
            upd.Initial = entity.Initial;
            upd.Name = entity.Name;
            upd.Active = entity.Active;
            _ctx.Tariffs.Update(upd);
            await _ctx.SaveChangesAsync();

            return upd.IdCountry;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            Tariff upd = await _ctx.Tariffs.FirstOrDefaultAsync(e => e.IdTariff == id);
            if (upd == null)
            {
                return NotFound();
            }
            _ctx.Tariffs.Remove(upd);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
