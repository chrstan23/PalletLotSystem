using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalletLotSystem
{
    public static class UserSession
    {
        public static string FullName { get; set; }
        public static string CompanyId { get; set; }
        public static int Privilege { get;  set; }
    }
}
