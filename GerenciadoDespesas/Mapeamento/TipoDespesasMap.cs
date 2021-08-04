using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class TipoDespesasMap : IEntityTypeConfiguration<TipoDespesas>
    {
        public void Configure(EntityTypeBuilder<TipoDespesas>builder)

        {
            //COLOCANDO AS RELAÇOES
            builder.HasKey(td => td.TipoDespesaId);
            builder.Property(td => td.Nome).HasMaxLength(50).IsRequired();
            builder.HasMany(td => td.Despesas).WithOne(td => td.TipoDespesas).HasForeignKey(td => td.TipoDespesasId);
            builder.ToTable("TipoDespesas");//NOME DA TABELA
        }
        

        
    }
}
