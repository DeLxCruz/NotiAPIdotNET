using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotifications.DTOs
{
    public class BlockChainDTO
    {
        public long Id { get; set; }
        public long IdNotificacion { get; set; }
        public long IdAuditoria { get; set; }
        public string Hash { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public DateOnly FechaModificacion { get; set; }
        
    }
}