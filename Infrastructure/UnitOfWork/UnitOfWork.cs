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
