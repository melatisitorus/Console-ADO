using Latihan_Minggu_5.Interfaces;
using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5
{
    public class TransactionItemController :ITransactionItem
    {
        private MyContext myContext = new MyContext();
        SaveData saveData = new SaveData();
        bool status = false;
        private object savedata;

        public bool DeleteTransactionItem(int Id)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_T_TransactionItem.Find(Id);
            if (get != null)
            {
                myContext.Entry(get).State = EntityState.Modified;
                //return savedata.Save(myContext);
            }
            else
            {
                Console.Write("Data Not Found");
            }
            return status;
        }

        public TB_T_TransactionItem get(int Id)
        {
            var get = myContext.TB_T_TransactionItem.SingleOrDefault(x => x.Id == Id);
            return get;
        }

        public bool InsertTransactionItem(TB_T_TransactionItem transactionItem)
        {
            TB_M_Items item = new TB_M_Items();
            TB_M_Sell sell = new TB_M_Sell();
            Console.Write("Insert Your Quantity : ");
            int Quantity = Convert.ToInt16(Console.ReadLine());
            Console.Write("Insert Sell : ");
            sell = get();
            if (sell != null)
            {

                //item = get(); 
                //if (item != null)
                //{
                    transactionItem.Quantity = Quantity;
                    transactionItem.TB_M_Items = item;
                    transactionItem.TB_M_Sell = sell;
                    myContext.TB_T_TransactionItem.Add(transactionItem);
                //}
             }

            return saveData.Save(myContext);
        }

        private TB_M_Sell get()
        {
            int Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Sell.Find(Id);
            return get;
        }

        public bool UpdateTransactionItem(int Id, TB_T_TransactionItem transactionItem)
        {
            int Quantity;
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_T_TransactionItem.Find(Id);
            if (get != null)
            {
                Console.Write("Insert Your Quantity :");
                Quantity = Convert.ToInt16(Console.ReadLine());
                get.Quantity = Quantity;
                myContext.Entry(get).State = EntityState.Modified;
                //return savedata.Save(myContext);
            }
            else
            {
                Console.Write("Data Not Found");
            }
            return status;
        }

        public List<TB_T_TransactionItem> viewAllData()
        {
            var get = myContext.TB_T_TransactionItem.Where(x => x.IsDelete == false).ToList();
            Console.WriteLine("============================");
            Console.WriteLine("\t Data Transaction Item ");
            Console.WriteLine("============================");
            foreach (var list in get)
            {
                Console.Write("Id : ");
                Console.WriteLine(list.Id);
                Console.Write("Quantity :");
                Console.WriteLine(list.Quantity);
                Console.Write("Item Id");
                Console.WriteLine(list.TB_M_Item_Id);
                Console.Write("Sell Id");
                Console.WriteLine(list.TB_M_Sell_Id);
                Console.WriteLine("");
            }
            return get;
        }

        
    }
}
