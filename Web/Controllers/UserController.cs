using Domain;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Web.DTO;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
    }

    [HttpGet("GetUsers")]
    public List<UserDto> GetUsers()
    {
        return _userRepository.GetAllUsers().ConvertAll(x => new UserDto()
        {
            Name = x.Name,
            Age = x.Age,
            Posts = x.Posts.ConvertAll(y => new PostDto()
            {
                Header = y.Header
            })
        });
    }

    [HttpGet("GetPosts")]
    public List<PostWithAuthorDto> GetPosts()
    {
        return _postRepository.GetPosts().ConvertAll(x => new PostWithAuthorDto()
        {
            Header = x.Header,
            Author = new UserDto()
            {
                Age = x.Author.Age, 
                Name = x.Author.Name
            }
        });
    }

    [HttpPost("SaveUser")]
    public IActionResult SaveUser(UserDto user)
    {
        if (user.Age <= 0)
        {
            return BadRequest();
        }

        User domainUser = new User();
        domainUser.Age = user.Age;
        domainUser.Name = user.Name;
        domainUser.Posts = new List<Post>();
        foreach (PostDto postDto in user.Posts)
        {
            domainUser.Posts.Add(new Post()
            {
                Header = postDto.Header
            });
        }

        _userRepository.AddUser(domainUser);
        _unitOfWork.Commit();

        return new OkResult();
    }
}