using System.Data;
using System.Data.SqlClient;
using ZApoioBack.Models;
using ZApoioBack.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ZApoioBack.Repository.Implementations
{
    public class DeployRepository : IDeployRepository
    {
        private readonly IConfiguration _configuration;

        public DeployRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Salvar(Deploy deploy)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO TB_DEPLOY (DT_DEPLOY, NM_TITULO, DS_TIPO, NM_AUTOR)
                VALUES (@DT_DEPLOY, @NM_TITULO, @DS_TIPO, @NM_AUTOR)";

            command.Parameters.Add(new SqlParameter("@DT_DEPLOY", DateTime.Now));
            command.Parameters.Add(new SqlParameter("@NM_TITULO", deploy.Titulo));
            command.Parameters.Add(new SqlParameter("@DS_TIPO", deploy.Tipo));
            command.Parameters.Add(new SqlParameter("@NM_AUTOR", deploy.Autor));

            command.ExecuteNonQuery();
        }

        public List<Deploy> ObterTodos()
        {
            var lista = new List<Deploy>();

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT ID_DEPLOY, DT_DEPLOY, NM_TITULO, DS_TIPO, NM_AUTOR
                FROM TB_DEPLOY
                ORDER BY DT_DEPLOY DESC";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Deploy
                {
                    Id = Convert.ToInt32(reader["ID_DEPLOY"]),
                    DataDeploy = Convert.ToDateTime(reader["DT_DEPLOY"]),
                    Titulo = reader["NM_TITULO"].ToString() ?? string.Empty,
                    Tipo = reader["DS_TIPO"].ToString() ?? string.Empty,
                    Autor = reader["NM_AUTOR"].ToString() ?? string.Empty
                });
            }

            return lista;
        }
    }
}
