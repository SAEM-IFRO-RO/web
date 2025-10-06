namespace SaemWeb.Models
{
  public class Aluno
  {
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cep { get; set; }
  }
}