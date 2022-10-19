﻿

using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using ToolBox;
using ToolBox.Models;

namespace DAL.Repositories
{
	public class ProjectRepo : Connection, IProjectRepo 
	{
		private string _connectionString;

        public ProjectRepo(IConfiguration config) : base(config){}
        protected Project Converter(IDataReader reader)
        {
            return new Project
            {
                Id = (int)reader["Id"],
                IdOwner = (int) reader["IdOwner"],
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                Goal = (int)reader["Goal"],
                BeginDate = (DateTime)reader["BeginDate"],
                EndDate = (DateTime)reader["EndDate"],
                //IdUser = (int)reader["IdUser"],
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
            Command cmd = new Command("SELECT * FROM Project");
            return ExecuteReader<Project>(cmd);
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
                    cmd.CommandText = "UPDATE Project SET IdOwner = @IdOwner, Title = @title, Description = @Description, Goal = @Goal, BeginDate = CONVERT(date,@BeginDate), EndDate = CONVERT(date,@EndDate), IsValidate = @IsValidate " +
                        " WHERE Id = @id";
                    cmd.Parameters.AddWithValue("IdOwner", p.IdOwner);
                    cmd.Parameters.AddWithValue("Title", p.Title);
                    cmd.Parameters.AddWithValue("Description", p.Description);
                    cmd.Parameters.AddWithValue("Goal", p.Goal);
                    cmd.Parameters.AddWithValue("BeginDate", p.BeginDate);
                    cmd.Parameters.AddWithValue("EndDate", p.EndDate);
                    //cmd.Parameters.AddWithValue("IdUser", p.IdUser);
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
                    cmd.CommandText = "INSERT INTO Project (IdOwner, Title, Description, Goal, BeginDate, EndDate, IsValidate) " +
                        "VALUES (@IdOwner, @Title, @Description, @Goal, CONVERT(date,@BeginDate), CONVERT(date,@EndDate), @IsValidate)";
                    cmd.Parameters.AddWithValue("IdOwner", p.IdOwner);
                    cmd.Parameters.AddWithValue("Title", p.Title);
                    cmd.Parameters.AddWithValue("Description", p.Description);
                    cmd.Parameters.AddWithValue("Goal", p.Goal);
                    cmd.Parameters.AddWithValue("BeginDate", p.BeginDate);
                    cmd.Parameters.AddWithValue("EndDate", p.EndDate);
                    //cmd.Parameters.AddWithValue("IdUser", p.IdUser);
                    cmd.Parameters.AddWithValue("IsValidate", p.IsValidate);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();


                }
            }
        }

    }
}