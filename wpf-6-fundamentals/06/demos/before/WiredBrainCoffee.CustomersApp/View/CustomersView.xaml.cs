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

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
          var column = Grid.GetColumn(customerListGrid);

          var newColumn = column == 0 ? 2 : 0;
          Grid.SetColumn(customerListGrid, newColumn);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            myCustomersViewModel.Add(null);
        }

        private CustomersViewModel myCustomersViewModel;    
    }
}
