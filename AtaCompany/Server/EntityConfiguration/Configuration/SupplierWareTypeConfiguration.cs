namespace AtaCompany;

public class SupplierWareTypeConfiguration : IEntityTypeConfiguration<SupplierWareType>
{
    public void Configure(EntityTypeBuilder<SupplierWareType> builder)
    {
        builder.HasKey(e => new { e.SupplierId, e.WareTypeId });

        builder.HasOne(e => e.Supplier).WithMany(e => e.SupplierWareTypes).HasForeignKey(e => e.SupplierId);
        builder.HasOne(e => e.WareType).WithMany(e => e.SupplierWareTypes).HasForeignKey(e => e.WareTypeId);
    }
}

