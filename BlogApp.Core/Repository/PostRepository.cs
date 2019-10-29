using BlogApp.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Repository
{
    public class PostRepository : DbContext
    {
        public PostRepository(DbContextOptions<PostRepository> options)
            :base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
