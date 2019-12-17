using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAuswertungWPF
{
    class Domain
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public Domain(string n)
        {
            this.name = n;
            this.Count = 1;
        }

    }
}
