using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Collections;
using static System.Console;
using System.Data.Common;

namespace FillDataSetUsingSqlDataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with Data Adapters *****\n");

            string connectionString = "Integrated Security = SSPI;Initial Catalog=Autolot;" + @"Data Source=(local)\";

            DataSet ds = new DataSet("AutoLot");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * From Inventory", connectionString);

            DataTableMapping tableMapping = adapter.TableMappings.Add("Inventory", "Current Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car Id");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");
            
            adapter.Fill(ds, "Inventory");

            PrintDataSet(ds);
            ReadLine();
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

                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Write(dt.Columns[curCol].ColumnName + "\t");
                } 
                WriteLine("\n----------------------------------------------");

                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                    }
                    WriteLine();
                }
            }

        }
    }
}
