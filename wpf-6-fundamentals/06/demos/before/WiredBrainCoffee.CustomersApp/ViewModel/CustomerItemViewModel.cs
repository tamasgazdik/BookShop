using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        public int Id => myCustomer.Id;

        public string? FirstName 
        { 
            get => myCustomer.FirstName;
            set
            {
                myCustomer.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string? LastName
        {
            get => myCustomer.LastName;
            set
            {
                myCustomer.LastName = value;
                OnPropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => myCustomer.IsDeveloper;
            set
            {
                myCustomer.IsDeveloper = value;
                OnPropertyChanged();
            }
        }

        public CustomerItemViewModel(Customer customer)
        {
            myCustomer = customer;
        }

        private Customer myCustomer;
    }
}
