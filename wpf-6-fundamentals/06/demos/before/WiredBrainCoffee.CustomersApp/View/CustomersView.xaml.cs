using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.View
{
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
          InitializeComponent();
          myCustomersViewModel = new CustomersViewModel(new CustomerDataProvider());
          DataContext = myCustomersViewModel;
          Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await myCustomersViewModel.LoadAsync();
        }

        private CustomersViewModel myCustomersViewModel;    
    }
}
