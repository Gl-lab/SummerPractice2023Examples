using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;
internal class PostRepository: IPostRepository
{
    private readonly ApplicationContext _context;

    public PostRepository( ApplicationContext context )
    {
        _context = context;
    }

    public List<Post> GetPosts()
    {
        return _context.Posts.Include(x => x.Author).ToList();
    }
}
