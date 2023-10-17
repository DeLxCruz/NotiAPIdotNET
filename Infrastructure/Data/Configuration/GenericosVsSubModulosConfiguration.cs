using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class GenericosVsSubModulosConfiguration : IEntityTypeConfiguration<GenericosVsSubModulos>
    {
        public void Configure(EntityTypeBuilder<GenericosVsSubModulos> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("GenericosVsSubModulos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.PermisosGenericos)
                 .WithMany(p => p.GenericosVsSubModulos)
                 .HasForeignKey(p => p.IdGenericos);

            builder.HasOne(p => p.MaestrosVsSubModulos)
                 .WithMany(p => p.GenericosVsSubModulos)
                 .HasForeignKey(p => p.IdSubModulos);

            builder.HasOne(p => p.Roles)
                 .WithMany(p => p.GenericosVsSubModulos)
                 .HasForeignKey(p => p.IdRol);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");
            
            builder.Property(e => e.FechaModificacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}