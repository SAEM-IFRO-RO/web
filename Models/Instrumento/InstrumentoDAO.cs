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