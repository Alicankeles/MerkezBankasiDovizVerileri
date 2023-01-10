using MerkezBankasiDovizVerileri.Data.Communicator.Abstract;
using MerkezBankasiDovizVerileri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MerkezBankasiDovizVerileri.Data.Communicator.Concrete
{
    public class TCMBCommunicator : ITCMBCommunicator
    {
        public ResponseData Run(RequestData request)
        {
            ResponseData result = new ResponseData();
            try
            {
                string tcmbLink = string.Format("http://www.tcmb.gov.tr/kurlar/{0}.xml", (request.IsBugun) ? "today" : string.Format("{2}{1}/{0}{1}{2}", request.Gun.ToString().PadLeft(2, '0'), request.Ay.ToString().PadLeft(2, '0'), request.Yil));

                result.Data = new List<ResponseDataKur>();

                XmlDocument doc = new XmlDocument();

                doc.Load(tcmbLink);

                if (doc.SelectNodes("Tarih_Date").Count < 1)
                {
                    result.Hata = "Kur Bilgisi Bulunamadı";
                }

                foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
                {
                    ResponseDataKur kur = new ResponseDataKur();

                    kur.Kodu = node.Attributes["Kod"].Value;
                    kur.Adi = node["Isim"].InnerText;
                    kur.Birimi = int.Parse(node["Unit"].InnerText);
                    kur.AlisKuru = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
                    kur.SatisKuru = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
                    kur.EfektifAlisKuru = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
                    kur.EfektifSatisKuru = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));

                    result.Data.Add(kur);


                }
            }
            catch (Exception ex)
            {
                result.Hata = ex.Message;
            }

            return result;
        }
    }
}
