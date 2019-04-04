using Latihan_Minggu_5;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Latihan_Minggu_5.Models;

namespace Latihan1
{
    public class SupplierController : ISupplier

    {
        public static MyContext myContext = new MyContext();
        saveData savedata = new saveData(myContext);
        bool status = false;
        public bool DeleteSupplier(int Id)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Suppliers.Find(Id);
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

        public TB_M_Suppliers get(int Id)
        {
            var get = myContext.TB_M_Suppliers.Find(Id);
            return get;
        }
        
        public bool InsertSupplier(TB_M_Suppliers supplier)
        {
            Console.Write("Insert your name : ");
            string Name = Console.ReadLine();
            supplier.Name = Name;
            myContext.TB_M_Suppliers.Add(supplier);
            return savedata.Save(myContext); 
        }

        public bool UpdateSupplier(int Id, TB_M_Suppliers supplier)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Suppliers.Find(Id);
            if (get != null)
            {
                Console.Write("Insert Your Name :");
                string Name = Console.ReadLine();
                get.Name = Name;
                myContext.Entry(get).State = EntityState.Modified;
                return savedata.Save(myContext);
            }
            else
            {
                Console.Write("Data Not Found");
            }
            return status;
        }

        public List<TB_M_Suppliers> viewAllData()
        {
            var get = myContext.TB_M_Suppliers.Where(x => x.IsDelete == false).ToList();
            Console.WriteLine("============================");
            Console.WriteLine("\t Data Supplier");
            Console.WriteLine("============================");
            foreach (var list in get)
            {
                Console.Write("Id : ");
                Console.WriteLine(list.Id);
                Console.Write("Name :");
                Console.WriteLine(list.Name);
            }
            return get;
        }
    }
}
