using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessTableTest a = new AccessTableTest();
            ShowMsg(a.ConnectionString);
        }
        static void ShowMsg(string msg)
        {
            Console.Write(msg);
            Console.Read();
        }

    }

    class AccessTableTest
    {
        public string ConnectionString
        {
            get
            {
                return GetConnectionString();
            }
        }
        string BuildConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = "(localdb)\\v11.0";
            builder["Initial Catalog"] = "Test";
            builder["Integrated Security"] = "True";
            return builder.ConnectionString;
        }

        string GetConnectionString()
        {
            string s = ConfigurationManager.ConnectionStrings["TableTestConnectionString"].ConnectionString;
            return s;
        }
        public string TestConnection()
        {
            using (SqlConnection conn=new SqlConnection(this.ConnectionString))
            {
                try
                {
                    conn.Open();
                    return conn.State.ToString();
                }
                catch (Exception)
                {
                    return "false";
                    throw;
                }
            }
        }
    }
}
