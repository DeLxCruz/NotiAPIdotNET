using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class SubModulos : BaseEntity
{
    [Required, MaxLength(80)]
    public string NombreSubModulo { get; set; }

    public ICollection<MaestrosVsSubModulos> MaestrosVsSubModulos { get; set; }
}
