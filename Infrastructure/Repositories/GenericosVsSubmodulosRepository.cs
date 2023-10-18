using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenericosVsSubmodulosRepository : GenericRepository<GenericosVsSubModulos>, IGenericosVsSubModulos
    {
        private readonly NotiAPIContext _context;

        public GenericosVsSubmodulosRepository(NotiAPIContext context) : base(context)
        {
            _context = context;
        }
    }
}