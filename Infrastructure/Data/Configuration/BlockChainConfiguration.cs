using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("BlockChain");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.TipoNotificaciones)
                 .WithMany(p => p.BlockChains)
                 .HasForeignKey(p => p.IdTipoNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificacion)
                 .WithMany(p => p.BlockChains)
                 .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Auditoria)
                 .WithMany(p => p.BlockChains)
                 .HasForeignKey(p => p.IdAuditoria);

            builder.Property(e => e.HashGenerado)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(e => e.FechaModificacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}