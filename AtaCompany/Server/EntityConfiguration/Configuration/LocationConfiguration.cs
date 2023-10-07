namespace AtaCompany;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(70);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(200);
        builder.Property(e => e.ImagePath).IsRequired();

        builder.HasMany(e => e.LocationContractors).WithOne(e => e.Location).HasForeignKey(e => e.LocationId);
        builder.HasMany(e => e.LocationSuppliers).WithOne(e => e.Location).HasForeignKey(e => e.LocationId);
        builder.HasMany(e => e.Wares).WithOne(e => e.Location).HasForeignKey(e => e.LocationId);
    }
}