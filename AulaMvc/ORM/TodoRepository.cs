﻿using Entities;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
