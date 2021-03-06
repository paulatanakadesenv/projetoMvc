﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Servicos
{
    public class ServicoRegistroVendas
    {
        private readonly VendasWebMvcContext _context;

        public ServicoRegistroVendas(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVenda>> EncontrarDataAsync(DateTime? dataMinima, DateTime? dataMaxima)
        {
            var resultado = from obj in _context.RegistroVenda select obj;
            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMinima.Value);
            }

            if (dataMaxima.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataMaxima.Value);
            }

            return await resultado
                .Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, RegistroVenda>>> EncontrarAgrupamentoDataAsync(DateTime? dataMinima, DateTime? dataMaxima)
        {
            var resultado = from obj in _context.RegistroVenda select obj;
            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMinima.Value);
            }

            if (dataMaxima.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataMaxima.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor
                .Departamento).OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }

    }
}