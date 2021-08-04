using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Models
{
    public class Despesas
    {
        public int DespesaId { get; set; }
        public int MesId { get; set; }//chave estrangeira
        public  Meses Meses { get; set; }//PROPRIEDADE NAVEGACIONAL
        public int TipoDespesasId { get; set; }//chave estrangeira
        public TipoDespesas TipoDespesas { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor invalido.")]
        public double Valor { get; set; }
    }
}
