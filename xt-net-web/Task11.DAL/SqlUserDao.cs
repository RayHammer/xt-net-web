using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Task06.DAL.Interfaces;
using Task06.Entities;

namespace Task11.DAL
{
    public class SqlUserDao : IUserDao
    {
        private readonly string connectionString = SqlDaoCommon.ConnectionString;

        public User Add(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                var nameVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Direction = ParameterDirection.Input,
                });
                var dateOfBirthVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@DateOfBirth",
                    Direction = ParameterDirection.Input,
                });
                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Output,
                });

                nameVal.Value = user.Name;
                dateOfBirthVal.Value = user.DateOfBirth;

                connection.Open();
                command.ExecuteNonQuery();

                user.Id = (int)idVal.Value;

                connection.Close();
                command.Dispose();
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var user = new User()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    };
                    users.Add(user);
                }

                connection.Close();
                command.Dispose();
            }
            return users;
        }

        public User GetById(int id)
        {
            User user = null;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";

                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Input
                });

                idVal.Value = id;

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    };
                }

                connection.Close();
                command.Dispose();
            }
            return user;
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUser";

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

        public void Update(int id, User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUser";

                var idVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Input
                });
                var nameVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Direction = ParameterDirection.Input
                });
                var dateOfBirthVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@DateOfBirth",
                    Direction = ParameterDirection.Input
                });

                idVal.Value = id;
                nameVal.Value = user.Name;
                dateOfBirthVal.Value = user.DateOfBirth;

                connection.Open();
                command.ExecuteNonQuery();

                user.Id = (int)idVal.Value;

                connection.Close();
                command.Dispose();
            }
        }
    }
}