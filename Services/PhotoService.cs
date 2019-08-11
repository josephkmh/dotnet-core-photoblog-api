using Microsoft.EntityFrameworkCore;
using PhotoBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoBlogApi.Services
{
  public interface IPhotoService
  {
    Task<Photo> AddPhoto(Photo photo);
    Task<Photo> UpdatePhoto(long id, Photo photo);
  }

  class PhotoService : IPhotoService
  {
    private DataContext _context;

    public PhotoService(DataContext context)
    {
      _context = context;
    }

    public async Task<Photo> AddPhoto(Photo photo)
    {
      _context.Photos.Add(photo);
      await _context.SaveChangesAsync();

      return photo;
    }

    public async Task<Photo> UpdatePhoto(long id, Photo photo)
    {

      _context.Entry(photo).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return photo;
    }
  }
}