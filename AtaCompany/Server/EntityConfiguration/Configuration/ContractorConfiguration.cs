namespace AtaCompany;

public class ContractorConfiguration : BaseConfigurationSetting<Contractor>
{
    public override void Configure(EntityTypeBuilder<Contractor> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.NationalId).IsRequired().HasMaxLength(14);

        builder.HasMany(e => e.LocationContracts).WithOne(e => e.Contractor).HasForeignKey(e => e.ContractorId);
    }
}
