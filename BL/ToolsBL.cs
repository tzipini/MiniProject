using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BL
{
    public static class ToolsBL
    {
        public static int getAge(this DateTime dt, DateTime d)
        {
            return dt.Year - d.Year;
        }
        public static bool CheckId(int id)
        {
            return LegalId(Convert.ToString(id));
        }

        public static bool IsLetters(string name)//בודק האם הערך שהתקבל כולל אך ורק אותיות בעברית
        {
            // pattern = @"\b[ת-א-]\s$" + @"\b[A-z]\s$";
            //Regex reg = new Regex(pattern);
            //return reg.IsMatch(name);
            return true;
        }

        public static bool IsntNull(string s)//null בודק האם הערך שהתקבל הוא 
        {
            return !string.IsNullOrEmpty(s);
        }
        public static bool IsCellPhone(string tel)//בודק האם המספר שהתקבל הוא מספר פלאפון
        {
            if (tel.Length != 10)
                return false;
            if ((tel[0] == 0) && (tel[1] == 5))
                if ((tel[2] == 2) || (tel[2] == 0) || (tel[2] == 4) || (tel[2] == 7) || (tel[2] == 8) ||(tel[2]==3))
                    return true;
            return false;
        }
        public static bool IsPhone(string tel)//בודק האם המספר שהתקבל הוא מספר טלפון
        {
            if ((tel.Length == 9) || (tel.Length == 10))
                return true;
            return false;
        }
        public static bool LegalId(string id)//בודק את המחרוזת שהתקבלה אם היא מייצגת מס' ת"ז חוקי
        {
            int x;
            if (!int.TryParse(id, out x))
                return false;
            if (id.Length < 5 || id.Length > 9)
                return false;
            for (int i = id.Length; i < 9; i++)
                id = "0" + id;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(id[i] - '0'));
                if (k > 9)
                    k -= 9;
                sum += k;
            }
            return sum % 10 == 0;
        }
        public static bool IsNumber(string num)
        {
            long x;
            if (long.TryParse(num, out x))
                return true;
            return false;
        }
    }
}

