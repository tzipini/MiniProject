using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_DAL
{
    public static class FactoryDal
    {
        private static  bool isExist = false;
        private static EX_DAL.IDal instance = null;
         
        public static IDal getDal()
        {
            if (isExist == false)
            {
                instance = new DAL_IMP_XML();
                isExist = true;
            }
            return instance;
        }
    }
}
