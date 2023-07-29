using AutoLotDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());
            WriteLine("***** Fun with ADO.NET EF Code First *****\n");
            ReadLine();
        }
    }
}
