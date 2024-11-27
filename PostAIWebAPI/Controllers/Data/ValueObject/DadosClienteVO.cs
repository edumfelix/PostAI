using System.Text.Json;

namespace PostAIWebAPI.Controllers.Data.ValueObject
{
    public class DadosClienteVO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Site { get; set; }
        public JsonDocument? Cores { get; set; }
        public byte[]? Logo { get; set; }
        public string? Segmento { get; set; }
        public string? Descricao { get; set; }
        public string? PublicoAlvo { get; set; }
        public string? FaixaPreco { get; set; }
        public string? IdUser { get; set; }
    }
}
