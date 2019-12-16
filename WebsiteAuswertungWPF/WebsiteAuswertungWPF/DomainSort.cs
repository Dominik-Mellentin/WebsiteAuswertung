using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAuswertungWPF
{
    class DomainSort
    {
        internal IOC ioc;
        public DomainSort(IOC ioc)
        {
            this.ioc = ioc;
        }
        public void Sort()
        {
            List<Domain> domains = new List<Domain>();
            foreach (string line in ioc.Files.Resultlist)
            {
                bool warinforeach = false;
                bool gibtesinlist = false;
                string[] splitstring;
                splitstring = line.Split(' ');
                foreach (Domain d in domains)
                {
                    warinforeach = true;
                    if (d.Name == splitstring[2])
                    {
                        gibtesinlist = true;
                        d.Count++;
                    }
                    else if (d.Name != splitstring[2] && gibtesinlist == false)
                    {
                        domains.Add(new Domain(splitstring[2]));
                    }
                }
                if (warinforeach == false)
                {
                    domains.Add(new Domain(splitstring[2]));
                }
            }
            foreach(Domain d in domains)
            {
                Console.WriteLine(d.Name + " " + d.Count);
            }
        }
    }
}
