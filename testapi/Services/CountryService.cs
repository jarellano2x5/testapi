using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using testapi.Data;
using testapi.DTOs;
using testapi.Models;

namespace testapi.Services
{
    public class CountryService
    {
        private readonly MinCtx _ctx;

        public CountryService(MinCtx context)
        {
            _ctx = context;
        }

        public async Task<IEnumerable<CountryDTO>> GetAll()
        {
            return await _ctx.Countries
                .Select(e => new CountryDTO
                {
                    IdCountry = e.IdCountry,
                    Name = e.Name,
                    Acronym = e.Acronym,
                    Language = e.Language
                }).ToListAsync();
        }

        public async Task<CountryDTO> Get(short id)
        {
            return await _ctx.Countries
                .Select(e => new CountryDTO
                {
                    IdCountry = e.IdCountry,
                    Name = e.Name,
                    Acronym = e.Acronym,
                    Language = e.Language
                }).FirstOrDefaultAsync(e => e.IdCountry == id);
        }

        public async Task<int> Create(CountryDTO model)
        {
            Country entity = new Country
            {
                IdCountry = model.IdCountry,
                Name = model.Name,
                Acronym = model.Acronym,
                Language = model.Language
            };

            _ctx.Countries.Add(entity);
            await _ctx.SaveChangesAsync();

            return entity.IdCountry;
        }

        public async Task<int> Update(short id, CountryDTO model)
        {
            Country upd = await _ctx.Countries.FirstOrDefaultAsync(e => e.IdCountry == id);
            if (upd == null)
            {
                return await Task.FromException<int>(new Exception("No encontrado"));
            }
            upd.Language = model.Language;
            upd.Name = model.Name;
            upd.Acronym = model.Acronym;
            _ctx.Countries.Update(upd);
            await _ctx.SaveChangesAsync();

            return upd.IdCountry;
        }

        public async Task<bool> Delete(int id)
        {
            Country upd = await _ctx.Countries.FirstOrDefaultAsync(e => e.IdCountry == id);
            if (upd == null)
            {
                return await Task.FromException<bool>(new Exception("No encontrado"));
            }
            _ctx.Countries.Remove(upd);
            await _ctx.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteForName(int id)
        {
            Country upd = await _ctx.Countries.FirstOrDefaultAsync(e => e.IdCountry == id);
            if (upd == null)
            {
                return await Task.FromException<bool>(new Exception("No encontrado"));
            }
            _ctx.Countries.Remove(upd);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
