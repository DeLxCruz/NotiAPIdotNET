using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class ModuloNotificaciones : BaseEntity
{
    [Required, MaxLength(50)]
    public string AsuntoNotificacion { get; set; }

    [Required]
    public long IdTipoNotificacion { get; set; }
    public TipoNotificaciones TipoNotificaciones { get; set; }

    [Required]
    public long IDRadicado { get; set; }
    public Radicados Radicados { get; set; }

    [Required]
    public long IdEstadoNotificacion { get; set; }
    public EstadoNotificacion EstadoNotificaciones { get; set; }

    [Required]
    public long IdHiloRespuesta { get; set; }
    public HiloRespuestaNotificacion HiloRespuestaNotificaciones { get; set; }

    [Required]
    public long IdFormato { get; set; }
    public Formatos Formatos { get; set; }

    [Required]
    public long IdRequerimiento { get; set; }
    public TipoRequerimiento TiposRequerimiento { get; set; }

    [MaxLength(2000)]
    public string TextoNotificacion { get; set; }
}