using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class Rol : BaseEntity
{
    [Required, MaxLength(100)]
    public string Nombre { get; set; }

    public ICollection<RolVsMaestro> RolVsMaestros { get; set; }
    public ICollection<GenericosVsSubModulos> GenericosVsSubModulos { get; set; }
}