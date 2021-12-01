using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Application.Visitors.SaveVisitorInfo
{
    public interface ISaveVisitorInfoService
    {
        void Ececute(RequestSaveVisitorInfoDto request);
    }
}
