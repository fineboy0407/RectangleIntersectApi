using Microsoft.EntityFrameworkCore;
using RectangleIntersectionCore.Models;

namespace RectangleIntersectionWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Rectangle> Rectangles { get; set; }
    }
}