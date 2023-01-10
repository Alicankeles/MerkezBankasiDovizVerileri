using System;
using System.Collections.Generic;
using System.Text;

namespace MerkezBankasiDovizVerileri.Data.Entity
{
    public class RequestData
    {
        public int Gun { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public bool IsBugun { get; set; }
    }
}
