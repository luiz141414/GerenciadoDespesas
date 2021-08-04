using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class MesesMap: IEntityTypeConfiguration<Meses>
    {
        public void Configure(EntityTypeBuilder<Meses>builder)
        {
            builder.HasKey(m => m.MesId);//chave primaria
            builder.Property(m => m.MesId).ValueGeneratedNever();
            builder.Property(m => m.Nome).HasMaxLength(50).IsRequired();
            //muitos(HasMany) para um(WithOne)
            builder.HasMany(m => m.Despesas).WithOne(m => m.Meses).HasForeignKey(m => m.MesId).OnDelete(DeleteBehavior.Cascade);
            //um(HasOne) para um(HasOne)
            builder.HasOne(m => m.Salarios).WithOne(m => m.Meses).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Meses");//nome da tabela

        }
    }
}
