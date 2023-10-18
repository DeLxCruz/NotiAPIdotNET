using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NotiAPIContext _context;
        private IAuditoria _auditorias;
        private IBlockChain _blockChains;
        private IEstadoNotificacion _estadoNotificaciones;
        private IFormatos _formatos;
        private IGenericosVsSubModulos _genericosVsSubModulos;
        private IHiloRespuestaNotificacion _hiloRespuestaNotificaciones;
        private IMaestrosVsSubmodulos _maestrosVsSubmodulos;
        private IModuloNotificaciones _moduloNotificaciones;
        private IModulosMaestros _modulosMaestros;
        private IPermisosGenericos _permisosGenericos;
        private IRadicados _radicados;
        private IRol _roles;
        private IRolVsMaestro _rolVsMaestros;
        private ISubModulos _subModulos;
        private ITipoNotificaciones _tipoNotificaciones;
        private ITipoRequerimiento _tipoRequerimientos;

        public UnitOfWork(NotiAPIContext context)
        {
            _context = context;
        }

        public IAuditoria Auditorias
        {
            get{
                if (_auditorias == null)
                {
                    _auditorias = new AuditoriaRepository(_context);
                }
                return _auditorias;
            }
        }

        public IBlockChain BlockChains
        {
            get{
                if (_blockChains == null)
                {
                    _blockChains = new BlockChainRepository(_context);
                }
                return _blockChains;
            }
        }

        public IEstadoNotificacion EstadoNotificaciones
        {
            get{
                if (_estadoNotificaciones == null)
                {
                    _estadoNotificaciones = new EstadoNotificacionRepository(_context);
                }
                return _estadoNotificaciones;
            }
        }

        public IFormatos Formatos
        {
            get{
                if (_formatos == null)
                {
                    _formatos = new FormatosRepository(_context);
                }
                return _formatos;
            }
        }

        public IGenericosVsSubModulos GenericosVsSubModulos
        {
            get{
                if (_genericosVsSubModulos == null)
                {
                    _genericosVsSubModulos = new GenericosVsSubmodulosRepository(_context);
                }
                return _genericosVsSubModulos;
            }
        }

        public IHiloRespuestaNotificacion HiloRespuestaNotificaciones
        {
            get{
                if (_hiloRespuestaNotificaciones == null)
                {
                    _hiloRespuestaNotificaciones = new HiloRespuestaNotificacionRepository(_context);
                }
                return _hiloRespuestaNotificaciones;
            }
        }

        public IMaestrosVsSubmodulos MaestrosVsSubmodulos
        {
            get{
                if (_maestrosVsSubmodulos == null)
                {
                    _maestrosVsSubmodulos = new MaestrosVsSubmodulosRepository(_context);
                }
                return _maestrosVsSubmodulos;
            }
        }

        public IModuloNotificaciones ModuloNotificaciones
        {
            get{
                if (_moduloNotificaciones == null)
                {
                    _moduloNotificaciones = new ModuloNotificacionesRepository(_context);
                }
                return _moduloNotificaciones;
            }
        }

        public IModulosMaestros ModulosMaestros
        {
            get{
                if (_modulosMaestros == null)
                {
                    _modulosMaestros = new ModulosMaestrosRepository(_context);
                }
                return _modulosMaestros;
            }
        }

        public IPermisosGenericos PermisosGenericos
        {
            get{
                if (_permisosGenericos == null)
                {
                    _permisosGenericos = new PermisosGenericosRepository(_context);
                }
                return _permisosGenericos;
            }
        }

        public IRadicados Radicados
        {
            get{
                if (_radicados == null)
                {
                    _radicados = new RadicadosRepository(_context);
                }
                return _radicados;
            }
        }

        public IRol Roles
        {
            get{
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public IRolVsMaestro RolVsMaestros
        {
            get{
                if (_rolVsMaestros == null)
                {
                    _rolVsMaestros = new RolVsMaestroRepository(_context);
                }
                return _rolVsMaestros;
            }
        }

        public ISubModulos SubModulos
        {
            get{
                if (_subModulos == null)
                {
                    _subModulos = new SubModulosRepository(_context);
                }
                return _subModulos;
            }
        }

        public ITipoNotificaciones TipoNotificaciones
        {
            get{
                if (_tipoNotificaciones == null)
                {
                    _tipoNotificaciones = new TipoNotificacionesRepository(_context);
                }
                return _tipoNotificaciones;
            }
        }

        public ITipoRequerimiento TipoRequerimientos
        {
            get{
                if (_tipoRequerimientos == null)
                {
                    _tipoRequerimientos = new TipoRequerimientoRepository(_context);
                }
                return _tipoRequerimientos;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}
