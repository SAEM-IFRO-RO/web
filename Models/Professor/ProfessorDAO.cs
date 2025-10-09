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

    // Inserção

    public void Inserir(Professor professor)
    {
      try
      {
        /*
        
create table professor (
id_pro int primary key auto_increment,
cpf_pro varchar(20),
nome_pro varchar(100),
data_nascimento_pro date,
email_pro varchar(50),
telefone_pro varchar(30),
cep_pro varchar(20)
);
        */
        var comando = _Connection.CreateCommand(" INSERT INTO professor (cpf_pro, nome_pro, data_nascimento_pro, email_pro, telefone_pro, cep_pro) VALUES (@_cpf, @_nome, @_data_nascimento, @_email, @_telefone, @_cep)");

        comando.Parameters.AddWithValue("@_cpf", professor.Cpf);
        comando.Parameters.AddWithValue("@_nome", professor.Nome);
        comando.Parameters.AddWithValue("@_data_nascimento", professor.DataNascimento);
        comando.Parameters.AddWithValue("@_email", professor.Email);
        comando.Parameters.AddWithValue("@_telefone", professor.Telefone);
        comando.Parameters.AddWithValue("@_cep", professor.Cep);

        comando.ExecuteNonQuery();

      }
      catch (Exception)
      {
        throw;
      }
    }


    // Listar
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