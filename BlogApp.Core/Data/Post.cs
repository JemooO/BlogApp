using BlogApp.Core.Utils;
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
        
        [Required]
        [MaxLength(255, ErrorMessage = "Maximum length for author exceeded")]
        public string Author { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Maximum length for title exceeded")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum length for sub title exceeded")]
        public string SubTitle { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length for image url exceeded")]
        [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", ErrorMessage ="ImageUrl should be a valid url")]
        public string ImageUrl { get; set; }

        private string _content;
        [Required]
        public string Content {
            get
            {
                return _content;
            }
            set
            {
                _content = HtmlSanitizerHelper.Sanitizer.Sanitize(value);
            }
        }
        

        public bool IsPublished { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
