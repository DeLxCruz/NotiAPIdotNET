using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class GenericosVsSubModulos : BaseEntity
{
    [Required]
    public long IdGenericos { get; set; }
    public PermisosGenericos PermisosGenericos { get; set; }

    [Required]
    public long IdSubModulos { get; set; }
    public MaestrosVsSubModulos MaestrosVsSubModulos { get; set; }

    [Required]
    public long IdRol { get; set; }
    public Rol Roles { get; set; }
}