using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up4It.Services
{
    public interface IAuthenticationService
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider);
    }
}
