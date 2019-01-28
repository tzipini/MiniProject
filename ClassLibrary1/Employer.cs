using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employer
    {
        public int Key { get; set; }
        public bool IsIndependent { get; set; }
        public int CompanyKey { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string CompanyName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public NameSpecialty Domain { get; set; }
        public DateTime EstablishmentDate { get; set; }


        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
