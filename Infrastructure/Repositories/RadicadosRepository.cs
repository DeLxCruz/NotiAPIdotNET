using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RadicadosRepository : GenericRepository<Radicados>, IRadicados
    {
        private readonly NotiAPIContext _context;

        public RadicadosRepository(NotiAPIContext context) : base(context)
        {
            _context = context;
        }
    }
}