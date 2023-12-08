using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinal.Models
{
    [Table("LocalRealizacao")]
    public class LocalRealizacao
    {
        [Column("LocalRealizacaoId")]
        [Display(Name = "Local de Realização")]
        public int LocalRealizacaoId { get; set; }


        [Column("LocalNomeId")]
        [Display(Name = "Nome do Local")]
        public string LocalNome { get; set; } = string.Empty;


        [ForeignKey("CidadeId")]
        [Display(Name = "Nome da Cidade")]
        public int CidadeId { get; set; }

        public Cidade? Cidade { get; set; }
    }
}
