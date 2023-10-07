namespace AtaCompany;

public class WareConfiguration : BaseConfigurationSetting<Ware>
{
    public override void Configure(EntityTypeBuilder<Ware> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Quantity).IsRequired();
        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.Note).IsRequired().HasMaxLength(100);
        builder.Property(e => e.EntranceDate).IsRequired();
    }
}

