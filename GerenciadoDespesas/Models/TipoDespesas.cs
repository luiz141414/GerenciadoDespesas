﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Models
{
    public class TipoDespesas
    {
        public int TipoDespesaId { get; set; }
        [Required (ErrorMessage ="Campo obrigatorio.")]
        [StringLength(50, ErrorMessage = "Use menos caracteres.")]
        [Remote("TipoDespesaExiste","TipoDespesas")]//validação remota
        public string Nome { get; set; }
        public ICollection<Despesas> Despesas { get; set; }
    }
}
