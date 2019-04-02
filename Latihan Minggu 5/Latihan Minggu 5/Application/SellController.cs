using Latihan_Minggu_5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Latihan_Minggu_5.Models;
using System.Data.Entity;

namespace Latihan_Minggu_5.Application
{
    public class SellController : ISell

    {
        public static MyContext myContext = new MyContext();
        SaveData savedata = new SaveData(myContext);
        TB_M_Sell sell = new TB_M_Sell();
        bool status = false;

        public bool DeleteSell(int Id)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Sell.Find(Id);
            if (get != null)
            {
                myContext.Entry(get).State = System.Data.Entity.EntityState.Deleted;
                return savedata.Save(myContext);
            }
            else
            {
                Console.Write("Data Not Found");
            }
            return status;
        }

        public TB_M_Sell get(int Id)
        {
            var get = myContext.TB_M_Sell.Find(Id);
            return get;
        }

        public bool InsertSell(TB_M_Sell sell)
        {
            sell.OrderDate = DateTime.Now;
            myContext.TB_M_Sell.Add(sell);
            return savedata.Save(myContext);
        }
        

        public List<TB_M_Sell> viewAllData()
        {
            var get = myContext.TB_M_Sell.Where(x => x.IsDelete == false).ToList();
            Console.WriteLine("============================");
            Console.WriteLine("\t Data Sell");
            Console.WriteLine("============================");
            foreach (var list in get)
            {
                Console.Write("Id : ");
                Console.WriteLine(list.Id);
                Console.Write("Order Date :");
                Console.WriteLine(list.OrderDate);
            }
            return get;
        }
    }
}
