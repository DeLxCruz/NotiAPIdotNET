using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class MaestrosVsSubModulosConfiguration : IEntityTypeConfiguration<MaestrosVsSubModulos>
    {
        public void Configure(EntityTypeBuilder<MaestrosVsSubModulos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("MaestrosVsSubModulos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.ModulosMaestros)
                 .WithMany(p => p.MaestrosVsSubModulos)
                 .HasForeignKey(p => p.IdMaestro);

            builder.HasOne(p => p.SubModulos)
                 .WithMany(p => p.MaestrosVsSubModulos)
                 .HasForeignKey(p => p.IdSubmodulo);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");
            
            builder.Property(e => e.FechaModificacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}