using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Up4It.Models;

namespace Up4It.Repositories
{
    public class UserRepository : MobileServiceRepository<User>
    {
        public UserRepository(IMobileServiceClient client) : base(client)
        {

        }
    }
}
