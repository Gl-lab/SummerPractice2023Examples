using Domain;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;

namespace Web.Controllers;
[ApiController]
[Route( "[controller]" )]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet( Name = "GetUser" )]
    public IEnumerable<User> Get()
    {
        return _userRepository.GetUsers();
    }

    [HttpPost( Name = "SaveUser" )]
    public IActionResult SaveUser( UserDto user )
    {
        if (user.Age <= 0)
        {
            return BadRequest();
        }
        User domainUser = new User();
        domainUser.Age = user.Age;
        domainUser.Name = user.Name;
        _userRepository.AddUser( domainUser );
        _unitOfWork.Commit();

        return new OkResult();
    }
}
