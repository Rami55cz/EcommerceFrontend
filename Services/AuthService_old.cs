using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace EcommerceFrontend.AuthServices
{
    public class AuthServiceOld
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private const string TOKEN_KEY = "jwt_token";
        private string _role = "";
        private int _userId = 1;

        public Task SetFakeUserAsync(string role, int userId)
        {
            _role = role;
            _userId = userId;
            return Task.CompletedTask;
        }

        public Task<string> GetUserRoleAsync()
        {
            return Task.FromResult(_role);
        }

        public Task<int> GetUserIdAsync()
        {
            return Task.FromResult(_userId);
        }

        public AuthServiceOld(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task SaveTokenAsync(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TOKEN_KEY, token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TOKEN_KEY);
        }

        public async Task SetAuthHeaderAsync()
        {
            var token = await GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}