using Domain.Entity;

namespace Domain.Repositories;
public interface IUserRepository
{
    void AddUser( User user );
    void RemoveUser( User user );
    User? GetUser( int userId );
    List<User> GetAllUsers();
}
