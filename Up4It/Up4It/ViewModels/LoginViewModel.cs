using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Up4It.Services;
using Xamarin.Forms;

namespace Up4It.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private Command _facebookLoginCommand;
        private Command _twitterLoginCommand;
        private Command _googleLoginCommand;
        private IAuthenticationService _authenticationService;

        public const string FacebookLoginCommandPropertyName = "FacebookLoginCommand";
        public const string TwitterLoginCommandPropertyName = "TwitterLoginCommand";
        public const string GoogleLoginCommandPropertyName = "GoogleLoginCommand";

        public LoginViewModel(INavigation navigation, IAuthenticationService authenticationService)
        {
            _navigation = navigation;
            _authenticationService = authenticationService;
        }

        public Command FacebookLoginCommand
        {
            get { return _facebookLoginCommand ?? (_facebookLoginCommand = new Command(async () => ExecuteLoginCommand(MobileServiceAuthenticationProvider.Facebook))); }
        }

        public Command TwitterLoginCommand
        {
            get { return _twitterLoginCommand ?? (_twitterLoginCommand = new Command(async () => ExecuteLoginCommand(MobileServiceAuthenticationProvider.Twitter))); }
        }

        public Command GoogleLoginCommand
        {
            get { return _googleLoginCommand ?? (_googleLoginCommand = new Command(async () => ExecuteLoginCommand(MobileServiceAuthenticationProvider.Google))); }
        }

        protected async Task<MobileServiceUser> ExecuteLoginCommand(MobileServiceAuthenticationProvider provider)
        {
            var user = await _authenticationService.LoginAsync(provider);
            await _navigation.PopModalAsync();

            return user;
        }
    }
}
