using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class HiloRespuestaNotificacion : BaseEntity
{
    [Required, MaxLength(80)]
    public string NombreTipo { get; set; }
    public ICollection<BlockChain> BlockChains { get; set; }
    public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }
}