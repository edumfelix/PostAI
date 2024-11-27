using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace PostAIWebAPI.Models
{
    [Table("dadoscliente")]
    [Index(nameof(Id), IsUnique = true)]
    public class DadosCliente
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("telefone")]
        public string? Telefone { get; set; }
        [Column("site")]
        public string? Site { get; set; }
        [Column("cores")]
        public JsonDocument? Cores { get; set; }
        [Column("logo")]
        public byte[]? Logo { get; set; }
        [Column("segmento")]
        public string? Segmento { get; set; }
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("publicoalvo")]
        public string? PublicoAlvo { get; set; }
        [Column("faixapreco")]
        public string? FaixaPreco { get; set; }
        [Column("id_user")]
        [ForeignKey(nameof(User))]
        public string? IdUser { get; set; } 
    }
}
