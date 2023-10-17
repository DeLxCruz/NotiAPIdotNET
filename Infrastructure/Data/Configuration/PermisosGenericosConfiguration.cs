using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class PermisosGenericosConfiguration : IEntityTypeConfiguration<PermisosGenericos>
    {
        public void Configure(EntityTypeBuilder<PermisosGenericos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("PermisosGenericos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.NombrePermiso)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}