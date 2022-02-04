using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Movements.Data.Mappings;
using Movements.Domain.Entities;
using System;
using System.Linq;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleProfile> ModuleProfiles { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Cosif> Cosif { get; set; }

        public DbSet<Movement> Moviments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new ModuleMap());
            modelBuilder.ApplyConfiguration(new ModuleProfileMap());

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CosifMap());
            modelBuilder.ApplyConfiguration(new MovementsMap());

            ApplyGlobalStandards(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Module[] _modules = new[]
            {
                new Module { Id = 1, Name = "Dashboard", Icon = "dashboard.png", URL = "dashboard", IsActive = true, Sequence = 1 },
                new Module { Id = 2, Name = "Users", Icon = "users.png", URL = "users", IsActive = true, Sequence = 2 },
                new Module { Id = 3, Name = "Account", Icon = "accounts.png", URL = "accounts", IsActive = true, Sequence = 3 },
            };

            Profile[] _profiles = new[]
            {
                new Profile { Id = 1, Name = "Admin", IsActive = true },
                new Profile { Id = 2, Name = "User", IsActive = true, IsDefault = true }
            };

            User[] _users = new[]
            {
                new User { Id = 1, Name = "Admin", IsActive = true, Email = "admin@template.com",
                    IsAuthorised = true, Password = "8D66A53A381493BEC08DA23CEF5A43767F20A42C", CreatedUser = 1,
                    CreatedDate = DateTime.Now, ProfileId = 1},
                new User { Id = 2, Name = "User", IsActive = true, Email = "user@template.com",
                    IsAuthorised = true, Password = "8D66A53A381493BEC08DA23CEF5A43767F20A42C", CreatedUser = 1,
                    CreatedDate = DateTime.Now, ProfileId = 2}
            };
            
            ModuleProfile[] _moduleProfiles = new[]
            {
                new ModuleProfile{ ProfileId = 1, ModuleId = 1 },
                new ModuleProfile{ ProfileId = 1, ModuleId = 2 },
                new ModuleProfile{ ProfileId = 1, ModuleId = 3 },
                new ModuleProfile{ ProfileId = 2, ModuleId = 1 },
                new ModuleProfile{ ProfileId = 2, ModuleId = 3 }
            };

            Product[] _products = new[]
            {
                    new Product { CodProduct = "0001", Description = "Notebook", Status = "A"},
                    new Product { CodProduct = "0002", Description = "Book", Status = "I"},
                    new Product { CodProduct = "0003", Description = "Head Phone", Status = "A"}
             };

            Cosif[] _cosifs = new[]
            {
                    new Cosif { CodProduct = "0001", CodCosif = "00000000001", CodClassification = "000001", Status = "A"},
                    new Cosif { CodProduct = "0002", CodCosif = "00000000002", CodClassification = "000002", Status = "I"},
                    new Cosif { CodProduct = "0003", CodCosif = "00000000003", CodClassification = "000003", Status = "A"}
             };


            Movement[] _movements = new[]
            {
                    new Movement { CodProduct = "0001", CodCosif = "00000000001", EntryNumber = 001, Month = 01, Year = 2020, Description = "Notebook", MovimentDate = DateTime.Now, UserCode = "TESTE", Value = 10000 }
             };


            modelBuilder.Entity<Module>().HasData(_modules);
            modelBuilder.Entity<Profile>().HasData(_profiles);
            modelBuilder.Entity<User>().HasData(_users);
            modelBuilder.Entity<Product>().HasData(_products);
            modelBuilder.Entity<Cosif>().HasData(_cosifs);
            modelBuilder.Entity<Movement>().HasData(_movements);
            modelBuilder.Entity<ModuleProfile>().HasData(_moduleProfiles);
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
