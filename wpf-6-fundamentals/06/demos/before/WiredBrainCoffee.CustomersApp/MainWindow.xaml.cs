using System.Windows;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myMainViewModel = new MainViewModel(new CustomersViewModel(new CustomerDataProvider()));
            DataContext = myMainViewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await myMainViewModel.LoadAsync();
        }

        private readonly MainViewModel myMainViewModel;
    }
}
