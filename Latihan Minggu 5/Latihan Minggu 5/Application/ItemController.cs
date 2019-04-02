using Latihan_Minggu_5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_Minggu_5
{
    public class ItemController : IItem
    {
        public static MyContext myContext = new MyContext();
        SaveData savedata = new SaveData(myContext);
        bool status = false;

        public bool DeleteItem(int Id)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Items.Find(Id);
            if (get != null)
            {
                myContext.Entry(get).State = EntityState.Deleted;
                //var result = (myContext.SaveChanges());
                //if (result > 0)
                //{
                //    Console.Write("Delete Succes");
                //    status = true;
                //}
                //else
                //{
                //    Console.Write("Delete Failed");
                //}
                return savedata.Save(myContext);
            }
            else
            {
                Console.Write("Data Not Found");
            }
            return status;
        }

        public TB_M_Items get(int Id)
        {
            Console.Write("Insert Your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Items.SingleOrDefault(x => x.Id==Id);
            Console.Write("Id : ");
            Console.WriteLine(get.Id);
            Console.Write("Name :");
            Console.WriteLine(get.Name);
            Console.Write("Supplier Id");
            Console.WriteLine(get.TB_M_Suppliers_Id);
            Console.Write("Price");
            Console.WriteLine(get.Price);
            Console.Write("Stock");
            Console.WriteLine(get.Stock);
            Console.WriteLine("");
            return get;
        }

        public bool InsertItem(TB_M_Items item)
        {
            TB_M_Suppliers supplier = new TB_M_Suppliers();
            Console.Write("Insert your name : ");
            string Name = Console.ReadLine();
            //Console.Write("Insert Supplier ID :");
            //int TB_M_Suppliers_Id = Convert.ToInt16(Console.ReadLine());
            supplier = get();
            Console.Write("Insert Price :");
            int Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insert Stock : ");
            int Stock = Convert.ToInt16(Console.ReadLine());
            if (supplier != null)
            {
                item.Name = Name;
                item.TB_M_Suppliers = supplier;
                item.Price = Price;
                item.Stock = Stock;

                myContext.TB_M_Items.Add(item);
                //var result = (myContext.SaveChanges());
                //if (result > 0)
                //{
                //    status = true;
                //    Console.Write("Insert Successfully");
                //}
                //else
                //{
                //    Console.Write("Insert Failed");
                //}
                return savedata.Save(myContext);
            }
            return status;
        }

        public bool UpdateItem(int Id, TB_M_Items item)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Items.Find(Id);
            if (get != null)
            {
                Console.Write("Insert Your Name :");
                string Name = Console.ReadLine();
                get.Name = Name;
                Console.Write("Insert Price :");
                int Price = Convert.ToInt32(Console.ReadLine());
                get.Price = Price;
                Console.Write("Insert Stock : ");
                int Stock = Convert.ToInt16(Console.ReadLine());
                get.Stock = Stock;
                myContext.Entry(get).State = EntityState.Modified;
                //var result = (myContext.SaveChanges());
                //if (result > 0)
                //{
                //    Console.Write("Update Succes");
                //    status = true;
                //}
                //else
                //{
                //    Console.Write("Update Failed");
                //}
                return savedata.Save(myContext);
            }
            else
            {
                Console.Write("Data Not Found");
            }
            return status;
        }

        public List<TB_M_Items> viewAllData()
        {
            var get = myContext.TB_M_Items.Where(x => x.IsDelete == false).ToList();
            Console.WriteLine("============================");
            Console.WriteLine("\t Data Item");
            Console.WriteLine("============================");
            foreach (var list in get)
            {
                Console.Write("Id : ");
                Console.WriteLine(list.Id);
                Console.Write("Name :");
                Console.WriteLine(list.Name);
                Console.Write("Supplier Id");
                Console.WriteLine(list.TB_M_Suppliers_Id);
                Console.Write("Price");
                Console.WriteLine(list.Price);
                Console.Write("Stock");
                Console.WriteLine(list.Stock);
                Console.WriteLine("");
            }
            return get;
        }

        public TB_M_Suppliers get()
        {
            Console.Write("Insert Your Supplier Id : ");
            int Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Suppliers.Find(Id);
            return get;
        }
        }
}
