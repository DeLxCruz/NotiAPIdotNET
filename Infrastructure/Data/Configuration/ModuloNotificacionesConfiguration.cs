using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class ModuloNotificacionesConfiguration : IEntityTypeConfiguration<ModuloNotificaciones>
    {
        public void Configure(EntityTypeBuilder<ModuloNotificaciones> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("ModuloNotificaciones");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.AsuntoNotificacion)
                 .IsRequired()
                 .HasMaxLength(80);

            builder.HasOne(p => p.EstadoNotificaciones)
                 .WithMany(p => p.ModulosNotificaciones)
                 .HasForeignKey(p => p.IdTipoNotificacion);

            builder.HasOne(p => p.Radicados)
                 .WithMany(p => p.ModuloNotificaciones)
                 .HasForeignKey(p => p.IdRadicado);

            builder.HasOne(p => p.EstadoNotificaciones)
                 .WithMany(p => p.ModulosNotificaciones)
                 .HasForeignKey(p => p.IdEstadoNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificaciones)
                 .WithMany(p => p.ModulosNotificaciones)
                 .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Formatos)
                 .WithMany(p => p.ModulosNotificaciones)
                 .HasForeignKey(p => p.IdFormato);

            builder.HasOne(p => p.TiposRequerimiento)
                 .WithMany(p => p.ModuloNotificaciones)
                 .HasForeignKey(p => p.IdRequerimiento);

            builder.Property(e => e.TextoNotificacion)
                 .HasMaxLength(2000);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(e => e.FechaModificacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}