using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase? SelectedViewModel
        {
            get => mySelectedViewModelBase;
            set
            {
                mySelectedViewModelBase = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(CustomersViewModel customersViewModel)
        {
            myCustomersViewModel = customersViewModel;
            SelectedViewModel = myCustomersViewModel;
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private readonly CustomersViewModel myCustomersViewModel;
        private ViewModelBase? mySelectedViewModelBase;
    }
}
