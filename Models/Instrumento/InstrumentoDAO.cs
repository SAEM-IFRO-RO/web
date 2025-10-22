using SaemWeb.Configs;

namespace SaemWeb.Models
{
  public class InstrumentoDAO
  {

    private readonly Connection _Connection;

    public InstrumentoDAO(Connection Connection)
    {
      _Connection = Connection;
    }

    // Inserção
    public void Inserir(Instrumento instrumento)
    {
      try
      {
        var comando = _Connection.CreateCommand(" INSERT INTO instrumento (nome_ins, tipo_ins) VALUES (@_nome, @_tipo)");

        comando.Parameters.AddWithValue("@_nome", instrumento.Nome);
        comando.Parameters.AddWithValue("@_tipo", instrumento.Tipo);

        comando.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Listar
    public List<Instrumento> Listar()
    {
      var lista = new List<Instrumento>();

      var comando = _Connection.CreateCommand("SELECT * FROM Instrumento");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var instrumento = new Instrumento
        {
          Id = leitor.GetInt32("id_ins"),
          Nome = leitor.GetString("nome_ins"),
          Tipo = leitor.GetString("tipo_ins")
        };

        lista.Add(instrumento);
      }

      return lista;
    }

    public Instrumento? BuscarPorId(int id)
    {
      var comando = _Connection.CreateCommand(
          "SELECT * FROM instrumento WHERE id_ins = @id;");
      comando.Parameters.AddWithValue("@id", id);

      var leitor = comando.ExecuteReader();

      if (leitor.Read())
      {
        var instrumento = new Instrumento();
        instrumento.Id = leitor.GetInt32("id_ins");
        instrumento.Nome = DAOHelper.GetString(leitor, "nome_ins");
        instrumento.Tipo = DAOHelper.GetString(leitor, "tipo_ins");

        return instrumento;
      }
      else
      {
        return null;
      }
    }

    public void Atualizar(Instrumento Instrumento)
    {
      try
      {
        var comando = _Connection.CreateCommand(
        "UPDATE Instrumento SET nome_ins = @_nome, tipo_ins = @_tipo WHERE id_ins = @_id;");

        comando.Parameters.AddWithValue("@_id", Instrumento.Id);
        comando.Parameters.AddWithValue("@_nome", Instrumento.Nome);
        comando.Parameters.AddWithValue("@_tipo", Instrumento.Tipo);

        comando.ExecuteNonQuery();
      }
      catch
      {
        throw;
      }
    }

    public void Excluir(int id)
    {
      try
      {
        var comando = _Connection.CreateCommand(
        "DELETE FROM Instrumento WHERE id_ins = @id;");

        comando.Parameters.AddWithValue("@id", id);

        comando.ExecuteNonQuery();
      }
      catch
      {
        throw;
      }
    }
  }
}