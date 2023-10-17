using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotifications.DTOs;
public class ModulosMaestrosDTO
{
    public long Id { get; set; }
    public string NombreModulo { get; set; }
    public DateOnly FechaCreacion { get; set; }
    public DateOnly FechaModificacion { get; set; }
}