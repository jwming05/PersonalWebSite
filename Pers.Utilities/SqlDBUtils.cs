using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Pers.Utilities
{
    public static class SqlDBUtils
    {
        public static object ExecuteScalar(string connectionString, string cmdText,
            CommandType commandType, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var sqlParameter in sqlParameters)
                        {
                            command.Parameters.Add(sqlParameter);
                        }
                    }

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        public static int ExecuteNonQuery(string connectionString, string cmdText,
            CommandType commandType, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var sqlParameter in sqlParameters)
                        {
                            command.Parameters.Add(sqlParameter);
                        }
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        //public static SqlDataReader ExecuteReader(string connectionString, string cmdText,
        //    CommandType commandType, params SqlParameter[] sqlParameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(cmdText, connection))
        //        {
        //            command.CommandType = commandType;

        //            if (sqlParameters != null)
        //            {
        //                foreach (var sqlParameter in sqlParameters)
        //                {
        //                    command.Parameters.Add(sqlParameter);
        //                }
        //            }

        //            connection.Open();
        //            return command.ExecuteReader();
        //        }
        //    }
        //}

        public static List<T> ExecuteReader<T>(string connectionString, string cmdText,
            CommandType commandType, Func<SqlDataReader, T> itemCreator, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = commandType;

                    if (sqlParameters != null)
                    {
                        foreach (var sqlParameter in sqlParameters)
                        {
                            command.Parameters.Add(sqlParameter);
                        }
                    }

                    connection.Open();

                    List<T> list = new List<T>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = itemCreator(reader);
                            list.Add(item);
                        }
                    }
                    return list;
                }
            }            
        }
    }
}
