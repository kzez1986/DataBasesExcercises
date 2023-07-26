using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;
using static System.Console;

namespace LinqToDataSetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** LINQ over DataSet *****");

            AutoLotDataSet dal = new AutoLotDataSet();
            InventoryTableAdapter tableAdapter = new InventoryTableAdapter();
            AutoLotDataSet.InventoryDataTable data = tableAdapter.GetData();

            BuildDataTableFromQuery(data);

            ReadLine();
        }

        static void ShowRedCars(DataTable data)
        {
            var cars = from car in data.AsEnumerable() where car.Field<string>("Color") == "Red" select new { ID = car.Field<int>("CarID"), Make = car.Field<string>("Make") };
            WriteLine("Here are the red cars we have in stock:");
            foreach(var item in cars)
            {
                WriteLine($"-> CarID = {item.ID} is {item.Make}");
            }
        }

        static void PrintAllCarIDs(System.Data.DataTable data)
        {
            EnumerableRowCollection enumData = data.AsEnumerable();

            foreach (DataRow r in enumData)
            {
                WriteLine($"Car ID = {r["CarID"]}");
            }
        }

        static void BuildDataTableFromQuery(DataTable data)
        {
            var cars = from car in data.AsEnumerable() where car.Field<int>("CarID") > 5 select car;
            DataTable newTable = cars.CopyToDataTable();


            for (int curRow = 0; curRow < newTable.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < newTable.Columns.Count; curCol++)
                {
                    Write(newTable.Rows[curRow][curCol].ToString().Trim() + "\t");
                }
                WriteLine();
            }
        }
    }
}
