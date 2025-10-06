using SaemWeb.Configs;

namespace SaemWeb.Models
{
  public class AlunoDAO
  {
    private readonly Connection _Connection;

    public AlunoDAO(Connection Connection)
    {
      _Connection = Connection;
    }


    public List<Aluno> Listar()
    {
      var lista = new List<Aluno>();

      var comando = _Connection.CreateCommand("SELECT * FROM Aluno");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var aluno = new Aluno
        {
          Id = leitor.GetInt32("id_alu"),
          Nome = leitor.GetString("nome_alu"),
          Cpf = leitor.GetString("cpf_alu"),
          DataNascimento = leitor.GetDateTime("data_nascimento_alu"),
          Email = leitor.GetString("email_alu"),
          Telefone = leitor.GetString("telefone_alu"),
          Cep = leitor.GetString("cep_alu"),
        };

        lista.Add(aluno);
      }

      return lista;
    }
  }
}