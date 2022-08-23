using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NYToDoListApi.Model
{
    public class ToDoRepository
    {
        private string connectionString = "";

        public ToDoRepository()
        {
            connectionString = "Data Source=DESKTOP-N6665N4\\HP;Initial Catalog=Todo;Integrated Security=true";
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }     
        }
        public void AddTo(ToDo to)
        {
            using (IDbConnection dbconnection=connection)
            {
                string sQuery = "INSERT INTO Todos (Title,Text,Date,Status) VALUES (@Title,@Text,@Date,@Status)";
                dbconnection.Open();
                dbconnection.Execute(sQuery,to);
            }
        }
        public IEnumerable<ToDo> GetAll()
        {
            using (IDbConnection dbconnection = connection)
            {
                string sQuery = "SELECT * FROM Todos";
                dbconnection.Open();
                return dbconnection.Query<ToDo>(sQuery);
            }
        }
        public ToDo GetById(int Id)
        {
            using (IDbConnection dbconnection = connection)
            {
                string sQuery = "SELECT * FROM Todos where Id=@Id";
                dbconnection.Open();
                return dbconnection.Query<ToDo>(sQuery, new { Id = @Id }).FirstOrDefault();
            }
        }
        public void Delete(int Id)
        {
            using (IDbConnection dbconnection = connection)
            {
                string sQuery = "DELETE FROM Todos where Id=@Id";
                dbconnection.Open();
                dbconnection.Query<ToDo>(sQuery, new { Id = @Id });
            }
        }
        public void Update(ToDo to)
        {
            using (IDbConnection dbconnection = connection)
            {
                string sQuery = "UPDATE Todos SET Title=@Title, Text=@Text, Date=@Date, Status=@Status where Id=@Id";
                dbconnection.Open();
                dbconnection.Query<ToDo>(sQuery,to);
            }
        }
    }
}
