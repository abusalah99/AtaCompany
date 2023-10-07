namespace AtaCompany;

public class SupplierConfiguration : BaseConfigurationSetting<Supplier>
{
    public override void Configure(EntityTypeBuilder<Supplier> builder)
    {
        base.Configure(builder);

        builder.HasIndex(e => e.MobileNumber).IsUnique();

        builder.Property(e => e.MobileNumber).IsRequired().HasMaxLength(11);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(200);

        builder.HasMany(e => e.SupplierWareTypes).WithOne(e => e.Supplier).HasForeignKey(e => e.SupplierId);
        builder.HasMany(e => e.LocationSuppliers).WithOne(e => e.Supplier).HasForeignKey(e => e.SupplierId);
    }
}