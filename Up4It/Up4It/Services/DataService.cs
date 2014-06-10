using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Up4It.Models;
using Up4It.Repositories;

namespace Up4It.Services
{
    public interface IDataService : IDisposable
    {
        Task<User> GetUser(string id);
        Task<User> CreateUser(User user);
        Task<MeetUp> GetMeetUp(string id);
        Task<MeetUp> CreateMeetUp(MeetUp meetUp);
        
    }

    public class DataService : IDataService
    {
        private UserRepository _userRepository;
        private MeetUpRepository _meetUpRepository;

        public DataService(IMobileServiceClient client)
        {
            _userRepository = new UserRepository(client);
            _meetUpRepository = new MeetUpRepository(client);
        }

        public async Task<User> GetUser(string id)
        {
            var users = await _userRepository.GetAsync(u => u.UserId == id);

            return users.FirstOrDefault();
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<MeetUp> GetMeetUp(string id)
        {
            var meetups = await _meetUpRepository.GetAsync(m => m.Id == id);

            return meetups.FirstOrDefault();
        }

        public async Task<MeetUp> CreateMeetUp(MeetUp meetUp)
        {
            return await _meetUpRepository.AddAsync(meetUp);
        }

        public void Dispose()
        {
            if (_userRepository != null)
                _userRepository.Dispose();

            if (_meetUpRepository != null)
                _userRepository.Dispose();
        }
    }
}
