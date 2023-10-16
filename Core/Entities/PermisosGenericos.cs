using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class PermisosGenericos : BaseEntity
{
    [Required, MaxLength(50)]
    public string NombrePermiso { get; set; }

    public ICollection<GenericosVsSubModulos> GenericosVsSubModulos { get; set; }
}
