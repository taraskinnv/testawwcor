﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPICarShow.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBCarShowEntities : DbContext
    {
        public DBCarShowEntities()
            //: base("name=DBCarShowEntities")
            : base("name=DBCarShowEntities")
            //: base("Server=tcp:taraskinnv.database.windows.net,1433;Initial Catalog=DBCarShow;Persist Security Info=False;User ID=taraskin;Password=3162022058Inter;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public  DbSet<Car> Car { get; set; }
        public  DbSet<CarBrand> CarBrand { get; set; }
        public  DbSet<CarOrder> CarOrder { get; set; }
        public  DbSet<Client> Client { get; set; }
        public  DbSet<Engine> Engine { get; set; }
        public  DbSet<ModelCar> ModelCar { get; set; }
        public  DbSet<PaymentTypes> PaymentTypes { get; set; }
        public  DbSet<TypeBody> TypeBody { get; set; }
    }
}
