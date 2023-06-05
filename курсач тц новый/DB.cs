using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_тц_новый
{
    public class DB
    {
        //internal static object TblReplacements;
        private static MalldbContext Instance;
        public static MalldbContext GetInstance()
        {
            if (Instance == null)
                Instance = new MalldbContext();
            
            return Instance;
        }
    }
}
