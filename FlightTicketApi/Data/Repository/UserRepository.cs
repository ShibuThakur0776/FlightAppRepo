using FlightTicketApi.Data.Repository.IRepository;
using FlightTicketApi.Models;
using FlightTicketApp.Data;

namespace FlightTicketApi.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Authenticate(string username, string password)
        {
           var userInDB = _context.Users.FirstOrDefault(u=>u.UserName == username && u.Password == password);
            //JWT
            userInDB.Password = "";
            return userInDB;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _context.Users.FirstOrDefault(u=>u.UserName == username);
            if (user == null)
                return true;
            else 
                return false;
        }

        public User Register(string username, string password)
        {
            User user = new User()
            {
                UserName = username,
                Password = password,
                Role = "Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
