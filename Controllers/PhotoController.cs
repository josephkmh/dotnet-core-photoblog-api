using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using PhotoBlogApi.Models;

namespace PhotoBlogApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{verison:apiVersion}/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly PhotoBlogApiContext _context;

        public PhotosController(PhotoBlogApiContext context)
        {
            _context = context;

            if (_context.Photos.Count() == 0)
            {
                _context.Photos.Add(new Photo { Title = "First photo" });
                _context.SaveChanges();
            }
        }

        // GET api/photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
        {
            return await _context.Photos.ToListAsync();
        }

        // GET api/photos/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/photos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/photos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/photos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
