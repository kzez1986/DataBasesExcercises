﻿using AutoLotDAL.Models;
using System;
using System.Activities.Debugger;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.Repos
{
    public class CustomerRepo : BaseRepo<Customer>, IRepo<Customer>
    {
        public CustomerRepo()
        {
            Table = Context.Customers;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Customer() { CustId = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();

        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Customer() { CustId = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
