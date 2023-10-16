using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
public class Auditoria : BaseEntity
{
    [Required, MaxLength(50)]
    public string NombreUsuario { get; set; }
    public long DescAccion { get; set; }
    public ICollection<BlockChain> BlockChains { get; set; }
}