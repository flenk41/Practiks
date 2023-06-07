using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Practika
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TechnicalData> TechnicalData { get; set; }
        public virtual DbSet<TypeBody> TypeBody { get; set; }
        public virtual DbSet<TypeEngine> TypeEngine { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Manager)
                .HasForeignKey(e => e.idManeger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mark>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Mark)
                .HasForeignKey(e => e.IdMark)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.CodeProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.TechnicalData)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.CodeProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeBody>()
                .HasMany(e => e.TechnicalData)
                .WithRequired(e => e.TypeBody)
                .HasForeignKey(e => e.IdTypeBody)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeEngine>()
                .HasMany(e => e.TechnicalData)
                .WithRequired(e => e.TypeEngine)
                .HasForeignKey(e => e.IdTypeEngine)
                .WillCascadeOnDelete(false);
        }
    }
}
