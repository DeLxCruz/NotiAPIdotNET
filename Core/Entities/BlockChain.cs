using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class BlockChain : BaseEntity
{
    [Required]
    public long IdTipoNotificacion { get; set; }
    public TipoNotificaciones TipoNotificaciones { get; set; }

    [Required]
    public long IdHiloRespuesta { get; set; }
    public HiloRespuestaNotificacion HiloRespuestaNotificacion { get; set; }

    [Required]
    public long IdAuditoria { get; set; }
    public Auditoria Auditoria { get; set; }
    
    [Required, MaxLength(100)]
    public string HashGenerado { get; set; }
    
}