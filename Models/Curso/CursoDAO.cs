using SaemWeb.Configs;

namespace SaemWeb.Models
{
  public class CursoDAO
  {

    private readonly Connection _Connection;

    public CursoDAO(Connection Connection)
    {
      _Connection = Connection;
    }


    public List<Curso> Listar()
    {
      var lista = new List<Curso>();

      var comando = _Connection.CreateCommand("SELECT * FROM Curso");
      var leitor = comando.ExecuteReader();

      while (leitor.Read())
      {
        var Curso = new Curso
        {
          Id = leitor.GetInt32("id_ins"),
          Nome = leitor.GetString("nome_ins"),
          Dificuldade = leitor.GetString("nivel_dificuldade_cur"),
          Descricao = leitor.GetString("descricao_cur"),
          IdInstrumentoFk = leitor.GetInt32("id_ins_fk"),
        };

        lista.Add(Curso);
      }

      return lista;
    }
  }
}