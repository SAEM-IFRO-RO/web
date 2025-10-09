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

    // Inserção
    public void Inserir(Curso curso)
    {
      try
      {
        var comando = _Connection.CreateCommand(" INSERT INTO curso VALUES (null, @_nome, @_dificuldade, @_descricao, @_id_inst_fk)");

        comando.Parameters.AddWithValue("@_nome", curso.Nome);
        comando.Parameters.AddWithValue("@_dificuldade", curso.Dificuldade);
        comando.Parameters.AddWithValue("@_descricao", curso.Descricao);
        comando.Parameters.AddWithValue("@_id_inst_fk", curso.IdInstrumentoFk);

        comando.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Listar
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