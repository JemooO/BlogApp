using System;

namespace BlogApp.Core.Model
{
    public class PostItem
    {
        /// <summary>
        ///  Unique id of the post.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///  Author name
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///  Title of the post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  Can be more detailed.
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        ///  Single image to appear on fixed size.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        ///  Post content, contains html tags.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///  Whether the post published or draft.
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        ///  Post creation date.
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
