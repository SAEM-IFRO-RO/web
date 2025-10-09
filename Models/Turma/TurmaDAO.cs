using SaemWeb.Configs;

namespace SaemWeb.Models
{
  public class TurmaDAO
  {

    private readonly Connection _Connection;

    public TurmaDAO(Connection Connection)
    {
      _Connection = Connection;
    }
    
    // Inserção
    public void Inserir(Turma turma)
    {
      try
      {
        var comando = _Connection.CreateCommand(" INSERT INTO turma VALUES (null, @_nome, @_vagas, @_status, @_data_inicial, @_data_final, @_id_cur_fk)");

        comando.Parameters.AddWithValue("@_nome", turma.Nome);
        comando.Parameters.AddWithValue("@_vagas", turma.Vagas);
        comando.Parameters.AddWithValue("@_status", turma.Status);
        comando.Parameters.AddWithValue("@_data_inicial", turma.DataInicial);
        comando.Parameters.AddWithValue("@_data_final", turma.DataFinal);
        comando.Parameters.AddWithValue("@_id_cur_fk", turma.IdCursoFk);

        comando.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Listagem
    public List<Turma> Listar()
    {
      var lista = new List<Turma>();

      var comando = _Connection.CreateCommand("SELECT * FROM Turma");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var turma = new Turma
        {
          Id = leitor.GetInt32("id_tur"),
          Nome = leitor.GetString("nome_tur"),
          Vagas = leitor.GetInt16("vagas_tur"),
          Status = leitor.GetString("status_tur"),
          DataInicial = leitor.GetDateTime("data_inicial_tur"),
          DataFinal = leitor.GetDateTime("data_final_tur"),

        };

        lista.Add(turma);
      }

      return lista;
    }
  }
}