using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Core.Data
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Author { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
