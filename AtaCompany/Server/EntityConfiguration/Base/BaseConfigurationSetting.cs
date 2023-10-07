namespace AtaCompany;

public class BaseConfigurationSetting<TEntity> : BaseConfiguration<TEntity> 
    , IEntityTypeConfiguration<TEntity> where TEntity : BaseEntitySetting
{
    public new virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(70);
    }
}
