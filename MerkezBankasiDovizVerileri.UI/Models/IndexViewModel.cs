using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerkezBankasiDovizVerileri.UI.Models
{
    public class IndexViewModel
    {
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public int Birimi { get; set; }
        public decimal AlisKuru { get; set; }
        public decimal SatisKuru { get; set; }
        public decimal EfektifAlisKuru { get; set; }
        public decimal EfektifSatisKuru { get; set; }
    }
}
