namespace AtaCompany;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.PaidMoney).IsRequired().HasMaxLength(10);

        builder.Property(e=>e.PaymentDate).IsRequired().HasDefaultValueSql("GETDATE()");
    }
}