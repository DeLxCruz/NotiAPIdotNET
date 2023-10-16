using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class MaestrosVsSubModulos : BaseEntity
{
    [Required]
    public long IdMaestro { get; set; }
    public ModulosMaestros ModulosMaestros { get; set; }

    [Required]
    public long IdSubmodulo { get; set; }
    public SubModulos SubModulos { get; set; }

    public ICollection<GenericosVsSubModulos> GenericosVsSubModulos { get; set; }
}