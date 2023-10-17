using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotifications.DTOs;
public class AuditoriaDTO
{
    public long Id { get; set; }
    public string NombreUsuario { get; set; }
    public DateOnly FechaCreacion { get; set; }
    public DateOnly FechaModificacion { get; set; }
}