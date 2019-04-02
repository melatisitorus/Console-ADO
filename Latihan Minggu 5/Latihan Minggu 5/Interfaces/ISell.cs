using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5.Interfaces
{
    interface ISell
    {
        List<TB_M_Sell> viewAllData();
        TB_M_Sell get(int Id);
        bool InsertSell(TB_M_Sell sell);
        bool DeleteSell(int Id);
    }
}
