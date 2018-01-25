using Bot_Application1.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1 {
    public class SkypeDAO {

        private  NpgsqlConnection connection = new NpgsqlConnection("Server=pcyo.ddns.net;Port=59487;Username=postgres;Password=postgres;Database=postgres");

        public void Open() {
            try {
                connection.Open();
            } catch(Exception ex) {
                throw ex;
            }          
        }

        public void InsertMessageLog(string name,string log,string time) {
            try {
                string query = $"insert into message_log(name,log,time) values('{name}','{log}','{time}')";
                NpgsqlCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                cmd.ExecuteReader();
            } catch(Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// 取出 TOP 50
        /// </summary>
        public List<MessageLog> GetMessageLog() {
            List<MessageLog> result = new List<MessageLog>();
            try {              
                string query = "select Name,Log,Time from message_log order by time desc limit 50";
                NpgsqlCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    result.Add(ConvertMessageLog(reader));
                }
                reader.Close();
                return result;
            } catch(Exception ex) {
                throw ex;
            }
        }

        public List<Quotation> GetQuotations(string key) {
            List<Quotation> result = new List<Quotation>();
            try {
                string query = $"select key,value from quotation where key like '%{key}%' order by seq desc";
                NpgsqlCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    result.Add(ConvertQuotation(reader));
                }
                reader.Close();
                return result;
            } catch (Exception ex) {
                return result;
            }
        }

        public void InsertQuotations(string key,string value) {       
            try {
                NpgsqlCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = $"insert into quotation(key,value) values('{key}','{value}')";
                cmd.CommandTimeout = 0;
                cmd.ExecuteReader();
            } catch (Exception ex) {
                throw ex;
            }
        }

        internal  MessageLog ConvertMessageLog(NpgsqlDataReader reader) {
            MessageLog value = new MessageLog();
            value.Name = reader.GetString(0);
            value.Log = reader.GetString(1);
            value.Time = reader.IsDBNull(2)? new DateTime() : reader.GetDateTime(2) ;
            return value;
        }

        internal Quotation ConvertQuotation(NpgsqlDataReader reader) {
            Quotation value = new Quotation();
            value.Key = reader.GetString(0);
            value.Value = reader.GetString(1);
            return value;
        }
    }
}