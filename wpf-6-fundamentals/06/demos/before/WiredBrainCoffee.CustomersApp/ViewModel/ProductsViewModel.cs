using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products { get; } = new();

        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            myProductDataProvider = productDataProvider;
        }

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await myProductDataProvider.GetProductsAsync();
            if (products != null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }

        private readonly IProductDataProvider myProductDataProvider;
    }
}
