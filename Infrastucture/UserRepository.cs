using ConsoleApp1;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;
internal class UserRepository: IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository( ApplicationContext context )
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }

    public void RemoveUser( User user )
    {
        _context.Users.Remove( user );
    }

    public User? GetUser( int userId )
    {
        return _context.Users.FirstOrDefault( x => x.Id == userId );
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.Include(x => x.Posts).ToList();
    }
}
