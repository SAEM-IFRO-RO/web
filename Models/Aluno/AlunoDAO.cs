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


    // Inserção

    public void Inserir(Aluno aluno)
    {
      try
      {
        var comando = _Connection.CreateCommand("INSERT INTO aluno VALUES (null, @_cpf, @_nome, @_data_nascimento, @_email, @_telefone, @_cep)");

        comando.Parameters.AddWithValue("@_cpf", aluno.Cpf);
        comando.Parameters.AddWithValue("@_nome", aluno.Nome);
        comando.Parameters.AddWithValue("@_data_nascimento", aluno.DataNascimento);
        comando.Parameters.AddWithValue("@_email", aluno.Email);
        comando.Parameters.AddWithValue("@_telefone", aluno.Telefone);
        comando.Parameters.AddWithValue("@_cep", aluno.Cep);

        comando.ExecuteNonQuery();

      }
      catch (Exception)
      {
        throw;
      }
    }

    // Listagem

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