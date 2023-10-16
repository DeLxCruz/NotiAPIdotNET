using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class RolVsMaestro : BaseEntity
{
    [Required]
    public long IdRol { get; set; }
    public Rol Roles { get; set; }

    [Required]
    public long IdMaestro { get; set;}
    public ModulosMaestros ModulosMaestros { get; set; }
}