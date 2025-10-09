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
  }
}