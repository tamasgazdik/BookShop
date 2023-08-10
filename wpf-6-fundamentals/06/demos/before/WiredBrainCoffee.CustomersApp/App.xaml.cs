 using System.Windows;
 using Microsoft.Extensions.DependencyInjection;
 using WiredBrainCoffee.CustomersApp.Data;
 using WiredBrainCoffee.CustomersApp.ViewModel;

 namespace WiredBrainCoffee.CustomersApp
{
    public partial class App : Application
    {
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            myServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = myServiceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            services.AddTransient<IProductDataProvider, ProductDataProvider>();
        }

        private readonly ServiceProvider myServiceProvider;
    }
}
