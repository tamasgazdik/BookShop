using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WiredBrainCoffee.CustomersApp.Command;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    internal class CustomersViewModel : ViewModelBase
    {
        #region properties
        public CustomerItemViewModel? SelectedCustomer
        {
            get => mySelectedCustomer;
            set
            {
                mySelectedCustomer = value!;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsCustomerSelected => SelectedCustomer != null;

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

        public NavigationSide NavigationSide
        {
            get => myNavigationSide;
            set
            {
                myNavigationSide = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand MoveNavigationCommand { get; set; }

        public DelegateCommand DeleteCommand { get; set; }
        #endregion

        #region constructor
        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            myCustomerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }
        #endregion

        #region public methods
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
        #endregion

        #region private methods
        private void Add(object? parameter)
        {
            MessageBox.Show("Added customer...");
            var customer = new Customer
            {
                FirstName = "New",
                LastName = "Customer"
            };

            var customerViewModel = new CustomerItemViewModel(customer);

            Customers.Add(customerViewModel);
            SelectedCustomer = customerViewModel;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        private void Delete(object? parameter)
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null;
        }
        #endregion

        #region private fields
        private NavigationSide myNavigationSide;
        private CustomerItemViewModel? mySelectedCustomer;
        private ICustomerDataProvider myCustomerDataProvider;
        #endregion

    }

    public enum NavigationSide
    {
        Left, 
        Right
    }
}
