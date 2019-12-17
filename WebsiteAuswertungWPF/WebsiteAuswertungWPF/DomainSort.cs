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
        int i = 0;
        public List<Domain> domains = new List<Domain>();
        public DomainSort(IOC ioc)
        {
            this.ioc = ioc;
        }
        public void Sort()
        {
            
            bool List_is_run = false;
            string[] String_Split;

            foreach (string line in ioc.Files.Resultlist)
            {
                List_is_run = false;
                String_Split = line.Split(' ');
                for (int i = 0; i < domains.Count; i++)
                {
                    if(domains[i].Name == String_Split[2])
                    {
                        domains[i].Count++;
                        List_is_run = true;
                    }
                }
                if(List_is_run == false)
                {
                    domains.Add(new Domain(String_Split[2]));
                }
            }
            foreach (Domain domain in domains)
            {
                Console.WriteLine(domain.Name + domain.Count);
            }
        }
    }
}
