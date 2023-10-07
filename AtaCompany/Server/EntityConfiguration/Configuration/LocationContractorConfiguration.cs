namespace AtaCompany;

public class LocationContractorConfiguration : IEntityTypeConfiguration<LocationContractor>
{
    public void Configure(EntityTypeBuilder<LocationContractor> builder)
    {
        builder.HasKey(e => new { e.LocationId, e.ContractorId });

        builder.HasOne(e => e.Location).WithMany(e => e.LocationContractors).HasForeignKey(e => e.LocationId);
        builder.HasOne(e => e.Contractor).WithMany(e => e.LocationContracts).HasForeignKey(e => e.ContractorId);
    }
}
