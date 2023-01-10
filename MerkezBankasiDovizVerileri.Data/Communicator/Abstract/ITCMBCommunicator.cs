using MerkezBankasiDovizVerileri.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerkezBankasiDovizVerileri.Data.Communicator.Abstract
{
    public interface ITCMBCommunicator
    {
        ResponseData Run(RequestData request);
    }
}
