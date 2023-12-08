﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("Colaborador")]
    public class Colaborador
    {
        [Column("ColaboradorId")]
        [Display(Name = "Colaborador")]
        public int ColaboradorId { get; set; }

        [Column("ColaboradorNome")]
        [Display(Name = "Nome do Colaborador")]
        public string ColaboradorNome { get; set; } = string.Empty;

        [Column("ColaboradorCpf")]
        [Display(Name = "Cpf do Colaborador")]
        public string ColaboradorCpf { get; set; } = string.Empty;

        [Column("ColaboradorSexo")]
        [Display(Name = "Sexo do Colaborador")]
        public string ColaboradorSexo { get; set; } = string.Empty;


        [Column("ColaboradorTelefone")]
        [Display(Name = "Telefone do Colaborador")]
        public string ColaboradorTelefone { get; set; } = string.Empty;


        [ForeignKey("CidadeId")]
        [Display(Name = "Nome da Cidade")]
        public int CidadeId { get; set; }

        public Cidade? Cidade { get; set; }



        [ForeignKey("TipoColaborador")]
        [Display(Name = "Nome do Colaborador")]
        public int TipoColaboradorId { get; set; }

        public TipoColaborador? TipoColaborador { get; set; }
    }
}
