namespace SaemWeb.Models
{
  public class Turma
  {

    public int Id { get; set; }
    public required string Nome { get; set; }
    public int Vagas { get; set; }
    public required string Status { get; set; }
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }
  }
}