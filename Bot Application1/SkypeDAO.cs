using Bot_Application1.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Bot_Application1
{
    public class SkypeDAO
    {
        private NpgsqlConnection connection;
        private string config_path = @"/etc/mydb.config";

        /* mydb.config should look like:
         * 
         * <?xml version = "1.0" encoding="utf-8"?>
         * <postgresql>
         *   <server>abc.net</server>
         *   <port>66666</port>
         *   <username>user</username>
         *   <password>password</password>
         *   <database>database</database>
         * </postgresql>
         */

        // load configuration to connect database
        public SkypeDAO()
        {
            XDocument xDoc = XDocument.Load(config_path);
            var psql_server = xDoc.Root.Element("server").Value;
            var psql_port = xDoc.Root.Element("port").Value;
            var psql_user = xDoc.Root.Element("username").Value;
            var psql_pwd = xDoc.Root.Element("password").Value;
            var psql_db = xDoc.Root.Element("database").Value;

            connection = new NpgsqlConnection($"Server={psql_server};Port={psql_port};Username={psql_user};Password={psql_pwd};Database={psql_db}");
        }

        public void Open()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(string name, string log, string time)
        {
            try
            {
                string query = $"insert into message_log(name,log,time) values('{name}','{log}','{time}')";
                NpgsqlCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取出 TOP 50
        /// </summary>
        public List<MessageLog> GetMessageLog()
        {
            List<MessageLog> result = new List<MessageLog>();
            try
            {
                string query = "select Name,Log,Time from message_log order by time desc limit 50";
                NpgsqlCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Convert(reader));
                }
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal MessageLog Convert(NpgsqlDataReader reader)
        {
            MessageLog value = new MessageLog();
            value.Name = reader.GetString(0);
            value.Log = reader.GetString(1);
            value.Time = reader.IsDBNull(2) ? new DateTime() : reader.GetDateTime(2);
            return value;
        }
    }
}