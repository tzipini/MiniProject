using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int  Key { get; set; }
        public int  EmployerKey { get; set; }
        public int EmployeeId { get; set; }
        public bool IsInterviewed { get; set; }
        public bool IsSinged { get; set; }
        public double HourlyWageBruto { get; set; }
        public double HourlyWageNeto { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double NumOfHoursToMonth { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
