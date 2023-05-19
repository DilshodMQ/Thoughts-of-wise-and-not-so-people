using Blazored.LocalStorage;
using DsrProject.Web.Pages.Auth;
using DsrProject.Web.Pages.Auth.ForgotPwd;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DsrProject.Web
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var url = $"{Settings.IdentityRoot}/connect/token";

            var request_body = new[]
            {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("client_id", Settings.ClientId),
            new KeyValuePair<string, string>("client_secret", Settings.ClientSecret),
            new KeyValuePair<string, string>("username", loginModel.Email!),
            new KeyValuePair<string, string>("password", loginModel.Password!)
        };

            var requestContent = new FormUrlEncodedContent(request_body);

            var response = await _httpClient.PostAsync(url, requestContent);

            var content = await response.Content.ReadAsStringAsync();

            var loginResult = JsonSerializer.Deserialize<LoginResult>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new LoginResult();
            loginResult.Successful = response.IsSuccessStatusCode;

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.AccessToken);
            await _localStorage.SetItemAsync("refreshToken", loginResult.RefreshToken);

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email!);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.AccessToken);

            return loginResult;
        }

        public async  Task<bool> Registr(RegistrModel registrModel)
        {
            string apiUrl = $"{Settings.ApiRoot}/api/v1/accounts/Registr";

                var body = JsonSerializer.Serialize(registrModel);
                var request = new StringContent(body, Encoding.UTF8, "application/json");
                var apiResponse = await _httpClient.PostAsync(apiUrl, request);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                if(!apiResponse.IsSuccessStatusCode)
                {
                    return false;
                }
            return true;
         
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("refreshToken");

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordModel model)
        {

                string apiUrl = $"{Settings.ApiRoot}/api/v1/accounts/ForgotPassword";

                var body = JsonSerializer.Serialize(model);
                var request = new StringContent(body, Encoding.UTF8, "application/json");
                var apiResponse = await _httpClient.PostAsync(apiUrl, request);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                if (!apiResponse.IsSuccessStatusCode)
                {
                    throw new Exception(apiContent);
                }
                else
                return true;
        }

        public async Task<bool> ResetForgotPassword(ResetPasswordModel resetPassword)
        {
            string apiUrl = $"{Settings.ApiRoot}/api/v1/accounts/ResetPassword";

            var body = JsonSerializer.Serialize(resetPassword);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsync(apiUrl, request);

            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            if (!apiResponse.IsSuccessStatusCode)
            {
                return false;
            }
            else
            return true;
        }
    }

}
