using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task11.DAL
{
    public class SqlAwardDao : IAwardDao
    {
        private readonly string connectionString = SqlDaoCommon.ConnectionString;

        public Award Add(Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";

                var titleVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Direction = ParameterDirection.Input,
                });
                var imageSource = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@ImageSource",
                    Direction = ParameterDirection.Input,
                });
                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Output,
                });

                titleVal.Value = award.Title;
                imageSource.Value = award.ImageSource;

                connection.Open();
                command.ExecuteNonQuery();

                award.Id = (int)idVal.Value;

                connection.Close();
                command.Dispose();
            }
            return award;
        }

        public IEnumerable<Award> GetAll()
        {
            var awards = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAwards";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var award = new Award()
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        ImageSource = reader["ImageSource"] as string
                    };
                    awards.Add(award);
                }

                connection.Close();
                command.Dispose();
            }
            return awards;
        }

        public Award GetById(int id)
        {
            Award award = null;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwardById";

                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Input,
                });

                idVal.Value = id;

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    award = new Award()
                    {
                        Id = id,
                        Title = reader["Title"] as string,
                        ImageSource = reader["ImageSource"] as string
                    };
                }

                connection.Close();
                command.Dispose();
            }
            return award;
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAward";

                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Input
                });

                idVal.Value = id;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                command.Dispose();
            }
        }

        public void Update(int id, Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAward";

                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Input
                });
                var titleVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Direction = ParameterDirection.Input,
                });
                var imageSource = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@ImageSource",
                    Direction = ParameterDirection.Input,
                });

                idVal.Value = id;
                titleVal.Value = award.Title;
                imageSource.Value = award.ImageSource;

                connection.Open();
                command.ExecuteNonQuery();

                award.Id = (int)idVal.Value;

                connection.Close();
                command.Dispose();
            }
        }
    }
}