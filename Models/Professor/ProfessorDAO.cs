using SaemWeb.Configs;

namespace SaemWeb.Models
{
  public class ProfessorDAO
  {

    private readonly Connection _Connection;

    public ProfessorDAO(Connection Connection)
    {
      _Connection = Connection;
    }


    public List<Professor> Listar()
    {
      var lista = new List<Professor>();

      var comando = _Connection.CreateCommand("SELECT * FROM Professor");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var Professor = new Professor
        {
          Id = leitor.GetInt32("id_pro"),
          Nome = leitor.GetString("nome_pro"),
          Cpf = leitor.GetString("cpf_pro"),
          DataNascimento = leitor.GetDateTime("data_nascimento_pro"),
          Email = leitor.GetString("email_pro"),
          Telefone = leitor.GetString("telefone_pro"),
          Cep = leitor.GetString("cep_pro"),
        };

        lista.Add(Professor);
      }

      return lista;
    }
  }
}