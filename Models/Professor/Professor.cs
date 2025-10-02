namespace SaemWeb.Models
{
  public class Professor
  {
    public required int Id { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required string Cep { get; set; }
  }
}