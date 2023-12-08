using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinal.Models
{
    [Table("Procedimento")]
    public class Procedimento
    {

        [Column("ProcedimentoId")]
        [Display(Name = "Procedimento")]
        public int ProcedimentoId { get; set; }


        [Column("ProcedimentoNomeId")]
        [Display(Name = "Nome do Procedimento")]
        public string ProcedimentoNome { get; set; } = string.Empty;


        [Column("ProcedimentoObservacaoId")]
        [Display(Name = "Observação")]
        public string ProcedimentoObservacaoId { get; set; } = string.Empty;


        [ForeignKey("TipoProcedimentoId")]
        [Display(Name = "Tipo do Procedimento")]
        public int TipoProcedimentoId { get; set; }

        public TipoProcedimento? TipoProcedimento { get; set; }
    }
}