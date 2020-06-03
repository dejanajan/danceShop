namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;
    using System.Data.SqlClient;
    using System.Diagnostics;

    public class DanceShopContext : DbContext
    {
         public DanceShopContext()
            : base("DanceShopContext")
        {
            System.Data.Entity.Database.SetInitializer(new
                System.Data.Entity.DropCreateDatabaseIfModelChanges<DanceShopContext>());
        }

        public DbSet<Model.Customer> Customers { get; set; }
        public DbSet<Model.Equipment> Equipments { get; set; }
        public DbSet<Model.Shop> Shops { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Customer>()
        //        .Property(e => e.Surname)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Customer>()
        //        .Property(e => e.Address)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Customer>()
        //        .Property(e => e.Email)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Equipment>()
        //        .Property(e => e.EquipmentType)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Equipment>()
        //        .Property(e => e.Producer)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Equipment>()
        //        .Property(e => e.Country)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Equipment>()
        //        .Property(e => e.Telephone)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Equipment>()
        //        .Property(e => e.Email)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Equipment>()
        //        .Property(e => e.Price)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Shop>()
        //        .Property(e => e.Location)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Shop>()
        //        .Property(e => e.CustomerName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Shop>()
        //        .Property(e => e.EquipmentName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Shop>()
        //        .Property(e => e.EquipmentType)
        //        .IsUnicode(false);
        //}


    }
}
