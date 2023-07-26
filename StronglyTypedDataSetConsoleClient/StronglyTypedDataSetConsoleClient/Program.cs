using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL.DataSets;
using AutoLotDAL.DataSets.AutoLotDataSetTableAdapters;
using static System.Console;

namespace StronglyTypedDataSetConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with strongly Typed Datasets *****\n");

            var table = new AutoLotDataSet.InventoryDataTable();

            var adapter = new InventoryTableAdapter();

            

            AddRecords(table, adapter);
            table.Clear();
            adapter.Fill(table);


            PrintInventory(table);
            CallStoredProc();
            ReadLine();
        }

        static void PrintInventory(AutoLotDataSet.InventoryDataTable dt)
        {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Write(dt.Columns[curCol].ColumnName + "\t");
            }
            WriteLine("\n-----------------------------------------------");

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Write(dt.Rows[curRow][curCol] + "\t");
                }
                WriteLine();
            }
            
        }

        public static void AddRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
        {
            try 
            {
                AutoLotDataSet.InventoryRow newRow = table.NewInventoryRow();

                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Saku";

                table.AddInventoryRow(newRow);

                table.AddInventoryRow("Yugo", "Green", "Zippy");

                adapter.Update(table);

            }   
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
        {
            try
            {
                AutoLotDataSet.InventoryRow rowToDelete = table.FindByCarId(40);
                adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
                rowToDelete = table.FindByCarId(41);
                adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public static void CallStoredProc()
        {
            try
            {
                var queriesTableAdapter = new QueriesTableAdapter();
                Write("Enter ID of car to look up: ");
                string carID = ReadLine() ?? "0";
                string carName = "";
                queriesTableAdapter.GetPetName(int.Parse(carID), ref carName);
                WriteLine($"CarID {carID} has the name of {carName}");
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}
