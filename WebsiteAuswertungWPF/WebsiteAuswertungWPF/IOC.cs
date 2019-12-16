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
    }
}
