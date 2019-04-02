using Latihan_Minggu_5.Application;
using Latihan_Minggu_5.Interfaces;
using Latihan_Minggu_5.Models;
using Latihan1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Latihan_Minggu_5
{
    class Program
    {
        static Program program = new Program();
        SupplierController supplierController = new SupplierController();
        ItemController itemController = new ItemController();
        SellController sellController = new SellController();
        TransactionItemController transactionItemController = new TransactionItemController();
        TB_M_Suppliers supplier = new TB_M_Suppliers();
        TB_M_Items item = new TB_M_Items();
        TB_M_Sell sell = new TB_M_Sell();
        TB_T_TransactionItem transactionItem = new TB_T_TransactionItem();
        ISupplier iSupplier;
        IItem iItem;
        ISell iSell;
        ITransactionItem iTransactionItem;
        int Id;

        static void Main(string[] args)
        {
            program.Menu();
            Console.Read();
        }


        public void Menu()
        {
            int pilih;
            Console.WriteLine("======================");
            Console.WriteLine("Transaksi Menu ");
            Console.WriteLine("======================");
            Console.WriteLine("1. Supplier Menu ");
            Console.WriteLine("2. Item Menu ");
            Console.WriteLine("3. Sell Menu");
            Console.WriteLine("4. Transaction Item Menu");
            Console.WriteLine("======================");
            Console.Write("Input Your Choice : ");
            pilih = Convert.ToInt16(Console.ReadLine());
            
            switch (pilih)
            {
                case 1:
                    program.MenuSuppliers();
                    break;
                case 2:
                    program.MenuItems();
                    break;
                case 3:
                    program.MenuSell();
                    break;
                case 4:
                    program.MenuTransactionItem();
                    break;
                default:
                    Console.WriteLine("........");
                    Console.Read();
                    break;
            }
        }

        public int MenuSuppliers()
        {
            int Pilih;
            Console.WriteLine("======================");
            Console.WriteLine("Menu Supplier");
            Console.WriteLine("======================");
            Console.WriteLine("1. View Data");
            Console.WriteLine("2. View Data By Id");
            Console.WriteLine("3. Insert Data");
            Console.WriteLine("4. Upadate Data");
            Console.WriteLine("5. Delete Data");
            Console.WriteLine("======================");
            Console.Write("Input Pilihan : ");
            Pilih = Convert.ToInt16(Console.ReadLine());

            switch (Pilih)
            {
                case 1:
                    iSupplier = new SupplierController();
                    supplierController.viewAllData();
                    Console.Read();
                    break;
                case 2:
                    iSupplier = new SupplierController();
                    supplierController.get(Id);
                    Console.Read();
                    break;
                case 3:
                    iSupplier = new SupplierController();
                    iSupplier.InsertSupplier(supplier);
                    Console.Read();
                    break;
                case 4:
                    iSupplier = new SupplierController();
                    iSupplier.UpdateSupplier(Id, supplier);
                    Console.Read();
                    break;
                case 5:
                    iSupplier = new SupplierController();
                    iSupplier.DeleteSupplier(Id);
                    Console.Read();
                    break;
            }
            return Pilih;
         }

        public int MenuItems()
        {
            int pilih;
            Console.WriteLine("======================");
            Console.WriteLine("Menu Item");
            Console.WriteLine("======================");
            Console.WriteLine("1. View All Data");
            Console.WriteLine("2. View Data By Id");
            Console.WriteLine("3. Insert Data");
            Console.WriteLine("4. Update Data");
            Console.WriteLine("5. Delete Data");
            Console.WriteLine("======================");
            Console.Write("input pilihan : ");
            pilih = Convert.ToInt16(Console.ReadLine());

            switch (pilih)
            {
                case 1:
                    itemController.viewAllData();
                    Console.Read();
                    break;
                case 2:
                    iItem = new ItemController();
                    itemController.get(Id);
                    Console.Read();
                    break;
                case 3:
                    iItem = new ItemController();
                    iItem.InsertItem(item);
                    Console.Read();
                    break;
                case 4:
                    int id = 0;
                    iItem = new ItemController();
                    iItem.UpdateItem(id, item);
                    Console.Read();
                    break;
                case 5:
                    iItem.DeleteItem(Id);
                    Console.Read();
                    break;
            }
            return pilih;
        }

        public int MenuSell()
        {
            int Pilih;
            Console.WriteLine("======================");
            Console.WriteLine("Menu Sell");
            Console.WriteLine("======================");
            Console.WriteLine("1. View All Data");
            Console.WriteLine("2. View Data By Id");
            Console.WriteLine("3. Insert Data");
            Console.WriteLine("4. Delete Data");
            Console.WriteLine("======================");
            Console.Write("Input Pilihan : ");
            Pilih = Convert.ToInt16(Console.ReadLine());

            switch (Pilih)
            {
                case 1:
                    sellController.viewAllData();
                    Console.Read();
                    break;
                case 2:
                    iSell = new SellController();
                    sellController.get(Id);
                    Console.Read();
                    break;
                case 3:
                    iSell = new SellController();
                    iSell.InsertSell(sell);
                    Console.Read();
                    break;
                case 4:
                    iSell = new SellController();
                    iSell.DeleteSell(Id);
                    Console.Read();
                    break;
            }
            return Pilih;
        }


        public int MenuTransactionItem()
        {
            int Pilih;
            Console.WriteLine("======================");
            Console.WriteLine("Menu Transaction Item");
            Console.WriteLine("======================");
            Console.WriteLine("1. View Data");
            Console.WriteLine("2. Insert Data");
            Console.WriteLine("3. Upadate Data");
            Console.WriteLine("4. Delete Data");
            Console.WriteLine("======================");
            Console.Write("Input Pilihan : ");
            Pilih = Convert.ToInt16(Console.ReadLine());

            switch (Pilih)
            {
                case 1:
                    transactionItemController.viewAllData();
                    Console.Read();
                    break;
                case 2:
                    iTransactionItem = new TransactionItemController();
                    iTransactionItem.InsertTransactionItem(transactionItem);
                    Console.Read();
                    break;
                case 3:
                    iTransactionItem = new TransactionItemController();
                    iTransactionItem.UpdateTransactionItem(Id, transactionItem);
                    Console.Read();
                    break;
                case 4:
                    iTransactionItem = new TransactionItemController();
                    iTransactionItem.DeleteTransactionItem(Id);
                    Console.Read();
                    break;
            }
            return Pilih;
        }
    }
}
