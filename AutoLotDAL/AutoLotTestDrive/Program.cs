using AutoLotDAL.EF;
using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
using AutoLotDAL.Repos;
using System.Data.Entity.Infrastructure;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DataInitializer());
            WriteLine("***** Fun with ADO.NET EF Code First *****\n");
            var car1 = new Inventory() { Make = "Yugo", Color = "Brown", PetName = "Brownie" };
            var car2 = new Inventory() { Make = "SmartCar", Color = "Brown", PetName = "Shorty" };
            AddNewRecord(car1);
            AddNewRecord(car2);
            AddNewRecords(new List<Inventory> { car1, car2 });
            PrintAllInventory();
            ShowAllOrders();
            ShowAllOrdersEagerlyFetched();

            PrintAllCustomersAndCreditRisks();
            var customerRepo = new CustomerRepo();
            var customer = customerRepo.GetOne(1);
            customerRepo.Context.Entry(customer).State = EntityState.Detached;
            var risk = MakeCustomerARisk(customer);
            PrintAllCustomersAndCreditRisks();

            AutoLotEntities autoLotEntities = new AutoLotEntities();


            ReadLine();
        }

        private static void AddNewRecord(Inventory car)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }

        private static void AddNewRecords(IList<Inventory> cars)
        {
            using (var repo = new InventoryRepo())
            {
                repo.AddRange(cars);
            }
        }

        private static void PrintAllInventory()
        {
            using (var repo = new InventoryRepo())
            {
                foreach(Inventory c in repo.GetAll())
                {
                    WriteLine(c);
                }
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                var carToUpdate = repo.GetOne(carId);
                if(carToUpdate != null)
                {
                    WriteLine("Before change: " + repo.Context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Blue";
                    WriteLine("After change: " + repo.Context.Entry(carToUpdate).State);
                    repo.Save(carToUpdate);
                    WriteLine("After save: " + repo.Context.Entry(carToUpdate).State);
                }
            }
        }

        private static void ShowAllOrders()
        {
            using(var repo = new OrderRepo())
            {
                WriteLine("*************** Pending Orders *****************");
                foreach(var itm in repo.GetAll())
                {
                    WriteLine($"->{itm.Customer.FullName} is waiting on {itm.Car.PetName}");
                }
            }
        }

        public static void UpdateRecordWithConcurrency()
        {
            var car = new Inventory() { Make = "Yugo", Color = "Brown", PetName = "Brownie" };
            AddNewRecord(car);
            var repo1 = new InventoryRepo();
            var car1 = repo1.GetOne(car.CarId);
            car1.PetName = "Updated";

            var repo2 = new InventoryRepo();
            var car2 = repo2.GetOne(car.CarId);
            car2.Make = "Nissan";

            repo1.Save(car1);
            try
            {
                repo2.Save(car2);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                WriteLine(ex);
            }
            //RemoveRecordById(car1.CarId, car1.Timestamp);
        }

        private static void ShowAllOrdersEagerlyFetched()
        {
            using (var context = new AutoLotEntities())
            {
                WriteLine("**************** Pending Orders **********************");
                var orders = context.Orders.Include(x => x.Customer).Include(y => y.Car).ToList();
                foreach (var itm in orders)
                {
                    WriteLine($"->{itm.Customer.FullName} is waiting on {itm.Car.PetName}");
                }
            }
        }

        private static CreditRisk MakeCustomerARisk(Customer customer)
        {
            using (var context = new AutoLotEntities())
            {
                context.Customers.Attach(customer);
                context.Customers.Remove(customer);
                var creditRisk = new CreditRisk()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };
                context.CreditRisks.Add(creditRisk);
                var creditRiskDupe = new CreditRisk()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };
                context.CreditRisks.Add(creditRiskDupe);
                try
                {
                    context.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    WriteLine(ex);
                }
                return creditRisk;
            }
        }

        private static void PrintAllCustomersAndCreditRisks()
        {
            WriteLine("********** Customers **********");
            using (var repo = new CustomerRepo())
            {
                foreach(var cust in repo.GetAll())
                {
                    WriteLine($"->{cust.FirstName} {cust.LastName} is a Customer.");
                }
            }
            WriteLine("********** Credit Risks **********");
            using (var repo = new CreditRiskRepo())
            {
                foreach(var risk in repo.GetAll())
                {
                    WriteLine($"->{risk.FirstName} {risk.LastName} is a Credit Risk!");
                }
            }
        }
    }
}
