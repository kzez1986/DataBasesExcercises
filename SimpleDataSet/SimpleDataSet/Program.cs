using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Console;

namespace SimpleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with DataSets *****\n");

            var carsInventoryDS = new DataSet("Car Inventory");

            carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventoryDS.ExtendedProperties["Company"] = "Mikko's Hot Tub Super Store";
            FillDataSet(carsInventoryDS);
            PrintDataSet(carsInventoryDS);
            ReadLine();

        }

        static void FillDataSet(DataSet ds)
        {
            var carIDColumn = new DataColumn("CarID", typeof(int))
            {
                Caption = "Card ID",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
            };

            var carMakeColumn = new DataColumn("Make", typeof (string));
            var carColorColumn = new DataColumn("Color", typeof(string)) { Caption = "Pet Name" };
            var carPetNameColumn = new DataColumn("PetName", typeof(string)) ;       }
    }
}
