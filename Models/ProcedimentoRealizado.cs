using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinal.Models
{
    [Table("ProcedimentoRealizado")]
    public class ProcedimentoRealizado
    {

        [Column("ProcedimentoRealizadoId")]
        [Display(Name = "Realização do Procedimento")]
        public int Id { get; set; }


        [ForeignKey("CidadeId")]
        [Display(Name = "Nome da Cidade")]
        public int? CidadeId { get; set; }

        public Cidade? Cidade { get; set; }

        [ForeignKey("TipoProcedimentoId")]
        [Display(Name = "Tipo do Procedimento")]
        public int? TipoProcedimentoId { get; set; }

        public TipoProcedimento? TipoProcedimento { get; set; }


        [ForeignKey("TipoColaborador")]
        [Display(Name = "Nome do Colaborador")]
        public int? TipoColaboradorId { get; set; }

        public TipoColaborador? TipoColaborador { get; set; }

        [ForeignKey("LocalRealizacaoId")]
        [Display(Name = "Nome do Local")]
        public int? LocalRealizacaoId { get; set; }

        public LocalRealizacao? LocalRealizacao { get; set; }

        [Column("DataRealizacao")]
        [Display(Name = "Data de Realizaoção")]

        public DateTime DataRealizacao { get; set; }


        [Column("ObservacaoRealizacao")]
        [Display(Name = "Observação do Realizador")]
        public string ObservacaoRealizacao { get; set; } = string.Empty;
    }
}
