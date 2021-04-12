using DS.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DS.Infrastructure.Context
{
    public partial class DishShopContext : DbContext
    {
        public DishShopContext()
        {
        }

        public DishShopContext(DbContextOptions<DishShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriesCharacteristic> CategoriesCharacteristics { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractsContent> ContractsContents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCharacteristic> ProductsCharacteristics { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopsAvailability> ShopsAvailabilities { get; set; }
        public virtual DbSet<SuppliesContent> SuppliesContents { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<SupplyStatus> SupplyStatuses { get; set; }
        public virtual DbSet<ValueType> ValueTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoriesCharacteristic>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.CharacteristicId });

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoriesCharacteristics)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriesCharacteristics_Categories");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.CategoriesCharacteristics)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriesCharacteristics_Characterisctics");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ValueType)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.ValueTypeId)
                    .HasConstraintName("FK_Characterisctics_ValueTypes");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contracts_Providers");
            });

            modelBuilder.Entity<ContractsContent>(entity =>
            {
                entity.HasKey(e => new { e.ContractId, e.ProductId })
                    .HasName("PK_ContractsContents_1");

                entity.Property(e => e.PricePerUnit).HasColumnType("money");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractsContents)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractsContents_Contracts");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ContractsContents)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractsContents_Products");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Positions");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Shops");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Producers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producers_Countries");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ScanCode)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Producers");
            });

            modelBuilder.Entity<ProductsCharacteristic>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CharacteristicId });

                entity.Property(e => e.Value).HasColumnType("numeric(7, 2)");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.ProductsCharacteristics)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsCharacteristics_Characterisctics");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsCharacteristics)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsCharacteristics_Products");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Providers_Cities");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StreetIdentifier).HasMaxLength(5);

                entity.Property(e => e.StreetName).HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shops_Cities");
            });

            modelBuilder.Entity<ShopsAvailability>(entity =>
            {
                entity.HasKey(e => new { e.ShopId, e.ProductId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShopsAvailabilities)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopsAvailabilities_Products");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopsAvailabilities)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopsAvailabilities_Shops");
            });

            modelBuilder.Entity<SuppliesContent>(entity =>
            {
                entity.HasKey(e => new { e.SupplyId, e.ProductId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SuppliesContents)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SuppliesContents_Products");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.SuppliesContents)
                    .HasForeignKey(d => d.SupplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SuppliesContents_Supplies");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.Property(e => e.DateCanceled).HasPrecision(3);

                entity.Property(e => e.DateCreated)
                    .HasPrecision(3)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateReceived).HasPrecision(3);

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Canceller)
                    .WithMany(p => p.SupplyCancellers)
                    .HasForeignKey(d => d.CancellerId)
                    .HasConstraintName("FK_Supplies_Employees1");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplies_Contracts");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.SupplyCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplies_Employees");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.SupplyReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK_Supplies_Employees2");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplies_Shops");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplies_SupplyStatuses");
            });

            modelBuilder.Entity<SupplyStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValueType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
