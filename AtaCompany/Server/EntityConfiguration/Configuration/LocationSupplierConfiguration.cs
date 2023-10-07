namespace AtaCompany;

public class LocationSupplierConfiguration : IEntityTypeConfiguration<LocationSupplier>
{
    public void Configure(EntityTypeBuilder<LocationSupplier> builder)
    {
        builder.HasKey(e => new { e.LocationId, e.SupplierId });

        builder.HasOne(e => e.Location).WithMany(e => e.LocationSuppliers).HasForeignKey(e => e.LocationId);
        builder.HasOne(e => e.Supplier).WithMany(e => e.LocationSuppliers).HasForeignKey(e => e.SupplierId);
    }
}
