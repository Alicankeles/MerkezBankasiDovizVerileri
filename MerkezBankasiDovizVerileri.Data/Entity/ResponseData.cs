using System;
using System.Collections.Generic;
using System.Text;

namespace MerkezBankasiDovizVerileri.Data.Entity
{
    public class ResponseData
    {
        public List<ResponseDataKur> Data { get; set; }
        public string Hata { get; set; }
    }
    public class ResponseDataKur
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
