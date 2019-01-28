using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{

    public class  Specialization
    {
        public int Key { get; set; }
        public NameSpecialty SpecialtyName { get; set; }
        public string Speciality { get; set; }
        public double MinRate { get; set; }
        public double MaxRate { get; set; }


        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
