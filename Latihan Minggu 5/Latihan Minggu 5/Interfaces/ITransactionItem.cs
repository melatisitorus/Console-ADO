using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5.Interfaces
{
    interface ITransactionItem
    {
        List<TB_T_TransactionItem> viewAllData();
        TB_T_TransactionItem get(int Id);
        bool InsertTransactionItem(TB_T_TransactionItem transactionItem);
        bool UpdateTransactionItem(int Id, TB_T_TransactionItem transactionItem);
        bool DeleteTransactionItem(int Id);
    }
}
