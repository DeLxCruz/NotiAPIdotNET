using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class ModulosMaestrosConfiguration : IEntityTypeConfiguration<ModulosMaestros>
    {
        public void Configure(EntityTypeBuilder<ModulosMaestros> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("ModulosMaestros");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.NombreModulo)
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