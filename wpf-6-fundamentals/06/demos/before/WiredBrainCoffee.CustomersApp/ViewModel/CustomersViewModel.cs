using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Customer? SelectedCustomer
        {
            get => mySelectedCustomer;
            set
            {
                mySelectedCustomer = value!;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

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
                    Customers.Add(customer);
                } 
            }
        }

        public void Add(Customer? customer)
        {
            var newCustomer = customer ?? new Customer
            {
                FirstName = "New",
                LastName = "Customer"
            };

            Customers.Add(newCustomer);
            SelectedCustomer = newCustomer;
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private Customer? mySelectedCustomer;
        private ICustomerDataProvider myCustomerDataProvider;
    }
}
