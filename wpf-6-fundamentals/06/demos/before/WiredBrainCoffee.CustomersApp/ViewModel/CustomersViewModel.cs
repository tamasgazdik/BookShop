using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    internal class CustomersViewModel : ViewModelBase
    {
        public CustomerItemViewModel? SelectedCustomer
        {
            get => mySelectedCustomer;
            set
            {
                mySelectedCustomer = value!;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            myCustomerDataProvider = customerDataProvider;
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await myCustomerDataProvider.GetAllAsync();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                } 
            }
        }

        public void Add()
        {
            var customer = new Customer
            {
                FirstName = "New",
                LastName = "Customer"
            };

            var customerViewModel = new CustomerItemViewModel(customer);

            Customers.Add(customerViewModel);
            SelectedCustomer = customerViewModel;
        }

        internal void MoveNavigation()
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        public NavigationSide NavigationSide
        {
            get => myNavigationSide;
            set
            {
                myNavigationSide = value;
                OnPropertyChanged();
            }
        }

        private NavigationSide myNavigationSide;
        private CustomerItemViewModel? mySelectedCustomer;
        private ICustomerDataProvider myCustomerDataProvider;
    }

    public enum NavigationSide
    {
        Left, 
        Right
    }
}
