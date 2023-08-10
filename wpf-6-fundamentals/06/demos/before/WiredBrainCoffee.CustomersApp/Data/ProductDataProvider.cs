using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Data
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
    }

    public class ProductDataProvider : IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> GetProductsAsync()
        {
            await Task.Delay(200); // simulate server work

            return new List<Product>
            {
                new Product()
                {
                    Name = "Whey Protein 2.5kg",
                    Description = "Maximize muscle gains with ultra cool whey protein powder."
                },
                new Product()
                {
                    Name = "Creatine Monohydrate 700g",
                    Description = "Hit PRs on a weekly basis with creatine monohydrate."
                },
                new Product()
                {
                    Name = "THOR Pre-Workout Complex Formula 250g",
                    Description = "Crush your fears with the power of Thor."
                }
            };
        }
    }
}
