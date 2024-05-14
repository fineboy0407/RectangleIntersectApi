using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectangleIntersectionWebApi.Data;
using RectangleIntersectionCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RectangleIntersectionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RectanglesController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("intersect")]
        public async Task<IActionResult> GetIntersectingRectangles([FromQuery] double x1, double y1, double x2, double y2)
        {
            var rects = await _dbContext.Rectangles
                .Where(r => (r.X1 <= x2) && (r.X2 >= x1) &&
                            (r.Y1 <= y2) && (r.Y2 >= y1))
                .ToListAsync();
            return Ok(rects);
        }
    }
}