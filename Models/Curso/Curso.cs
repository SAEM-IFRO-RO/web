namespace SaemWeb.Models
{
  public class Curso
  {
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Dificuldade { get; set; } = "";
    public string? Descricao { get; set; } = "";
    public required int IdInstrumentoFk { get; set; }
  }
}