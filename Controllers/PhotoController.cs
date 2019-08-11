using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using PhotoBlogApi.Models;
using PhotoBlogApi.Services;

namespace PhotoBlogApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{verison:apiVersion}/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private DataContext _context;
        private IPhotoService _photoService;

        public PhotosController(
            DataContext dataContext,
            IPhotoService photoService
        )
        {
            _context = dataContext;
            _photoService = photoService;

            if (_context.Photos.Count() == 0)
            {
                _photoService.AddPhoto(new Photo { Title = "First photo!" });
                _photoService.AddPhoto(new Photo { Title = "second photo..." });
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
        public async Task<ActionResult<Photo>> Get(long id)
        {
            Photo photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // POST api/photos
        [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
            return await _photoService.AddPhoto(photo);
        }

        // PUT api/photos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Photo>> Put(long id, Photo photo)
        {
            if (id != photo.Id)
            {
                return BadRequest();
            }

            return await _photoService.UpdatePhoto(id, photo);
        }

        // DELETE api/photos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
