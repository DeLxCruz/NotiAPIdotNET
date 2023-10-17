using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotifications.DTOs;
using AutoMapper;
using Core.Entities;

namespace ApiNotifications.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auditoria, AuditoriaDTO>().ReverseMap();
        CreateMap<EstadoNotificacion, EstadoNotificacionDTO>().ReverseMap();
        CreateMap<Formatos, FormatosDTO>().ReverseMap();
        CreateMap<HiloRespuestaNotificacion, HiloRespuestaNotificacionDTO>().ReverseMap();
        CreateMap<ModulosMaestros, ModulosMaestrosDTO>().ReverseMap();
        CreateMap<PermisosGenericos, PermisosGenericosDTO>().ReverseMap();
        CreateMap<Radicados, RadicadosDTO>().ReverseMap();
        CreateMap<Rol, RolDTO>().ReverseMap();
        CreateMap<SubModulos, SubModulosDTO>();
        CreateMap<TipoNotificaciones, TipoNotificacionesDTO>().ReverseMap();
        CreateMap<TipoRequerimiento, TipoRequerimientoDTO>().ReverseMap();
    }
}