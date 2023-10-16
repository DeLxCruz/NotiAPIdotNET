using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class EstadoNotificacion : BaseEntity
{
    [Required, MaxLength(50)]
    public string NombreEstado { get; set; }
    public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }
}