using Latihan_Minggu_5.Interfaces;
using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5
{
    public class TransactionItemController :ITransactionItem
    {
        private MyContext myContext = new MyContext();
        saveData saveData = new saveData();
        bool status = false;
        private object savedata;

        public int Quantity { get; private set; }

        public bool DeleteTransactionItem(int Id)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_T_TransactionItem.Find(Id);
            if (get != null)
            {
                myContext.Entry(get).State = EntityState.Modified;
                return saveData.Save(myContext);
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
            {
                Collection <TB_T_TransactionItem> itemPurchase = new Collection <TB_T_TransactionItem>();
                bool Purchase;
                string decision;
                Purchase = true;
                int sell= Save(); 

                do
                {
                    Console.Write("Kode Barang Yang Ingin Di beli :");
                    int Id = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Insert Your Quantity :");
                    int quantity = Convert.ToInt16(Console.ReadLine());

                    ItemController itemController = new ItemController(myContext);
                    TB_T_TransactionItem transactionItem = new TB_T_TransactionItem();
                    transactionItem.Quantity = Quantity;
                    transactionItem.TB_M_Items = itemController.get(Id);
                    transactionItem.TB_M_Sell = get(sell);
                    itemPurchase.Add(transactionItem);

                    Console.WriteLine("Lanjutkan Pembelian? (Y/N)");
                    decision = Console.ReadLine();
                    if (decision.ToUpper() == "Y")
                    {
                        Purchase = true;
                    }
                    else
                    {
                        Purchase = false;
                    }
                } while (Purchase == true);

                foreach (var list in itemPurchase)
                {
                    myContext.TB_T.TransactionItem.Add(list);
                }
                return Latihan_Minggu_5.saveData.Save(myContext);
            }
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
            var get = myContext.TB_T_TransactionItem.();
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
