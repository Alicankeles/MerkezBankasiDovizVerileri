using MerkezBankasiDovizVerileri.Data.Communicator.Abstract;
using MerkezBankasiDovizVerileri.Data.Entity;
using MerkezBankasiDovizVerileri.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MerkezBankasiDovizVerileri.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITCMBCommunicator _iTCMBCommunicator;
        public HomeController(ITCMBCommunicator itCMBCommunicator)
        {
            _iTCMBCommunicator = itCMBCommunicator;
        }

        public IActionResult Index()
        {
            var req = new RequestData()
            {
                Ay = 1,
                Gun = 10,
                Yil = 2023,
                IsBugun = false
            };
            var resp = _iTCMBCommunicator.Run(req);
            var viewList = new List<IndexViewModel>();
            if (resp.Data != null)
            {
                foreach (var item in resp.Data)
                {
                    var viewData = new IndexViewModel();
                    viewData.Adi = item.Adi;
                    viewData.AlisKuru = item.AlisKuru;
                    viewData.Birimi = item.Birimi;
                    viewData.EfektifAlisKuru = item.EfektifAlisKuru;
                    viewData.EfektifSatisKuru = item.EfektifSatisKuru;
                    viewData.Kodu = item.Kodu;
                    viewData.SatisKuru = item.SatisKuru;
                    viewList.Add(viewData);
                }
            }
            return View(viewList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
