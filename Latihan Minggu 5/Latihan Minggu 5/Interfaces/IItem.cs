using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5
{
    public interface IItem
    {
        List<TB_M_Items> viewAllData();
        TB_M_Items get(int Id);
        bool InsertItem(TB_M_Items item);
        bool UpdateItem(int Id, TB_M_Items item);
        bool DeleteItem(int Id);
    }
}
