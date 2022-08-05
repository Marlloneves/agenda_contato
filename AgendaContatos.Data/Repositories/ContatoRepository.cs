using AgendaContatos.Data.Configurations;
using AgendaContatos.Data.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Data.Repositories
{
    public class ContatoRepository
    {
        //método para inserir um contato na base de dados
        public void Create(Contato contato)
        {
            var sql = @"
                INSERT INTO CONTATO(
                    IDCONTATO,
                    NOME,
                    EMAIL,
                    TELEFONE,
                    DATANASCIMENTO,
                    IDUSUARIO)
                VALUES(
                    @IdContato,
                    @Nome,
                    @Email,
                    @Telefone,
                    @DataNascimento,
                    @IdUsuario)
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetSqlConnectionString()))
            {
                connection.Execute(sql, contato);
            }
        }

        //método para atualizar um contato na base de dados
        public void Update(Contato contato)
        {
            var sql = @"
                UPDATE CONTATO
                SET
                    NOME = @Nome,
                    EMAIL = @Email,
                    TELEFONE = @Telefone,
                    DATANASCIMENTO = @DataNascimento
                WHERE
                    IDCONTATO = @IdContato
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetSqlConnectionString()))
            {
                connection.Execute(sql, contato);
            }
        }

        //método para excluir um contato na base de dados
        public void Delete(Contato contato)
        {
            var sql = @"
                DELETE FROM CONTATO
                WHERE IDCONTATO = @IdContato
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetSqlConnectionString()))
            {
                connection.Execute(sql, contato);
            }
        }
        //método para consultar todos os contatos de 1 usuário
        public List<Contato> GetByUsuario(Guid idUsuario)
        {
            var sql = @"
                SELECT * FROM CONTATO
                WHERE IDUSUARIO = @idUsuario
                ORDER BY NOME
            ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetSqlConnectionString()))
            {
                return connection.Query<Contato>(sql, new { idUsuario }).ToList();
            }
        }
        //método para consultar 1 contato baseado no id do contato e id do usuário
        public Contato GetById(Guid idUsuario, Guid idContato)
        {
            var sql = @"
                SELECT * FROM CONTATO
                WHERE IDUSUARIO = @idUsuario
                WHERE IDCONTATO = @idContato
                ORDER BY NOME
            ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetSqlConnectionString()))
            {
                return connection.Query<Contato>(sql, new { idUsuario, idContato }).FirstOrDefault();
            }
        }
    }
}

