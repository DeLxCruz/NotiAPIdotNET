using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotifications.DTOs
{
    public class ModuloNotificacionesDTO
    {
        public long Id { get; set; }
        public string AsuntoNotificacion { get; set; }
        public long IdTipoNotificacion { get; set; }
        public long IdRadicado { get; set; }
        public long IdEstadoNotificacion { get; set; }
        public long IdHiloRespuesta { get; set; }
        public long IdFormato { get; set; }
        public long IdRequermiemnto { get; set; }
        public string TextoNotificacion { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public DateOnly FechaModificacion { get; set; }
    }
}