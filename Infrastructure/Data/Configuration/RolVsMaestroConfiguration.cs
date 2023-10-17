using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class RolVsMaestroConfiguration : IEntityTypeConfiguration<RolVsMaestro>
    {
        public void Configure(EntityTypeBuilder<RolVsMaestro> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad
            // utilizando el objeto builder
            builder.ToTable("RolVsMaestro");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.Roles)
                 .WithMany(p => p.RolVsMaestros)
                 .HasForeignKey(p => p.IdRol);

            builder.HasOne(p => p.ModulosMaestros)
                 .WithMany(p => p.RolVsMaestros)
                 .HasForeignKey(p => p.IdMaestro);

            builder.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(e => e.FechaModificacion)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}