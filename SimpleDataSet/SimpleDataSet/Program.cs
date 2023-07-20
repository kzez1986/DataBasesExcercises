using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Console;
using System.Collections;

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
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };

            var carMakeColumn = new DataColumn("Make", typeof (string));
            var carColorColumn = new DataColumn("Color", typeof(string)) { Caption = "Pet Name" };
            var carPetNameColumn = new DataColumn("PetName", typeof(string)) ;

            var inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["PetName"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);
            carRow = inventoryTable.NewRow();

            carRow[1] = "Saab";
            carRow[2] = "Red";
            carRow[3] = "Sea Breeze";
            inventoryTable.Rows.Add(carRow);

            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };

            ds.Tables.Add(inventoryTable);
        }

        private static void ManipulateDataRowState()
        {
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            var row = temp.NewRow();
            WriteLine($"After calling NewRow(): {row.RowState}");

            temp.Rows.Add(row);
            WriteLine($"After calling Row.Add(): {row.RowState}");

            row["TempColumn"] = 10;
            WriteLine($"After first assignment: {row.RowState}");

            temp.AcceptChanges();
            WriteLine($"After calling AcceptChanges: {row.RowState}");

            row["TempColumn"] = 11;
            WriteLine($"After first assignment: {row.RowState}");

            temp.Rows[0].Delete();
            WriteLine($"After calling Delete: {row.RowState}");
        }

        static void PrintDataSet(DataSet ds)
        {
            WriteLine($"DataSet is named: {ds.DataSetName}");
            foreach(DictionaryEntry de in ds.ExtendedProperties)
            {
                WriteLine($"Key = {de.Key}, Value = {de.Value}");
            }
            WriteLine();

            foreach(DataTable dt in ds.Tables)
            {
                WriteLine($"=> {dt.TableName} Table:");

                for (var curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Write($"{dt.Columns[curCol].ColumnName}\t");
                }

                WriteLine("\n---------------------------------------------");

                for(var curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for(var curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Write($"{dt.Rows[curRow][curCol]}\t");
                    }
                    WriteLine();
                }
            }
        }
        
    }
}
