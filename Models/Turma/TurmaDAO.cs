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
          Nome = leitor.GetString("nome_pro"),
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