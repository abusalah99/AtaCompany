namespace AtaCompany;

public static class DependencyInjectionService
{
    public static void AddDependencyInjectionService(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddSingleton(typeof(IBaseRepositorySetting<>), typeof(BaseRepositorySetting<>));
        services.AddSingleton(typeof(IBaseUnitOfWork<>), typeof(BaseUnitOfWork<>));
        services.AddSingleton(typeof(IBaseUnitOfWorkSetting<>), typeof(BaseUnitOfWorkSetting<>));

        services.AddSingleton<IImageConverter, ImageConverter>();
        services.AddSingleton<IFileSaver, FileSaver>();

        services.AddScoped<IContractorRepository, ContractorRepository>();
        services.AddScoped<IContractorUnitOfWork, ContractorUnitOfWork>();

        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ILocationUnitOfWork, LocationUnitOfWork>();

        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ISupplierUnitOfWork, SupplierUnitOfWork>();

        services.AddScoped<IWareRepository, WareRepository>();
        services.AddScoped<IWareUnitOfWork, WareUnitOfWork>();

        services.AddScoped<IWareTypeRepository, WareTypeRepository>();
        services.AddScoped<IWareTypeUnitOfWork, WareTypeUnitOfWork>();

        services.AddTransient<TransactionMiddleware>();
    }
}
