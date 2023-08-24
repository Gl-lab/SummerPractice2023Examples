﻿using ConsoleApp1;
using Domain.Entity;
using Domain.Repositories;


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

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }
}
