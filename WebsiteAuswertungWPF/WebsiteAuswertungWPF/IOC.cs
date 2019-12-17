using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAuswertungWPF
{

    class IOC
    {
        internal File_Convert Files = new File_Convert();
        internal db_Connection DB = new db_Connection();
        internal DomainSort Sort;
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
                Console.WriteLine("INSERT INTO Website(Zeit,Sender,Empfaenger)VALUES(\'" + String_Split[0] + "\'," + "\'" + String_Split[1] + "\'," + "\'" + String_Split[2] + "\')");
                DB.DB_Insert("INSERT INTO Website(Zeit,Sender,Empfaenger)VALUES(\'" + String_Split[0] + "\'," + "\'" + String_Split[1] + "\'," + "\'" + String_Split[2] + "\')");
            }
        }
    }
}
