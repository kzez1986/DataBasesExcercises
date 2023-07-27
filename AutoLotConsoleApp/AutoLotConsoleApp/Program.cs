using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotConsoleApp.EF;
using static System.Console;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with ADO.NET EF *****\n");
            //int carId = AddNewRecord();
            //WriteLine(carId);
            PrintAllInventory();
            //FunWithLinqQueries();
            ReadLine();
        }

        private static int AddNewRecord()
        {
            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Car() { Make = "Yugo", Color = "Brown", CarNickName = "Brownie" };
                    context.Cars.Add(car);
                    context.SaveChanges();

                    return car.CarId;

                }
                catch(Exception ex)
                {
                    WriteLine(ex.InnerException.Message);
                    return 0;
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                //foreach(Car c in context.Cars)
                //{
                //    WriteLine(c);
                //}

                //foreach (Car c in context.Cars.SqlQuery("Select CarId,Make,Color,PetName as CarNickName from Inventory where Make=@p0", "BMW"))
                //{
                //    WriteLine(c);
                //}

                foreach (Car c in context.Cars.Include("Orders"))
                {
                    foreach (Order o in c.Orders)
                    {
                        WriteLine(o.OrderId);
                    }
                }
            }
        }

        private static void FunWithLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                var colorMakes = from item in context.Cars select new { item.Color, item.Make };
                foreach (var item in colorMakes)
                {
                    WriteLine(item);
                }

                var blackCars = from item in context.Cars where item.Color == "Black" select item;
                foreach (var item in blackCars)
                {
                    WriteLine(item);
                }
            }
        }
    }
}
