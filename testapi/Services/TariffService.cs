using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testapi.Models;
using testapi.DTOs;
using testapi.Data;

namespace testapi.Services
{
    public class TariffService
    {
        private readonly MinCtx _ctx;

        public TariffService(MinCtx context)
        {
            _ctx = context;
        }

        public async Task<IEnumerable<TariffDTO>> GetAll()
        {
            return await _ctx.Tariffs.Select(e => new TariffDTO
            {
                IdTariff = e.IdTariff,
                Name = e.Name,
                IdCountry = e.IdCountry,
                Initial = e.Initial,
                Active = e.Active
            }).ToListAsync();
        }

        public async Task<TariffDTO> Get(short id)
        {
            return await _ctx.Tariffs.Select(e => new TariffDTO
            {
                IdTariff = e.IdTariff,
                Name = e.Name,
                IdCountry = e.IdCountry,
                Initial = e.Initial,
                Active = e.Active
            }).FirstOrDefaultAsync(e => e.IdTariff == id);
        }

        public async Task<int> Create(TariffDTO model)
        {
            Tariff entity = new Tariff
            {
                IdTariff = model.IdTariff,
                Name = model.Name,
                IdCountry = model.IdCountry,
                Initial = model.Initial,
                Active = model.Active
            };
            _ctx.Tariffs.Add(entity);
            await _ctx.SaveChangesAsync();

            return entity.IdCountry;
        }
    }
}
