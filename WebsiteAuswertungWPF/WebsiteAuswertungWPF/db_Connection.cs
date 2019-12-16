using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebsiteAuswertungWPF
{
    class db_Connection
    {
        string Connection_String;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        SqlCommand sqlcommand;
        DataTable Sql_Datatable = new DataTable();

        public void Start_DB_Connection()
        {
            Connection_String = "Data Source=(local);Initial Catalog=DB_Lagerverwaltung;Integrated Security=True";
            sqlconnection = new SqlConnection(Connection_String);

            sqlconnection.Open();
            Console.WriteLine("Connection Startet!");
        }

        public DataTable SQL_Command(string sql)
        {
            Start_DB_Connection();
            sqlcommand = new SqlCommand(sql, sqlconnection);
            sqldataadapter = new SqlDataAdapter(sqlcommand);

            sqldataadapter.Fill(Sql_Datatable);
            Close_DB_Connection();

            return Sql_Datatable;
        }

        public void Close_DB_Connection()
        {
            Console.WriteLine("Connection Closed!");
            sqlconnection.Close();
        }

        public void DB_Insert(string sql)
        {
            sqlcommand = new SqlCommand(sql, sqlconnection);
            sqlcommand.ExecuteNonQuery();
        }
    }
}
