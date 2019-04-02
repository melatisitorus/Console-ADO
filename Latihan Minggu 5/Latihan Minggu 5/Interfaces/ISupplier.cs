using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5
{
    public interface ISupplier
    {
        List<TB_M_Suppliers> viewAllData();
        TB_M_Suppliers get(int Id);
        bool InsertSupplier(TB_M_Suppliers supplier);
        bool UpdateSupplier(int Id, TB_M_Suppliers supplier);
        bool DeleteSupplier(int Id);
    }
}
