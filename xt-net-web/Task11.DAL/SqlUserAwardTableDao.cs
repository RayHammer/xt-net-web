using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Task06.DAL.Interfaces;

namespace Task11.DAL
{
    public class SqlUserAwardTableDao : IUserAwardTableDao
    {
        private readonly string connectionString = SqlDaoCommon.ConnectionString;

        public void Add(int userId, int awardId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GiveAward";

                var userIdVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Direction = ParameterDirection.Input
                });

                var awardIdVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Direction = ParameterDirection.Input
                });

                userIdVal.Value = userId;
                awardIdVal.Value = awardId;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                command.Dispose();
            }
        }

        public void Clear(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.ClearAwardsFor";

                var userIdVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Direction = ParameterDirection.Input
                });

                userIdVal.Value = userId;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                command.Dispose();
            }
        }

        public IEnumerable<int> GetAwardIdsFor(int userId)
        {
            var awards = new List<int>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwardsFor";

                var userIdVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Direction = ParameterDirection.Input
                });

                userIdVal.Value = userId;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awards.Add((int)reader["AwardID"]);
                }

                connection.Close();
                command.Dispose();
            }
            return awards;
        }

        public void Remove(int userId, int awardId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RevokeAward";

                var userIdVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Direction = ParameterDirection.Input
                });

                var awardIdVal = command.Parameters.Add(new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Direction = ParameterDirection.Input
                });

                userIdVal.Value = userId;
                awardIdVal.Value = awardId;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                command.Dispose();
            }
        }
    }
}