using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Movements.Data.Mappings;
using Movements.Domain.Entities;
using System;
using System.Linq;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Cosif> Cosif { get; set; }
        public DbSet<Movement> Moviments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CosifMap());
            modelBuilder.ApplyConfiguration(new MovementsMap());

            ApplyGlobalStandards(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

            Product[] _products = new[]
            {
                    new Product { CodProduct = "0001", Description = "Notebook", Status = "A"},
                    new Product { CodProduct = "0002", Description = "Book", Status = "I"},
                    new Product { CodProduct = "0003", Description = "Head Phone", Status = "A"}
             };

            Cosif[] _cosifs = new[]
            {
                    new Cosif {  CodCosif = "00000000001", CodClassification = "000001", Status = "A"},
                    new Cosif {  CodCosif = "00000000002", CodClassification = "000002", Status = "I"},
                    new Cosif {  CodCosif = "00000000003", CodClassification = "000003", Status = "A"}
             };


            modelBuilder.Entity<Product>().HasData(_products);
            modelBuilder.Entity<Cosif>().HasData(_cosifs);
        }

        private ModelBuilder ApplyGlobalStandards(ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList()
                    .ForEach(fe => fe.DeleteBehavior = DeleteBehavior.Restrict);

                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.UpdatedData):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.CreatedDate):
                            property.IsNullable = false;
                            property.SetColumnType("datetime");
                            property.SetDefaultValueSql("CURRENT_TIMESTAMP");
                            break;
                        case nameof(Entity.IsActive):
                            property.IsNullable = false;
                            property.SetDefaultValue(true);
                            break;
                    }
                }
            }

            return builder;
        }
    }
}
