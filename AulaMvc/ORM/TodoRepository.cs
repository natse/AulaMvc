using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ORM
{
    public class TodoRepository : RepositoryConnector, Interfaces.ITodoRepository
    {
        public TodoRepository(IConfiguration config): base (config){}
        public void Add(ToDo obj)
        {
            dynamicParemeters pam = new dynamicParemeters();
            pam.Add("@Tarefa", obj.Tarefa);
            string sql = "INSERT INTO Todo (Tarefa) VALUES(@Tarefa)";
            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql, pam);
            }
        }

        public ToDo Get(int id)
        {
            string sql = $"SELECT * FROM Todo WHERE Id = {id}";
            using (var con = new SqlConnection(base.GetConnection()))
            {
                return con.Query<ToDo>(sql).FirsOrDefault();
            }

        }

        public IEnumerable<ToDo> GetAll()
        {
            IEnumerable<ToDo> retorno;
            string sql = "SELECT *FROM Todo";
            using (var con = new SqlConnection(base.GetConnection()))
            {
                retorno = con.Query<ToDo>(sql);
            }
            return retorno;
        }

        public void Remove(ToDo obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo obj)
        {
            string sql = $@"UPDATE FROM
                            Todo SET Tarefa = 
                            @Tarefa WHERE Id = {obj.Id}";
            DynamicParameters pam = new DynamicParameters();
            pam.Add("@Tarefa", obj.Tarefa);
            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql, pam);
            }
        }
    }
}
