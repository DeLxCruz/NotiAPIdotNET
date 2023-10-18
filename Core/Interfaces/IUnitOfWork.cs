using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IAuditoria Auditorias { get; }
    IBlockChain BlockChains { get; }
    IEstadoNotificacion EstadoNotificaciones { get; }
    IFormatos Formatos { get; }
    IGenericosVsSubModulos GenericosVsSubModulos { get; }
    IHiloRespuestaNotificacion HiloRespuestaNotificaciones { get; }
    IMaestrosVsSubmodulos MaestrosVsSubmodulos { get; }
    IModuloNotificaciones ModuloNotificaciones { get; }
    IModulosMaestros ModulosMaestros { get; }
    IPermisosGenericos PermisosGenericos { get; }
    IRadicados Radicados { get; }
    IRol Roles { get; }
    IRolVsMaestro RolVsMaestros { get; }
    ISubModulos SubModulos { get; }
    ITipoNotificaciones TipoNotificaciones { get; }
    ITipoRequerimiento TipoRequerimientos { get; }
    Task<int> SaveAsync();
}