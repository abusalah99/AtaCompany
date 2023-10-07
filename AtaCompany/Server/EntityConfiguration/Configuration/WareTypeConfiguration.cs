namespace AtaCompany;

public class WareTypeConfiguration : BaseConfigurationSetting<WareType>
{
    public override void Configure(EntityTypeBuilder<WareType> builder)
    {
        base.Configure(builder);

        builder.HasIndex(e=>e.Name).IsUnique();

        builder.HasMany(e => e.SupplierWareTypes).WithOne(e => e.WareType).HasForeignKey(e => e.WareTypeId);
        builder.HasMany(e => e.Contractors).WithOne(e => e.WareType).HasForeignKey(e => e.WareTypeId);
        builder.HasMany(e => e.Wares).WithOne(e => e.WareType).HasForeignKey(e => e.WareTypeId);
    }
}
