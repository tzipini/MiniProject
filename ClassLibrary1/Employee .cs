using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public Area AreaName { get; set; }
        public Degree DegreeI { get; set; }
        public bool IsMilitaryGraduate { get; set; }
        public string Recommendation { get; set; }
        public double ExperienceYears { get; set; }
        public BankAccount BankAccount1 { get; set; }
        public int AccountNumber { get; set; }
        public int SpacialityKey { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
