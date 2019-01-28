using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Tools
    {
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetRuntimeProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            return str;
        }
    }
    public enum Degree { DIPLOMA = 0, BA = 1, MA = 2, PHD = 3, student = 4 };
    public enum NameSpecialty { DataBase = 1, Syber = 2, ServerPrograming = 3, MobilePrograming = 4, InterfacesDesign = 5, Networks = 6 };
    public enum Area {GushDan =  1 , Hasharon = 2 , Jerusalem = 3 , Negev = 4, Shfela = 5,Galil =6,Haifa = 7};

    public struct BankAccount
    {
        public string BankName { get; set; }
        public int BankKey { get; set; }
        public int BranchNumber { get; set; }
        public string Town { get; set; }
    }
}
