using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogApp.Core.Data;
using BlogApp.Core.Repository;
using Ganss.XSS;
using StackExchange.Redis;
using BlogApp.Core.Notification;

namespace BlogApp.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostRepository _context;
        
        
        public PostsController(PostRepository context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetPosts(int? pageNum, int? pageSize)
        {
            if (pageNum.HasValue && pageSize.HasValue)
                return _context.Posts.Skip((pageNum.Value - 1) * pageSize.Value).Take(pageSize.Value);
            return _context.Posts;
        }

        
        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromRoute] Guid id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            

            if (PostExists(id))
            {
                var originPost = await _context.Posts.FindAsync(id);

                originPost.Title = post.Title;
                originPost.SubTitle = post.SubTitle;
                originPost.ImageUrl = post.ImageUrl;
                originPost.IsPublished = post.IsPublished;
                originPost.Content = post.Content;

                _context.Entry(originPost).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<IActionResult> PostPost(Post post)
        {
            post.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            NotificationManager.Notification.SubmitNotification(string.Format("{0} Write new Post with title {1}", 
                post.Author, post.Title), string.Format("http://localhost:4000/posts/{0}", post.Id));
                
            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}