using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class DespesasMap : IEntityTypeConfiguration<Despesas>
    {
        public void Configure(EntityTypeBuilder<Despesas>builder)
        {
            builder.HasKey(d => d.DespesaId);//primeiro se define a chave primaria
            builder.Property(d => d.Valor).IsRequired();//depois vc define o parametro e o método
            //depois vc define os relacionamentos entre as classes
            builder.HasOne(d => d.Meses).WithMany(d => d.Despesas).HasForeignKey(d => d.MesId);
            builder.HasOne(d => d.TipoDespesas).WithMany(d => d.Despesas).HasForeignKey(d => d.TipoDespesasId);
            builder.ToTable("Despesas");
        }

    }
}
