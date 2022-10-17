

using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories
{
	public class ProjectRepo : IProjectRepo 
	{
		private string _connectionString;

        public ProjectRepo(IConfiguration config)
        {
          _connectionString = config.GetConnectionString("default");
        }
        protected Project Converter(IDataReader reader)
        {
            return new Project
            {
                Id = (int)reader["Id"],
                IdOwner = (int) reader["IdOwner"],
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                Goal = (int)reader["Goal"],
                BeginDate = (DateOnly)reader["BeginDate"],
                EndDate = (DateOnly)reader["EndDate"],
                IdUser = (int)reader["IdUser"],
                IsValidate = (bool)reader["IsValidate"]

            };
        }

        

        public void Delete(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Project WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }

        public IEnumerable<Project> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Project";
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Converter(reader);
                        }
                    }
                }
            }
        }

        public Project GetById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Project WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Converter(reader);
                        }
                        throw new Exception("Projet inexistant");

                    }
                }
            }

        }

        public void Update(Project p)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Project SET IdOwner = @IdOwner, Title = @title, Description = @Description, Goal = @Goal, BegindDate = @BeginDate, EndDate = @EndDate, IdUser = @IdUser, IsValidate = @IsValidate " +
                        " WHERE Id = @id";
                    cmd.Parameters.AddWithValue("IdOwner", p.IdOwner);
                    cmd.Parameters.AddWithValue("Title", p.Title);
                    cmd.Parameters.AddWithValue("Description", p.Description);
                    cmd.Parameters.AddWithValue("Goal", p.Goal);
                    cmd.Parameters.AddWithValue("BeginDate", p.BeginDate);
                    cmd.Parameters.AddWithValue("EndDate", p.EndDate);
                    cmd.Parameters.AddWithValue("IdUser", p.IdUser);
                    cmd.Parameters.AddWithValue("IsValidate", p.IsValidate);
                    cmd.Parameters.AddWithValue("id", p.Id);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
            }
        }

        public void CreateProject(Project p)
		{
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Project (IdOwner, Title, Description, Goal, BeginDate, EndDate, IdUser, IsValidate) " +
                        "VALUES (@IdOwner, @Title, @Description, @Goal, CONVERT(date,@BeginDate,111), CONVERT(date,@EndDate,111), @IdUser, @IsValidate)";
                    cmd.Parameters.AddWithValue("IdOwner", p.IdOwner);
                    cmd.Parameters.AddWithValue("Title", p.Title);
                    cmd.Parameters.AddWithValue("Description", p.Description);
                    cmd.Parameters.AddWithValue("Goal", p.Goal);
                    cmd.Parameters.AddWithValue("BeginDate", p.BeginDate);
                    cmd.Parameters.AddWithValue("EndDate", p.EndDate);
                    cmd.Parameters.AddWithValue("IdUser", p.IdUser);
                    cmd.Parameters.AddWithValue("IsValidate", p.IsValidate);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();


                }
            }
        }

    }
}