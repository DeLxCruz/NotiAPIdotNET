using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class FormatosConfiguration : IEntityTypeConfiguration<Formatos>
    {
        public void Configure(EntityTypeBuilder<Formatos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("Formatos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.NombreFormato)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");
            
            builder.Property(e => e.FechaModificacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}