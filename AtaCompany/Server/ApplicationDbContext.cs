namespace AtaCompany;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(new ContractorConfiguration())
                           .ApplyConfiguration(new LocationConfiguration())
                           .ApplyConfiguration(new LocationContractorConfiguration())
                           .ApplyConfiguration(new LocationSupplierConfiguration())
                           .ApplyConfiguration(new SupplierConfiguration())
                           .ApplyConfiguration(new SupplierWareTypeConfiguration())
                           .ApplyConfiguration(new WareConfiguration())
                           .ApplyConfiguration(new WareTypeConfiguration());
 }
