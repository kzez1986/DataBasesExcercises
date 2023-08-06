namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using AutoLotDAL.Models;

    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL.Interception;
    using System.Data.Entity.Core.Objects;

    public class AutoLotEntities : DbContext
    {
        // Your context has been configured to use a 'AutoLotEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AutoLotDAL.EF.AutoLotEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AutoLotEntities' 
        // connection string in the application configuration file.
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            DbInterception.Add(new ConsoleWriterInterception());

            DatabaseLogger.StartLogging();
            
            DbInterception.Add(DatabaseLogger);

            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;

            //DatabaseLogger.StartLogging();
            //DbInterception.Add(DatabaseLogger);

        }
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
            public virtual DbSet<Customer> Customers { get; set; }
            public virtual DbSet<Inventory> Inventory { get; set; }
            public virtual DbSet<Order> Orders { get; set; }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);


        }

        public void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            {
                if((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if(entity.Color == "Red")
                    {
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                }
            }
        }

        private void OnObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {

        }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}