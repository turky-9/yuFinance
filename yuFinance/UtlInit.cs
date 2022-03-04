using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuFinance
{
    public class UtlInit
    {
        public static int Number() => -1;
        public static decimal Amount() => -1;
        public static bool False() => false;
        public static DateTime DateTime() => new DateTime(1000, 1, 1);
        public static EDrCrKbn DrCrKbn() => EDrCrKbn.None;
        public static EKmkKbn KmkKbn() => EKmkKbn.None;
        public static string String() => string.Empty;
        public static DatKmk Kmk() => new DatKmk(); 
        public static DatTr Tr() => new DatTr();
        public static List<T> DatList<T>() => new List<T>();
    }
}
