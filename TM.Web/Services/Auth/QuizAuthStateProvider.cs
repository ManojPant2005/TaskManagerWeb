using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using TM.Shared;

namespace TM.Web.Services.Auth
{
    public class QuizAuthStateProvider : AuthenticationStateProvider
    {
        private const string AuthType = "quiz-auth";
        private const string UserDataKey = "udata";
        private Task<AuthenticationState> _stateTask;
        private readonly IJSRuntime _js;
        private readonly NavigationManager _nav;

        public QuizAuthStateProvider(IJSRuntime js, NavigationManager nav)
        {
            _js = js;
            _nav = nav;
            SetAuthStateTask();
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
              _stateTask;

        // Current logged-in user
        public LoggedInUser User { get; private set; }
        public bool IsLoggedIn => User?.Id > 0;

        // Method to set the user state upon login
        public async Task SetLoginAsync(LoggedInUser user)
        {
            User = user;
            SetAuthStateTask();
            NotifyAuthenticationStateChanged(_stateTask);
            await _js.InvokeVoidAsync("localStorage.setItem", UserDataKey, user.ToJson());
        }

        public bool IsInitializing { get; private set; } = true;

        // Method to logout and clear user data
        public async Task SetLogoutAsync()
        {
            User = null;
            SetAuthStateTask();
            NotifyAuthenticationStateChanged(_stateTask);
            await _js.InvokeVoidAsync("localStorage.removeItem", UserDataKey);
        }

        // Method to initialize and check for valid token in localStorage
        public async Task InitilizeAsync()
        {
            try
            {
                var uData = await _js.InvokeAsync<string?>("localStorage.getItem", UserDataKey);
                if (string.IsNullOrWhiteSpace(uData))
                {
                    RedirectToLogin();
                    return;
                }

                var user = LoggedInUser.LoadFrom(uData);
                if (user == null || user.Id == 0)
                {
                    RedirectToLogin();
                    return;
                }

                // Check if JWT token is valid
                if (!IsTokenValid(user.Token))
                {
                    RedirectToLogin();
                    return;
                }

                await SetLoginAsync(user);
            }
            catch (Exception ex)
            {
                // Handle error if necessary
            }
            finally
            {
                IsInitializing = false;
            }
        }

        // Method to redirect the user to login page
        private void RedirectToLogin()
        {
            _nav.NavigateTo("auth/login");
        }

        // Method to check if JWT token is valid
        private static bool IsTokenValid(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            var jwtHandler = new JwtSecurityTokenHandler();
            if (!jwtHandler.CanReadToken(token))
                return false;

            var jwt = jwtHandler.ReadJwtToken(token);
            var expClaim = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp);
            if (expClaim == null)
                return false;

            var expTime = long.Parse(expClaim.Value);
            var expDatetimeUtc = DateTimeOffset.FromUnixTimeSeconds(expTime).UtcDateTime;

            return expDatetimeUtc < DateTime.UtcNow;
        }

        // Set the authentication state based on the logged-in user
        private void SetAuthStateTask()
        {
            if (IsLoggedIn)
            {
                var claims = User.ToClaims();

                var identity = new ClaimsIdentity(claims, AuthType);
                var principal = new ClaimsPrincipal(identity);
                var authState = new AuthenticationState(principal);
                _stateTask = Task.FromResult(authState);
            }
            else
            {
                var identity = new ClaimsIdentity();
                var principal = new ClaimsPrincipal(identity);
                var authState = new AuthenticationState(principal);
                _stateTask = Task.FromResult(authState);
            }
        }

        // New method to check if the current user is in a specific role
        public bool IsInRole(string role)
        {
            return User?.Role == role;
        }
    }
}
