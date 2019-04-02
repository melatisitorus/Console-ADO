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
        SaveData savedata = new SaveData(myContext);
        bool status = false;
        public bool DeleteSupplier(int Id)
        {
            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = myContext.TB_M_Suppliers.Find(Id);
            if (get != null)
            {
                myContext.Entry(get).State = System.Data.Entity.EntityState.Deleted;
                //    var result = (myContext.SaveChanges());
                //    if (result > 0)
                //    {
                //        Console.Write("Delete Succes");
                //        status = true;
                //    }
                //    else
                //    {
                //        Console.Write("Delete Failed");
                //    }
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
