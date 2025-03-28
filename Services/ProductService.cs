using System.Net.Http.Json;
using EcommerceFrontend.Models;
using EcommerceFrontend.Pages;

namespace EcommerceFrontend.Services{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
    
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public async Task<List<Product>> GetProductsAsync()
        {
            // Makes an HTTP GET request to fetch the product list from the API.
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/product");
        }

        public async Task CreateProductAsync(Product product){
            await _httpClient.PostAsJsonAsync("api/product", product);
        }

        public async Task DeleteProductAsync(int id){
            await _httpClient.DeleteAsync($"api/product/{id}");
        }
        public async Task<Product?> GetProductByIdAsync(int id){
            return await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
        }

        public async Task UpdateProductsAsync(int id, Product product){
            await _httpClient.PutAsJsonAsync($"api/product/{id}", product);
        }
    }
}