using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EscolaMapping : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Escola : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Escola);

            // 1 : N => Escola : Turmas
            builder.HasMany(f => f.Turmas)
                .WithOne(p => p.Escola)
                .HasForeignKey(p => p.Id);

            builder.ToTable("Fornecedores");
        }
    }
}