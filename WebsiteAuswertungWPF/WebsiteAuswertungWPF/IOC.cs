using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WebsiteAuswertungWPF
{

    class IOC
    {
        internal File_Convert Files = new File_Convert();
        internal db_Connection DB = new db_Connection();
        internal DomainSort Sort;

        DataTable Dt = new DataTable();
        public IOC()
        {
            Sort = new DomainSort(this);
        }

        public void Insert_DB()
        {
            foreach(string file in Files.Resultlist)
            {
                string[] String_Split;
                String_Split = file.Split(' ');
                DB.DB_Insert("INSERT INTO Website(Zeit,Sender,Empfaenger)VALUES(\'" + String_Split[0] + "\'," + "\'" + String_Split[1] + "\'," + "\'" + String_Split[2] + "\')");
            }
        }

        public void Top()
        {
            int x = 10;
            Sort.domains.OrderBy(o => o.Count).ToList();

            if(Sort.domains.Count < 10)
            {
                x = Sort.domains.Count;
            }
            for(int i = 0; i < x; i++)
            {
                Console.WriteLine(Sort.domains[i].Name + Sort.domains[i].Count);
            }
        }

        public void DataTable_To_List(DataTable Datatable)
        {
            foreach (DataRow row in Datatable.Rows)
            {
                Console.WriteLine(row[1] + " " + row[2] + " " + row[3]);
                Files.Resultlist.Add(row[1] + " " + row[2] + " " + row[3]);
            }
        }

        public void LoadData()
        {
            Dt = DB.SQL_Command("SELECT * FROM Website");
            DataTable_To_List(Dt);
        }
    }
}
