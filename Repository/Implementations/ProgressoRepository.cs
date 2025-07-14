using System.Data.SqlClient;
using ZApoioBack.Models;
using ZApoioBack.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ZApoioBack.Repository.Implementations
{
    public class ProgressoRepository : IProgressoRepository
    {
        private readonly IConfiguration _configuration;

        public ProgressoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Salvar(ProgressoZAcademy progresso)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO TB_PROGRESSO_ZACADEMY 
                (USUARIO, MODULO, ACERTOS, TOTAL, DATA)
                VALUES (@USUARIO, @MODULO, @ACERTOS, @TOTAL, @DATA)";

            command.Parameters.AddWithValue("@USUARIO", progresso.Usuario);
            command.Parameters.AddWithValue("@MODULO", progresso.Modulo);
            command.Parameters.AddWithValue("@ACERTOS", progresso.Acertos);
            command.Parameters.AddWithValue("@TOTAL", progresso.Total);
            command.Parameters.AddWithValue("@DATA", DateTime.Now);

            command.ExecuteNonQuery();
        }

        public List<ProgressoZAcademy> ListarPorUsuario(string usuario)
        {
            var lista = new List<ProgressoZAcademy>();

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT * FROM TB_PROGRESSO_ZACADEMY 
                WHERE USUARIO = @USUARIO 
                ORDER BY DATA DESC";

            command.Parameters.AddWithValue("@USUARIO", usuario);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new ProgressoZAcademy
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Usuario = reader["USUARIO"].ToString() ?? "",
                    Modulo = reader["MODULO"].ToString() ?? "",
                    Acertos = Convert.ToInt32(reader["ACERTOS"]),
                    Total = Convert.ToInt32(reader["TOTAL"]),
                    Data = Convert.ToDateTime(reader["DATA"])
                });
            }

            return lista;
        }
    }
}
